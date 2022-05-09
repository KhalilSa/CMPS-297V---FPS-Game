using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


 //class that creates a simple AI to move around the map and shoot at the player
public class AI_Sample1 : MonoBehaviour{
    	//define the position of the player
	public Transform player;
	//define the position of the enemy
	public Transform enemy;
	//define the speed of the enemy
	public float speed;
	//define the range of the enemy
	public float range;

	public float visionRange = 100f;
	//define the bullet prefab
	public GameObject bullet;
	//define the rate of fire
	public float fireRate;
	//define the next time the enemy can fire
	private float nextFire;

	// Use this for initialization
	void Start () {
		//set the next time the enemy can fire
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update () {
		//move the enemy towards the player
		if (Vector3.Distance(Vector3.MoveTowards(enemy.position, player.position, speed * Time.deltaTime), player.position) < visionRange)
		{
			enemy.position = Vector3.MoveTowards(enemy.position, player.position, speed * Time.deltaTime);
			speed = 5;

        }
        else
        {
			speed = 3;
        }
		//if the enemy can fire and the player is in range
		if (Time.time > nextFire && Vector3.Distance(enemy.position, player.position) < range){
			//set the next time the enemy can fire
			nextFire = Time.time + fireRate;
			//create a new bullet
			print("Attack");
		}
	}
}
 