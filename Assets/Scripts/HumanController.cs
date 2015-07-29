/*
using UnityEngine;
using System.Collections;

public class HumanController : MonoBehaviour {
	GameObject Enemy_tank;
	Transform target;
	
	public float speed;
	public float bullspeed;
	public int damage;
	
	public Rigidbody shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	
	float attackRange = 1000.0f;
	
	bool CanSeeTarget ()
	{
		if (Vector3.Distance (transform.position, target.position) > attackRange)
			return false;
		RaycastHit hit;
		if (Physics.Linecast (transform.position, target.position, out hit))
			return hit.transform == target;
		return false;
	}
	
	void Start ()
	{
		if (target == null && GameObject.FindWithTag ("Player")) {
			target = GameObject.FindWithTag ("Player").transform;
			Debug.Log ("found Player");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Enemy_tank = GameObject.FindWithTag ("Enemy");
		if (target == null)
			return;
		if (!CanSeeTarget ())
			return;

		// Rotate towards target
		Debug.Log ("Start moving");
		Vector3 targetPoint = target.position;
		Quaternion targetRotation = Quaternion.LookRotation 
			(targetPoint - Enemy_tank.transform.position);
		Enemy_tank.transform.rotation = Quaternion.Slerp
			(Enemy_tank.transform.rotation, targetRotation, Time.deltaTime * 2.0f);
		// If we are almost rotated towards target
		Vector3 forward = Enemy_tank.transform.TransformDirection (Vector3.forward);
		Vector3 targetDir = targetPoint - Enemy_tank.transform.position;
		if (Vector3.Angle (forward, targetDir) < 10.0f || Vector3.Angle (forward, targetDir) > -10.0f) {
			if (Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				Rigidbody clone;
				clone = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as Rigidbody;
				//clone.velocity = Enemy_tank.transform.TransformDirection (transform.forward * bullspeed);
				clone.velocity = transform.forward * bullspeed;
			}
		}
		if (Vector3.Distance (transform.position, target.position) < attackRange) {
			Vector3 targetPoint1 = target.position;
			Quaternion targetRotation1 = Quaternion.LookRotation 
				(targetPoint1 - transform.position);
			transform.rotation = Quaternion.Slerp
				(transform.rotation, targetRotation1, Time.deltaTime * 1.0f);
			transform.Translate (Vector3.forward * 5.0f * Time.deltaTime);
		}
		Debug.Log ("End moving");
	}
}
*/

using UnityEngine;
using System.Collections;

public class HumanController : MonoBehaviour {
	GameObject Enemy_tank;
	Transform target;
	
	public float speed;
	public float bullspeed;
	public int damage;
	
	public Rigidbody shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	private Animator anim;
	
	float attackRange = 500.0f;
	
	bool CanSeeTarget ()
	{
		if (Vector3.Distance (transform.position, target.position) > attackRange)
			return false;
		RaycastHit hit;
	
		if (Physics.Linecast (transform.position, target.position, out hit))
			return hit.transform == target;
		return false;
	}
	
	void Start ()
	{
		if (target == null && GameObject.FindWithTag ("Player"))	
			target = GameObject.FindGameObjectWithTag ("Player").transform;	
	}
	
	// Update is called once per frame
	void Update () {
		Enemy_tank = GameObject.FindWithTag ("Enemy");
		if (target == null)
			return;
		if (!CanSeeTarget ())
			return;
		// Rotate towards target
		Vector3 targetPoint = target.position;
		Quaternion targetRotation = Quaternion.LookRotation 
			(targetPoint - Enemy_tank.transform.position);
		Enemy_tank.transform.rotation = Quaternion.Slerp
			(Enemy_tank.transform.rotation, targetRotation, Time.deltaTime * 2.0f);
		// If we are almost rotated towards target
		Vector3 forward = Enemy_tank.transform.TransformDirection (Vector3.forward);
		Vector3 targetDir = targetPoint - Enemy_tank.transform.position;
		if (Vector3.Angle (forward, targetDir) < 10.0f || Vector3.Angle (forward, targetDir) > -10.0f) {
			if (Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				Rigidbody clone;
				clone = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as Rigidbody;
				//clone.velocity = Enemy_tank.transform.TransformDirection (transform.forward * bullspeed);
				clone.velocity = transform.forward * bullspeed;
			}
		}
		if (Vector3.Distance (transform.position, target.position) < attackRange) {
			Vector3 targetPoint1 = target.position;
			Quaternion targetRotation1 = Quaternion.LookRotation 
				(targetPoint1 - transform.position);
			transform.rotation = Quaternion.Slerp
				(transform.rotation, targetRotation1, Time.deltaTime * 3.0f);
			transform.Translate (Vector3.forward * 7.0f * Time.deltaTime);
		}
	}
}