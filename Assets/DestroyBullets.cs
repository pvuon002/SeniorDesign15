using UnityEngine;
using System.Collections;

public class DestroyBullets : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "BlasterBullet" || col.tag == "Bolt")
			Destroy (col.gameObject);
		if (col.tag == "PyroBullet")
		{
			PyroLauncherController pyroController = col.gameObject.GetComponent<PyroLauncherController>();
			pyroController.Explode();
			Destroy (col.gameObject);
		}
	}
}
