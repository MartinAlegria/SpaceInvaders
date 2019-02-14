/*
	Martin Alfredo Alegria Vizcaya
	A01022216
	GameOver.cs
	Script that presents the Game Over screen, it varies depending if the player wins or loses.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	public static bool isDead = false; //Variable to check if the player is dead or not
	public static bool win = false; //Variable to check if the player has won or not
	private Text gameOver; //Text that will be presented to the player if he wins/loses
    
    void Start()
    {
    	/*
		Get the text component and disable it, so it doesn´t present itself 
		in the screen.
    	*/
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
    }

    void Update()
    {
    	/*
		If the player is dead time freezes
		and the "GAME OVER" text is presented on screen.
    	*/
     	if(isDead){
     		Time.timeScale = 0;
     		gameOver.enabled = true;
     	}   

     	/*
		If the player wins the text changes to You WIN
		and its presented to the player while time freezes.
     	*/
     	if(win){
     		gameOver.text = "You WIN";
     		Time.timeScale = 0;
     		gameOver.enabled = true;
     	}
    }
}
