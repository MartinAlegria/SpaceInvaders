﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
	private Transform enemyHolder;
	public float speed;

	public GameObject shot;
	public double fireRate = 0.997;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.2f);
        enemyHolder = GetComponent<Transform>();
    }

    // Update is called once per frame
    void MoveEnemy(){
    	enemyHolder.position += Vector3.right * speed;

    	foreach( Transform enemy in enemyHolder){
    		if(enemy.position.x < -10.5 || enemy.position.x > 10.5){
    			speed = -speed;
    			enemyHolder.position += Vector3.down * 0.5f;
    			return;
    		}

    		if(enemy.position.y <= -4){
    			GameOver.isDead = true;
    			Time.timeScale = 0;
    		}

    		if(enemyHolder.childCount== 1){
    			CancelInvoke();
    			InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
    		}

    		if(enemyHolder.childCount == 0){
    			PlayerScore.playerScore = 0;
    			SceneManager.LoadScene("SampleScene");
    		}
    	}
    }
}