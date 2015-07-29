using UnityEngine;
using System.Collections;

public class PyroLauncherCleanup : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "PyroBullet") {
			PyroLauncherController pyroExplosion = col.GetComponent<PyroLauncherController>();
			pyroExplosion.Explode();
			Destroy (col.gameObject);		
		}
	}
}
