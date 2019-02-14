/*
	Martin Alfredo Alegria Vizcaya
	A01022216
	PlayerController.cs
	Script that controls the player's ship.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private Transform player; //The player's sprite
	private float nextFire; //Min time to wait before firing another bullet
	public float speed; //Speed at which the player moves
	public float maxPoint, minPoint; //Bounds of the scene/screen

	public GameObject bullet; //The bullet
	public Transform bulletSpawn; //Where the bullet will spawn
	public float fireRate; //Rate at which the player can fire the bullet


    // Start is called before the first frame update
    void Start(){
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate(){

		float h = Input.GetAxis("Horizontal");

		//Don't let the player move further than the screen in the left side
		if(player.position.x < minPoint && h < 0){
			h = 0;
		}    
		//Don't let the player move further than the screen in the right side    
		else if (player.position.x > maxPoint && h > 0){
			h = 0;
		}
		//Move the player
		player.position += Vector3.right * h * speed;
    }

    void Update(){
    	//If the space bar is pressed and the player has waited enough time to fire..
    	if(Input.GetKeyDown(KeyCode.Space) /* Input.GetKeyDown("space")*/ && Time.time > nextFire){
    		//Create an instance of the bullet and reset the nextFire time
    		nextFire = Time.time + fireRate;
    		Instantiate(bullet, bulletSpawn.position,bulletSpawn.rotation);
    	}
    }

}//CLASS
