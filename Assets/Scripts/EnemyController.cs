/*
	Martin Alfredo Alegria Vizcaya
	A01022216
	EnemyController.cs
	Script that controls the motion of the horde of enemies.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
	private Transform enemyHolder; //The gameobject that holds all the enemies
	public float speed; //Speed at which they move

	public GameObject bullet; //Bullet that they fire towards the player
	public double fireRate = 0.997; //Fire rate of those bullets

    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.2f); //Invoke the MoveEnemy func
        enemyHolder = GetComponent<Transform>();
    }

    // Move the Enemy
    void MoveEnemy(){
    	//Move the horde at the speed set
    	enemyHolder.position += Vector3.right * speed;

    	//for each enemy in the horde
    	foreach( Transform enemy in enemyHolder){
    		//Dont let them go off the screen
    		if(enemy.position.x < -10.5 || enemy.position.x > 10.5){
    			//Return them back to the screen
    			speed = -speed; 
    			enemyHolder.position += Vector3.down * 0.5f; //Go down
    			return;
    		}

    		//Fire a bullet from a random enemy
    		if(Random.value > fireRate){
    			Instantiate(bullet, enemy.position, enemy.rotation);
    		}

    		//If the horde (or one enemy) reaches the players base, GAME OVER
    		if(enemy.position.y <= -1.08){
    			GameOver.isDead = true;
    			Time.timeScale = 0;
    		}

    	}

    	//If there is one enemy left, speed a bit up
    	if(enemyHolder.childCount == 1){
    			CancelInvoke();
    			InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
    		}

    	//If there is no enemy left, player has won
    	if(enemyHolder.childCount == 0){
    			PlayerScore.playerScore = 0;
    			GameOver.win = true;
    	}
    }
}
