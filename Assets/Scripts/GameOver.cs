﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	public static bool isDead = false;
	public static bool win = false;
	private Text gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
     	if(isDead){
     		Time.timeScale = 0;
     		gameOver.enabled = true;
     	}   

     	if(win){
     		gameOver.text = "You WIN";
     		Time.timeScale = 0;
     		gameOver.enabled = true;
     	}
    }
}
