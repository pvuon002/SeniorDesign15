using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour {

	public Health playerHealth;
	public HumanController humanController;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Bolt") {
			playerHealth.takeDamage(humanController.damage);
			Destroy (col.gameObject);
		}
	}
}
