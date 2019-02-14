/*
	Martin Alfredo Alegria Vizcaya
	A01022216
	EnemyBulletControl.cs
	Script that controls the motion of the enemies' bullets
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour {

	private Transform bullet; //Bullet that will be controled
	public float speed; //Speed at which it moves

	
	void Start () {
		bullet = GetComponent<Transform> ();
	}

	void FixedUpdate(){
		//Move the bullet by the speed set
		bullet.position += Vector3.up * -speed;

		//If the bullet passes the screen it is destroyed
		if (bullet.position.y <= -10)
			Destroy (bullet.gameObject);
	}

	
	//When the bullet (which was set as Trigger) enters an object with Collider...
	void OnTriggerEnter(Collider other)
	{
		//If the collider is the player..
		if (other.tag == "Player") {
			Destroy (other.gameObject); //We destroy the bullet
			Destroy (gameObject); //We destroy the player
			GameOver.isDead = true; //And we kill him

		} 
		//If the collider is a base..
		else if (other.tag == "Base") {
			GameObject playerBase = other.gameObject;
			BaseHealth baseHealth = playerBase.GetComponent<BaseHealth> ();
			baseHealth.health -= 1; // We substract form that base's health
			Destroy (gameObject); //We destroy the bullet
		}
	}
}