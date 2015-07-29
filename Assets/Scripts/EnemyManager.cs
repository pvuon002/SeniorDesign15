using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

	public Health playerHealth;
	public Transform player;
	public Transform[] spawnPoints;
	public GameObject enemy;
	public float spawnTime;
	public float spawnInterval;
	public float spawnDistance;
	public int spawnDiameter;

	private int numSpawned = 0;
	private bool startSpawn = false;
	private bool continueSpawn = true;
	private int onTime = 0;
	private int maxOnTime = 2;
	private int offTime = 0;
	private int maxOffTime = 8;

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("Spawn", spawnTime, spawnInterval);

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (startSpawn) {
			InvokeRepeating ("Spawn", spawnTime, spawnInterval);
			startSpawn = false;
		}
	}

	void Spawn()
	{
				if (continueSpawn) {
						foreach (Transform spawnPoint in spawnPoints)
								if (Vector3.Distance (spawnPoint.position, player.position) <= spawnDistance) {	
										Vector3 spawnPosition = new Vector3 (spawnPoint.position.x + Random.Range (-spawnDiameter / 2, spawnDiameter / 2),
				                                    	spawnPoint.position.y,
				                                    	spawnPoint.position.z + Random.Range (-spawnDiameter / 2, spawnDiameter / 2));
										Quaternion randomRotation = Random.rotation;
										Instantiate (enemy, spawnPosition, spawnPoint.rotation);
								}
						onTime++;
						if (onTime >= maxOnTime) {
								onTime = 0;
								continueSpawn = false;
						}
				} else {
						offTime++;
						if (offTime >= maxOffTime) {
								offTime = 0;
								continueSpawn = true;
						}
				}
		}

	public void StartSpawn()
	{
		startSpawn = true;
	}
}
