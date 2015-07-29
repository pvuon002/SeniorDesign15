/*
using UnityEngine;
using System.Collections;

public class MoveRobo : MonoBehaviour {

	public float speed=5.0f;
	public bool facing = false;
	//private float angle = 0.0f;
	Transform target;
	Transform wtarget;
	private Vector3 targetPoint;
	private Quaternion targetRotation;

	public State state;
	public enum State{
		Idle,
		Way1,
		Way2,
		Way3,
		Way4,
		Way5,
		Way6
	}
	
	
	void Start () {
		target = GameObject.FindWithTag ("Player").transform; 
		state = State.Idle;

	}
	
	void Update () {
			// robot will rotate to Player's direction
			
			

			// when the target reaches a distance of 5 or less (closer), 
			// approach the target

			switch (state) 
			{
			case State.Idle:
				state= State.Way1;
				break;
			case State.Way1:
				waypoint1();
				break;
			case State.Way2:
				waypoint2();
				break;
			case State.Way3:
				waypoint3();
				break;
			case State.Way4:
				waypoint4();
				break;
			case State.Way5:
				waypoint5();
				break;
			case State.Way6:
				waypoint6();
				break;

			}	
		
		if (Mathf.Abs (transform.position.z - target.position.z) <= 6) {
						transform.LookAt (target);
						
				}

	void waypoint1()
	{
		facing = false;
		wtarget = GameObject.FindWithTag("WP1").transform;
		float distance = Vector3.Distance (transform.position, wtarget.transform.position);

		Debug.DrawLine (wtarget.transform.position, transform.position , Color.magenta);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(wtarget.position - transform.position), speed*Time.deltaTime);
		
		//move towards the player
		transform.position += transform.forward * 3f * Time.deltaTime;
		if (distance < 2f)
			state = State.Way2;
	}

	void waypoint2()
	{
		facing = false;
		wtarget = GameObject.FindWithTag ("WP2").transform;
		float distance = Vector3.Distance (transform.position, wtarget.transform.position);

		Debug.DrawLine (wtarget.transform.position, transform.position, Color.magenta);
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (wtarget.position - transform.position), speed * Time.deltaTime);

		//move towards the player
		transform.position += transform.forward * 3f * Time.deltaTime;
		if (distance < 2f)
				state = State.Way1;
	}

	void waypoint3()
	{
		facing = false;
		wtarget = GameObject.FindWithTag ("WP2").transform;
		float distance = Vector3.Distance (transform.position, wtarget.transform.position);
		
		Debug.DrawLine (wtarget.transform.position, transform.position, Color.magenta);
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (wtarget.position - transform.position), speed * Time.deltaTime);
		
		//move towards the player
		transform.position += transform.forward * 3f * Time.deltaTime;
		if (distance < 2f)
			state = State.Way4;
	}

	void waypoint4()
	{
		facing = false;
		wtarget = GameObject.FindWithTag ("WP2").transform;
		float distance = Vector3.Distance (transform.position, wtarget.transform.position);
		
		Debug.DrawLine (wtarget.transform.position, transform.position, Color.magenta);
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (wtarget.position - transform.position), speed * Time.deltaTime);
		
		//move towards the player
		transform.position += transform.forward * 3f * Time.deltaTime;
		if (distance < 2f)
			state = State.Way3;
	}

	void waypoint5()
	{
		facing = false;
		wtarget = GameObject.FindWithTag ("WP2").transform;
		float distance = Vector3.Distance (transform.position, wtarget.transform.position);
		
		Debug.DrawLine (wtarget.transform.position, transform.position, Color.magenta);
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (wtarget.position - transform.position), speed * Time.deltaTime);
		
		//move towards the player
		transform.position += transform.forward * 3f * Time.deltaTime;
		if (distance < 2f)
			state = State.Way6;
	}

	void waypoint6()
	{
		facing = false;
		wtarget = GameObject.FindWithTag ("WP2").transform;
		float distance = Vector3.Distance (transform.position, wtarget.transform.position);
		
		Debug.DrawLine (wtarget.transform.position, transform.position, Color.magenta);
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (wtarget.position - transform.position), speed * Time.deltaTime);
		
		//move towards the player
		transform.position += transform.forward * 3f * Time.deltaTime;
		if (distance < 2f)
			state = State.Way5;
	}

	bool spotted() {
		RaycastHit hit;
		
		if (Physics.Linecast (transform.position, target.position, out hit)) {
			if (hit.transform == target)
				return true;
		}
		return false;
	}


}
 */
using UnityEngine;
using System.Collections;

public class MoveRobo : MonoBehaviour {
	
	public float speed=5.0f;
	public bool facing = false;
	//private float angle = 0.0f;
	Transform target;
	Transform wtarget;
	private Vector3 targetPoint;
	private Quaternion targetRotation;
	
	public State state;
	public enum State{
		Idle,
		Way1,
		Way2,
		Way3,
		Way4,
		Way5,
		Way6
	}
	
	
	void Start () {
		target = GameObject.FindWithTag ("Player").transform; 
	}
	
	void Update () {
		
				// when the target reaches a distance of 5 or less (closer), 
				// approach the target
		
				switch (state) {
				case State.Idle:
						state = State.Way1;
						break;
				case State.Way1:
						wtarget = GameObject.FindWithTag ("WP1").transform;
						waypoint ();
			//state = State.Way2;
						break;
				case State.Way2:
						wtarget = GameObject.FindWithTag ("WP2").transform;
						waypoint ();
			//state = State.Way1;
						break;
				case State.Way3:
						wtarget = GameObject.FindWithTag ("WP3").transform;
						waypoint ();
			//state = State.Way4;
						break;
				case State.Way4:
						wtarget = GameObject.FindWithTag ("WP4").transform;
						waypoint ();
			//state = State.Way3;
						break;
				case State.Way5:
						wtarget = GameObject.FindWithTag ("WP6").transform;
						waypoint ();
			//state = State.Way6;
						break;
				case State.Way6:
						wtarget = GameObject.FindWithTag ("WP7").transform;
						waypoint ();
			//state = State.Way5;
						break;
			
				}	
		
				if (Mathf.Abs (transform.position.z - target.position.z) <= 10) {
						transform.LookAt (target);
			
				}
		}
		
		
		void waypoint()
		{
			float distance = Vector3.Distance (transform.position, wtarget.transform.position);
			
			Debug.DrawLine (wtarget.transform.position, transform.position , Color.magenta);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(wtarget.position - transform.position), speed*Time.deltaTime);
			
			//move towards the player
			transform.position += transform.forward * 3f * Time.deltaTime;
			if (distance < 2f) {
				if(state== State.Way1)
					state = State.Way2;
				else if (state== State.Way2)
					state = State.Way1;
				else if (state== State.Way3)
					state = State.Way4;
				else if (state== State.Way4)
					state = State.Way3;
				else if (state== State.Way5)
					state = State.Way6;
				else if (state== State.Way6)
					state = State.Way5;
			}
			
		}
		
		
		bool spotted() {
			RaycastHit hit;
			
			if (Physics.Linecast (transform.position, target.position, out hit)) {
				if (hit.transform == target)
					return true;
			}
			return false;
		}
		
		
}
