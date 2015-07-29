/*
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnTMPieceCollect : MonoBehaviour {

	public GameObject TimeMachinePieces;
	public Text messageText;
	public Text pieceCountText;

	private int numPiecesTotal;
	private int numPiecesCollected = 0;

	public void Start()
	{
		numPiecesTotal = TimeMachinePieces.transform.childCount;
		UpdatePieceCountText (numPiecesCollected);

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "TimeMachinePiece") {
			Destroy(col.gameObject);
			numPiecesCollected++;
			UpdatePieceCountText (numPiecesCollected);
			if(numPiecesTotal - numPiecesCollected > 0)
			{
				StartCoroutine(ShowMessage ("You found a time machine piece! \n Only "
			                            + (numPiecesTotal - numPiecesCollected).ToString () + " pieces remaining!", 2.0f));
			}
			else // You found all the pieces!
			{
				StartCoroutine(ShowMessage ("Congrats, you found all the pieces!", 3.0f));
			}
		}
	}

	IEnumerator ShowMessage(string msg, float delay)
	{
		messageText.text = msg;
		messageText.enabled = true;
		yield return new WaitForSeconds (delay);
		messageText.enabled = false;
	}

	void UpdatePieceCountText(int count)
	{
		pieceCountText.text = "x" + count.ToString ();
	}
}
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnTMPieceCollect : MonoBehaviour {
	
	public GameObject TimeMachinePieces;
	public Text messageText;
	public Text pieceCountText;
	public GameObject tpflare;
	
	private int numPiecesTotal;
	private int numPiecesCollected = 0;
	
	private bool coll_tp1= false;
	private bool show_win= false;
	
	// Format: Rectangle ( x , y , width, height )
	Rect _quitWindowRect = new Rect ( Screen.width/2-125, Screen.height/2-25, 300, 70 );
	private float msgDelay= 2.7f;
	
	void OnGUI()
	{
		GUIStyle myStyle = new GUIStyle (GUI.skin.window);
		myStyle.fontSize = 18;
		myStyle.font = (Font)Resources.Load ("Fonts/Arial", typeof(Font));
		myStyle.normal.textColor = Color.yellow;
		GUI.backgroundColor = Color.white;
		if (show_win) {
			if (coll_tp1) {
				GUI.Window (123, _quitWindowRect, QuitWindowFunction, 
				            "You have found a \n Time Machine Piece! \n", myStyle);
				pieceCountText.text = "x1";
			/*} else if (coll_tp2) {
				GUI.Window (5324, _quitWindowRect, QuitWindowFunction, 
				            "You have found your \n Second Time Machine Piece! \n ", myStyle);
				pieceCountText.text = "x2";
			} else if (coll_tp3) {
				GUI.Window (1543, _quitWindowRect, QuitWindowFunction, 
				            "Hooray! You have found your \n Third Time Machine Piece! Keep it up!\n ", myStyle);
				pieceCountText.text = "x3";
			} else if (coll_tp3) {
				GUI.Window (2453, _quitWindowRect, QuitWindowFunction, 
				            "You have found your \n Fourth Time Machine Piece! Justone more to go!\n ", myStyle);
				pieceCountText.text = "x4";
			} else if (coll_tp3) {
			GUI.Window (9864, _quitWindowRect, QuitWindowFunction, 
			            "Hooray! You have found the Final Time Machine Piece! Take them back to the Scientist!\n ", myStyle);
				pieceCountText.text = "x5";*/
		}
		}
	}
	
	void QuitWindowFunction ( int id )
	{
		/*if (GUI.Button (new Rect (100, 50, 100, 30), "Got It!")) {
						show_win = false;
						coll_tp1 = false;
						coll_tp2 = false;
						coll_tp3 = false;
				}*/
		StartCoroutine (ShowMessage());
		
	}
	
	public void Start()
	{
		numPiecesTotal = TimeMachinePieces.transform.childCount;
		Debug.Log (numPiecesTotal);
		//UpdatePieceCountText (numPiecesCollected);
		pieceCountText.text = "x0";
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "TimeMachinePiece") {
			Destroy(col.gameObject);
			//GameObject newFlare = Instantiate(tpflare, TimeMachinePieces.transform.position, TimeMachinePieces.transform.rotation) as GameObject;
			numPiecesCollected++;
			Debug.Log ("Time MAchine Piece: " + numPiecesCollected);
			
			// sets the boolean "show_win" to true
			// so that there is a pop up window
			show_win= true;
			
			if(numPiecesCollected == 1)
				coll_tp1 = true;
			else if(numPiecesCollected == 2)
				coll_tp1 = true;
			else if(numPiecesCollected == 3)
				coll_tp1 = true;
			else if(numPiecesCollected == 4)
				coll_tp1 = true;
			else if(numPiecesCollected == 5)
				coll_tp1 = true;
			
			/*UpdatePieceCountText (numPiecesCollected);
			if(numPiecesTotal - numPiecesCollected > 0)
			{
				StartCoroutine(ShowMessage ("You found a time machine piece! \n Only "
			                            + (numPiecesTotal - numPiecesCollected).ToString () + " pieces remaining!", 2.0f));
			}
			else // You found all the pieces!
			{
				StartCoroutine(ShowMessage ("Congrats, you found all the pieces!", 3.0f));
			}*/
		}
	}
	
	private IEnumerator ShowMessage()
	{
		StopCoroutine ("ShowMessage");
		//messageText.text = msg;
		//messageText.enabled = true;
		yield return new WaitForSeconds (msgDelay);
		show_win = false;
		coll_tp1 = false;

		//messageText.enabled = false;
	}
	
	/*void UpdatePieceCountText(int count)
	{
		pieceCountText.text = "x" + count.ToString ();
	}*/
}