using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangePanel : MonoBehaviour {

	public Sprite[] pics;

	private Image panel;
	private int curr = 0;

	// Use this for initialization
	void Start () {
		panel = GetComponent<Image> ();
		panel.sprite = pics [curr];
	}
	
	public void OnClickNext()
	{
		curr++;
		if(curr < pics.Length)
			panel.sprite = pics[curr];
		else
			Application.LoadLevel("Level 01");
	}

	public void OnClickPrev()
	{
		curr--;
		if (curr >= 0)
				panel.sprite = pics [curr];
		else
				Application.LoadLevel ("Main Menu");
	}
}
