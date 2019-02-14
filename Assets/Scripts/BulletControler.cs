/*
	Martin Alfredo Alegria Vizcaya
	A01022216
	BulletControler.cs
	Script that controls the bullet's motion and collitions.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{

	private Transform bullet; //The bullet we'll be firing
	public float speed; //The speed at which the bullet will travel

    void Start()
    {
        bullet = GetComponent<Transform> ();
    }

    void FixedUpdate(){
    	bullet.position += Vector3.up * speed; //Formula to move the bullet up at the speed set.
    	/*
		If the bullet passes the upper bound of the screen, its deleted from memory
		so that it doesnt impact memory.
    	*/
    	if(bullet.position.y >= 10) 
    		Destroy(gameObject);

    }

    
	//When the bullet (which was set as Trigger) enters an object with Collider...
    void OnTriggerEnter(Collider other){

    	/*
		If the collider the bullet enters is an enemy we destroy it and the bullet as well.
		Then, we increment the player's score by 10.
    	*/
    	if (other.tag == "Enemy"){
    		Debug.Log("Enemy");
    		Destroy(other.gameObject);
    		Destroy(gameObject);
    		PlayerScore.playerScore += 10;
    		
    	}
    	/*
		If the collider the bullet enters is a base, then we reduce a point from
		the base's "health" and destroy the bullet. 
    	*/
    	else if (other.tag == "Base"){
    		GameObject playerBase = other.gameObject;
			BaseHealth baseHealth = playerBase.GetComponent<BaseHealth> ();
			baseHealth.health -= 1;
			Destroy (gameObject);
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
