using UnityEngine;
using System.Collections;


public class RoboShooting : MonoBehaviour {

	public float waitBullets = 1.0f; //time between each shot
	public float range = 10f;  // distance of beam

	float timer;  //timer to determine when to fire
	Ray beam;  // ray from robo eye and forward
	RaycastHit beamHit;  // to get info on location of hit
	LineRenderer beamLine;  // ref to linerenderer
	Light beamLight; // ref to light
	float effectsTime = 0.2f; //length of time effects are displayed
	Transform target;
	public Color c1= Color.white;
	public Color c2= Color.red;

	void Start () {
		target = GameObject.FindWithTag ("Player").transform; 
	}

	void Awake()
	{
		beamLine = GetComponent <LineRenderer> ();
		beamLight = GetComponent <Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		beamLine.material = new Material(Shader.Find("Particles/Additive"));
		beamLine.SetColors(c1, c2);
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		
		// If the Fire1 button is being press and it's time to fire...
		//if(Input.GetButton ("Fire1") && timer >= waitBullets)

		if(target!=null && Mathf.Abs (transform.position.z - target.position.z) <= 10)
		{
			// ... shoot the gun.
			Shoot ();
		}
		
		// If the timer has exceeded the proportion of waitBullets that the effects should be displayed for...
		if(timer >= waitBullets * effectsTime)
		{
			// ... disable the effects.
			DisableEffects ();
		} 
	}

	void Shoot()
	{

		// Reset the timer.
		timer = 0f;

		// Enable the light.
		beamLight.enabled = true;

		// Enable the line renderer and set it's first position to be the end of the eye.
		beamLine.enabled = true;
		beamLine.SetPosition (0, transform.position);

		// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
		beam.origin = transform.position;
		beam.direction = transform.forward;

		// Perform the raycast against gameobjects 
		if(Physics.Raycast (beam, out beamHit, range))
		{
			// Set the second position of the line renderer to the point the raycast hit.
			Debug.Log("Ray hits Player ");
			beamLine.SetPosition (1, beamHit.point);
			target.gameObject.GetComponent<PlayerController>().PlayerStun();
		}
		// If the raycast didn't hit anything on the shootable layer...
		else
		{
			// ... set the second position of the line renderer to the fullest extent of the gun's range.
			beamLine.SetPosition (1, beam.origin + beam.direction * range);
		}

	}

	public void DisableEffects ()
	{
		// Disable the line renderer and the light.
		beamLine.enabled = false;
		beamLight.enabled = false;
	}
}
