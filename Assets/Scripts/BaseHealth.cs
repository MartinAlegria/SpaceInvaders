/*
	Martin Alfredo Alegria Vizcaya
	A01022216
	BaseHealth.cs
	Script that monitors the Base's health
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
	public float health = 6;

    // Update is called once per frame
    void Update()
    {
    	//If there is no health left, destroy the base.
        if(health <= 0)
        {
        	Destroy(gameObject);
        }
    }
}
