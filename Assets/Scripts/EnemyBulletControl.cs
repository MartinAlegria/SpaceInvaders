using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour {

	private Transform bullet;
	public float speed;

	// Use this for initialization
	void Start () {
		bullet = GetComponent<Transform> ();
	}

	void FixedUpdate(){
		bullet.position += Vector3.up * -speed;

		if (bullet.position.y <= -10)
			Destroy (bullet.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			Destroy (gameObject);
			GameOver.isDead = true;
			
		} else if (other.tag == "Base") {
			GameObject playerBase = other.gameObject;
			BaseHealth baseHealth = playerBase.GetComponent<BaseHealth> ();
			baseHealth.health -= 1;
			Destroy (gameObject);
		}
	}
}