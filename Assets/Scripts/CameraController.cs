using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	public Transform player;
	public Vector3 offset;
	public Health playerHealth;

	private MusicSingleton musicSingleton;

	public void Start()
	{
		GameObject backgroundMusic = GameObject.FindGameObjectWithTag ("BackgroundMusic");
		musicSingleton = MusicSingleton.Instance ();
	}

	// Update is called once per frame
	void LateUpdate () {
		if (playerHealth.health > 0) {
			transform.position = player.position + offset;
			//musicSingleton.transform.position = transform.position;
		}
	}
}
