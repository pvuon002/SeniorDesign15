using UnityEngine;
using System.Collections;

public class PyroLauncherController : MonoBehaviour {

	public int damage;
	public static float range = 15.0f;
	public static float xzPlaneSpeed = 5.0f;
	public float explosionRadius;
	//public Vector3 direction;
	public Transform explosion;
	

	public static Vector3 targetPosToVelocityVector(Vector3 target, Vector3 player)
	{
		/*
		Vector3 toTarget = target - player;
		toTarget.y = 0.0f; // Want the vector to be parallel to the floor (i.e. xz plane)
		float distanceToTarget = toTarget.magnitude;
		toTarget.y = distanceToTarget; 	//The velocity vector is 45 degrees above the horizon.
										//For a 45 degree angle, the base and the height must
										// be the sam length.
		
		return toTarget.normalized; 
		*/
		target.y = 0.0f;
		player.y = 0.0f;
		Vector3 d = target - player;
		d.y = d.magnitude;
		return d.normalized;

	}

	public void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosionRadius);
		Instantiate (explosion, transform.position, Quaternion.identity);
		foreach(Collider col in colliders)
		{
			if(col.tag == "Enemy")
			{
				col.SendMessage("takeDamage", damage);
			}
		}
	}
}
