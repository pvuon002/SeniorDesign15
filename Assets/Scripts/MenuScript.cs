using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public void OnClickPlay()
	{
		Application.LoadLevel ("Show");
	}

	public void OnClickQuit()
	{
		Application.Quit ();
	}

	public void OnClickHelp()
	{
		Application.LoadLevel("Help");
	}
}
