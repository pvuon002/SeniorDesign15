using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour 
{
	public float speed = 3.0f;
	public float ZoomSpeed = 3.0f;








	void LateUpdate () 
	{

		float horizontal = Input.GetAxis("Horizontal");
		float vertical 	 = Input.GetAxis("Vertical");
		float zoom = Input.GetAxis("Fire1");
		Vector3 fr = transform.forward;
		fr.y = 0;
		transform.position += Vector3.left * vertical * speed * Time.deltaTime;
		transform.position += Vector3.forward * horizontal * speed * Time.deltaTime;
		transform.position += Vector3.up * zoom * ZoomSpeed *Time.deltaTime;
	}
}
