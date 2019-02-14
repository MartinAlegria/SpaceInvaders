/*
	Martin Alfredo Alegria Vizcaya
	A01022216
	PlayerScore.cs
	Script that manages the player's score as well as the Score text on screen.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
	public static float playerScore = 0; //Variable were the score is saved
	private Text scoreText; //Scoreboard text
    
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + playerScore; //Show the current score.
    }
}
