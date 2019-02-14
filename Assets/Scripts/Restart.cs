/*
	Martin Alfredo Alegria Vizcaya
	A01022216
	Reestart.cs
	Script that gives the reestart functionality by pressing the R key.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) //If the player presses the R key
        {
        	/*
        	The score is reset, we bring back the player from the dead
        	We unfreeze time and load our scene.
        	*/
        	PlayerScore.playerScore = 0;
        	GameOver.isDead = false;
            GameOver.win = false;
        	Time.timeScale = 1;
        	SceneManager.LoadScene("SampleScene");
        }
    }
}
