using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarController : MonoBehaviour {

	Image healthBarImage;
	public Health playerHealth;
	public Sprite lowHealthSrite;
	public Text weaponText;
	public PlayerController playerController;

	private Text healthBarText;
	private int oldHealth;

	void Start()
	{
		healthBarImage = GetComponent<Image> ();
		healthBarText = GetComponentInChildren<Text> ();
		oldHealth = playerHealth.health;
		healthBarImage.fillAmount = (float)playerHealth.health / playerHealth.maxHealth;
		healthBarText.text = playerHealth.health.ToString ();
		weaponText.text = playerController.getWeapon();
	}

	// Update is called once per frame
	void LateUpdate () {
		if (playerHealth.health >= 0.0f && oldHealth != playerHealth.health) {
			if ((float)playerHealth.health / playerHealth.maxHealth <= 0.4f)
					healthBarImage.sprite = lowHealthSrite;
			healthBarImage.fillAmount = (float)playerHealth.health / playerHealth.maxHealth;
			healthBarText.text = playerHealth.health.ToString ();
			weaponText.text = playerController.getWeapon();
			oldHealth = playerHealth.health;
				}
	}
}
