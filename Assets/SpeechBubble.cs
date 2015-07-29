using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SpeechBubble : MonoBehaviour
{
	//this game object's transform
	private Transform goTransform;
	//the game object's position on the screen, in pixels
	private Vector3 goScreenPos;
	//the game objects position on the screen
	private Vector3 goViewportPos;
	//The speech to display in order
	private string[] dialogue = {"Oh, you are up! You were out for quite a while there.",
								"Don't worry, I am on your side.",
								"I saw you arrive and hid you in this park to keep you safe.",
								"To return back safely, help me collect all the time machine pieces!"};
	private KeyCode continueKey = KeyCode.Space;
	private int numDialogue;
	private int currDialogue = 0;
	private bool displayNext;
	private bool endDialogue;
	
	//the width of the speech bubble
	public int bubbleWidth = 200;
	//the height of the speech bubble
	public int bubbleHeight = 100;

	public PlayerController player;
	public EnemyManager enemyManager;
	
	//an offset, to better position the bubble
	public float offsetX = 0;
	public float offsetY = 150;
	
	//an offset to center the bubble
	private int centerOffsetX;
	private int centerOffsetY;
	
	//a material to render the triangular part of the speech balloon
	public Material mat;
	//a guiSkin, to render the round part of the speech balloon
	public GUISkin guiSkin;
	
	//use this for early initialization
	void Awake ()
	{
		//get this game object's transform
		goTransform = this.GetComponent<Transform>();

		numDialogue = dialogue.Length;
		displayNext = false;
		endDialogue = false;
	}
	
	//use this for initialization
	void Start()
	{
		//if the material hasn't been found
		if (!mat)
		{
			Debug.LogError("Please assign a material on the Inspector.");
			return;
		}
		
		//if the guiSkin hasn't been found
		if (!guiSkin)
		{
			Debug.LogError("Please assign a GUI Skin on the Inspector.");
			return;
		}
		
		//Calculate the X and Y offsets to center the speech balloon exactly on the center of the game object
		centerOffsetX = bubbleWidth/2;
		centerOffsetY = bubbleHeight/2;
	}
	
	//Called once per frame, after the update
	void LateUpdate()
	{
		//find out the position on the screen of this game object
		goScreenPos = Camera.main.WorldToScreenPoint(goTransform.position);	
		
		//Could have used the following line, instead of lines 70 and 71
		//goViewportPos = Camera.main.WorldToViewportPoint(goTransform.position);
		goViewportPos.x = goScreenPos.x/(float)Screen.width;
		goViewportPos.y = goScreenPos.y/(float)Screen.height;
	}
	
	//Draw GUIs
	void OnGUI()
	{
		if (!endDialogue)
		{

			//Begin the GUI group centering the speech bubble at the same position of this game object. After that, apply the offset
			Rect groupRect = new Rect (goScreenPos.x - centerOffsetX - offsetX, Screen.height - goScreenPos.y - centerOffsetY - offsetY, bubbleWidth, bubbleHeight);
			GUI.BeginGroup (groupRect);

			//Render the round part of the bubble
			Rect bubbleRect = new Rect (0, 0, 200, 100);
			GUI.Label (bubbleRect, "", guiSkin.customStyles [0]);

			//Render the text
			Rect textRect = new Rect (10, 25, 190, 50);
			GUI.Label (textRect, dialogue [currDialogue], guiSkin.label);



			//If the button is pressed, go back to 41 Post
			if (GUI.Button (new Rect (50, 60, 100, 30), "Continue")) {
					displayNext = true;
			}

			GUI.EndGroup ();

			if (displayNext) {
				currDialogue++;
				displayNext = false;
				if (currDialogue >= numDialogue) {
					endDialogue = true;
					player.EnableGuns();
					enemyManager.StartSpawn();
				}
				
			}
		}
	}
	
	//Called after camera has finished rendering the scene
	void OnRenderObject()
	{
		if (!endDialogue)
		{
			//push current matrix into the matrix stack
			GL.PushMatrix ();
			//set material pass
			mat.SetPass (0);
			//load orthogonal projection matrix
			GL.LoadOrtho ();
			//a triangle primitive is going to be rendered
			GL.Begin (GL.TRIANGLES);

			//set the color
			GL.Color (Color.white);

			//Define the triangle vetices
			GL.Vertex3 (goViewportPos.x, goViewportPos.y + (offsetY / 3) / Screen.height, 0.1f);
			GL.Vertex3 (goViewportPos.x - (bubbleWidth / 3) / (float)Screen.width, goViewportPos.y + offsetY / Screen.height, 0.1f);
			GL.Vertex3 (goViewportPos.x - (bubbleWidth / 8) / (float)Screen.width, goViewportPos.y + offsetY / Screen.height, 0.1f);

			GL.End ();
			//pop the orthogonal matrix from the stack
			GL.PopMatrix ();
		}
	}
}