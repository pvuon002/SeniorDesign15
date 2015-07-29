using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {
	public Transform target;
	public Transform target1;
	GameObject Enemy;
	public float rotationSpeed;
	public float moveSpeed;
	Transform myTransform;
	//public int randomNumber;
	
	public float bullspeed;
	public Rigidbody shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	
	float attackRange = 25.0f;
	public State state;
	public enum State {
		Idle,
		Way1,
		Way2,
		Way3,
		Way4,
		Stop
	}
	
	void Awake (){
		myTransform = transform;
	}
	
	// Use this for initialization
	void Start () {
		if (target == null && GameObject.FindWithTag ("Player"))	
			target = GameObject.FindWithTag ("Player").transform;
		state = State.Idle;
	}
	
	public bool CanSeeTarget ()
	{
		if (Vector3.Distance (transform.position, target.position) > attackRange)
			return false;
		RaycastHit hit;
		if (Physics.Linecast (transform.position, target.position, out hit))
			return hit.transform == target;
		return false;
	}
	
	// Update is called once per frame
	void Update () {
		SwitchState();
		switch (state) {
		case State.Stop:
			StopT ();
			break;
		case State.Idle:
			Idle();
			break;
		case State.Way1:
			WayP1 ();
			break;
		case State.Way2:
			WayP2 ();
			break;
		case State.Way3:
			WayP3 ();
			break;
		case State.Way4:
			WayP4 ();
			break;
			
		}
	}
	
	void SwitchState()
	{
		if (target != null && CanSeeTarget ()) {
			state = State.Stop;
		} 
	}
	
	void StopT()
	{
		Debug.Log ("Stop");
		//state = State.Stop;
		Enemy = GameObject.FindWithTag ("Enemy");
		
		// Rotate towards target
		Vector3 targetPoint = target.position;
		Vector3 temp1 = targetPoint - Enemy.transform.position;
		temp1.y = 0.0f;
		Quaternion targetRotation = Quaternion.LookRotation (temp1);
		//(targetPoint - Enemy.transform.position);
		
		
		Enemy.transform.rotation = Quaternion.Slerp
			(Enemy.transform.rotation, targetRotation, Time.deltaTime * 2.0f);
		Vector3 forward = Enemy.transform.TransformDirection (Vector3.forward);
		Vector3 targetDir = targetPoint - Enemy.transform.position;
		targetDir.y = 0.0f;
		if (Vector3.Angle (forward, targetDir) < 10.0f || Vector3.Angle (forward, targetDir) > -10.0f) {
			if (Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Rigidbody clone;
				clone = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as Rigidbody;
				clone.velocity = transform.forward * bullspeed;
			}
		}
		//if (Vector3.Distance (transform.position, target.position) < attackRange) {
			Vector3 targetPoint1 = target.position;
			Vector3 temp2 = targetPoint1 - transform.position;
			temp2.y = 0.0f;
			Quaternion targetRotation1 = Quaternion.LookRotation 
				(temp2);
			transform.rotation = Quaternion.Slerp
				(transform.rotation, targetRotation1, Time.deltaTime * 1.0f);
			transform.Translate (Vector3.forward * 0.05f);
		//}
	}
	
	void Idle(){
		if (state != State.Stop) {
			state = State.Way1;	
		}
		
	}
	void WayP1(){
		target1 = GameObject.FindWithTag("w1").transform;
		float distance = Vector3.Distance (myTransform.position, target1.transform.position);
		Debug.DrawLine (target1.transform.position, myTransform.position , Color.green);
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,    Quaternion.LookRotation(target1.position - myTransform.position), rotationSpeed*Time.deltaTime);
		
		//move towards the player
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		if (distance < 2f)
			state = State.Way2;
	}
	void WayP2()
	{
		target1 = GameObject.FindWithTag("w2").transform;
		float distance = Vector3.Distance (myTransform.position, target1.transform.position);
		
		Debug.DrawLine (target1.transform.position, myTransform.position , Color.red);
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,    Quaternion.LookRotation(target1.position - myTransform.position), rotationSpeed * Time.deltaTime);
		
		//move towards the player
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		if (distance < 2f)
			state = State.Way3;
	}
	void WayP3()
	{
		target1 = GameObject.FindWithTag("w3").transform;
		float distance = Vector3.Distance (myTransform.position, target1.transform.position);
		
		Debug.DrawLine (target1.transform.position, myTransform.position , Color.red);
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,    Quaternion.LookRotation(target1.position - myTransform.position), rotationSpeed * Time.deltaTime);
		
		//move towards the player
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		if (distance < 2f)
			state = State.Way4;
	}
	void WayP4()
	{
		target1 = GameObject.FindWithTag("w4").transform;
		float distance = Vector3.Distance (myTransform.position, target1.transform.position);
		
		Debug.DrawLine (target1.transform.position, myTransform.position , Color.red);
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation,    Quaternion.LookRotation(target1.position - myTransform.position), rotationSpeed*Time.deltaTime);
		
		//move towards the player
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		if (distance < 2f)
			state = State.Way1;
	}
	
}