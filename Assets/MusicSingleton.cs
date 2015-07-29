using UnityEngine;
using System.Collections;

public class MusicSingleton : MonoBehaviour {

	private static MusicSingleton instance = null;
	private static GameObject mainCamera;

	public static MusicSingleton Instance()
	{
		return instance;
	}

	// Use this for initialization
	void Awake () {
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		if (instance != null && instance != this) {
			Debug.Log ("singleton exists");
			Destroy (this.gameObject);

			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
		//MoveToMainCamera ();
	}

	public void Update()
	{
		MoveToMainCamera ();
	}

	public void MoveToMainCamera()
	{
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		transform.position = mainCamera.transform.position + mainCamera.transform.forward * 5;
	}
}
