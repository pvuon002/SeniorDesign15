using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	public void OnClickRestart()
	{
		Debug.Log ("restart");
		Application.LoadLevel ("Level 01");
	}
	
	public void OnClickHome()
	{
		Application.LoadLevel ("Main Menu");
	}

	public void OnClickQuit()
	{
		Application.Quit ();
	}

}
