using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health;
	public int maxHealth;
	public float hpDropChance;
	public GameObject healthPickup;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "BlasterBullet") {
			takeDamage (BlasterBulletController.damage);

			Destroy (col.gameObject);
		} else if (col.tag == "PyroBullet") {
			PyroLauncherController pyroExplosion = col.GetComponent<PyroLauncherController> ();
			pyroExplosion.Explode ();

			Destroy (col.gameObject);
		}
		else if(this.gameObject.tag == "Player" && col.tag == "Life")
		{
			heal();
			Destroy (col.gameObject);
		}
	}

	public void takeDamage(int dmg)
	{
		health -= dmg;
		if (health <= 0)
			Death ();
	}

	// Called when health <= 0
	private void Death()
	{
		Destroy (gameObject);
		if (this.gameObject.tag == "Player")
						Application.LoadLevel ("GameOver");
		else
		{
			if(Random.Range(0, 100) < hpDropChance)
				Instantiate(healthPickup, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

	public void heal()
	{
				if (health >= maxHealth)
						return;
				else {
						health += 10;
				}
	}
}
