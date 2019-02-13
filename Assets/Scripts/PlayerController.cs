using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private Transform player;
	private float nextFire;
	public float speed;
	public float maxPoint, minPoint;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;


    // Start is called before the first frame update
    void Start(){
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate(){
		float h = Input.GetAxis("Horizontal");

		if(player.position.x < minPoint && h < 0){
			h = 0;
		}        
		else if (player.position.x > maxPoint && h > 0){
			h = 0;
		}
		player.position += Vector3.right * h * speed;
    }

    void Update(){
    	if(Input.GetKeyDown(KeyCode.Space) /* Input.GetKeyDown("space")*/ && Time.time > nextFire){
    		nextFire = Time.time + fireRate;
    		Instantiate(shot, shotSpawn.position,shotSpawn.rotation);
    	}
    }

}//CLASS
