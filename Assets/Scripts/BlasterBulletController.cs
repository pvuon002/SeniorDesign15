using UnityEngine;
using System.Collections;

public class BlasterBulletController : MonoBehaviour {

	public float speed;
	public static int damage = 45;
	private Vector3 direction = new Vector3(1.0f, 0.0f, 0.0f);

	// Use this for initialization
	public void Start () {

	}
	
	// Update is called once per frame
	public void Update () {
		transform.position += direction * speed * Time.deltaTime;
		Destroy(gameObject, 4);
	}

	public void Initialize(Vector3 dir)
	{
		direction = dir.normalized;
	}


}
