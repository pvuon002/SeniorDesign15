using UnityEngine;
using System.Collections;

public class WaypointController : MonoBehaviour {

	public Transform player;
	public Transform TMPiece1;
	
	// Update is called once per frame
	void LateUpdate () {
		transform.LookAt (TMPiece1.position - player.position, transform.up);
	}
}
