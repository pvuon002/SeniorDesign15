using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public int maxSpawns;
	public int radius;
	public int interval;
	public int downTime;
	public float minRange;
	public GameObject human;

	private Transform player;
	private int currTime = 0;
	private int currSpawns = 0;

	void Start()
	{
		player = GameObject.FindWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		if (currSpawns < maxSpawns && Vector3.Distance (transform.position, player.position) <= minRange)
		{	
			if(currSpawns >= maxSpawns)
			{

			}
			Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-radius, radius),
			                                    transform.position.y,
			                                    transform.position.z + Random.Range(-radius, radius/2));
			Quaternion randomRotation = Random.rotation;
			Instantiate (human, spawnPosition, randomRotation);
			currSpawns++;
		}
	}
}
