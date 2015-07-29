using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "BlasterBullet" || col.tag == "PyroBullet") {
			EnemyHealth enemy = GetComponent<EnemyHealth> ();
			enemy.Hit (col.gameObject);

			Destroy (col.gameObject);
		}
	}
	*/
}
