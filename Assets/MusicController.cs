using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	private MusicSingleton music;

	// Use this for initialization
	void Start () {
		music = MusicSingleton.Instance ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		music.MoveToMainCamera ();
	}
}
