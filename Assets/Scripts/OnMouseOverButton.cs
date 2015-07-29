using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnMouseOverButton : MonoBehaviour {
	
	public Sprite normal;
	public Sprite hover;

	private SpriteRenderer spriteRenderer;

	public void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public void OnMouseOver()
	{
		spriteRenderer.sprite = hover;
	}

	public void OnMouseExit()
	{
		spriteRenderer.sprite = normal;
	}
}
