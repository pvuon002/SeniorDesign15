using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSliderController : MonoBehaviour {

	public Health playerHealth;
	public Image sliderFill;

	private Slider healthSlider;
	private int oldHealth;

	// Use this for initialization
	void Start () {
		healthSlider = GetComponent<Slider> ();
		oldHealth = playerHealth.health;
		healthSlider.value = (float)playerHealth.health / playerHealth.maxHealth;
		healthSlider.interactable = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (playerHealth.health >= 0.0f && oldHealth != playerHealth.health) {
			if ((float)playerHealth.health / playerHealth.maxHealth <= 0.4f)
				sliderFill.color = Color.red;
			else if((float)playerHealth.health / playerHealth.maxHealth > 0.4f)
				sliderFill.color = Color.green;
			healthSlider.value = (float)playerHealth.health / playerHealth.maxHealth;
			oldHealth = playerHealth.health;
		}
	}
}
