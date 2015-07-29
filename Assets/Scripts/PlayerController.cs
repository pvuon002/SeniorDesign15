using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//public static int health = 200;
	public float speed;
	public Transform weapon;
	public GameObject blasterBulletPrefab;
	public GameObject pyroBulletPrefab;
	public GameObject shotgunPelletPrefab;
	public Text weaponText;
	public Image weaponImage;
	public Sprite blasterSprite;
	public Sprite pyroSprite;
	public Sprite shotgunSprite;

	private Rigidbody rb;
	private Vector3 bulletDirection;
	private const int NUM_WEAPONS = 2;
	private enum WeaponType {BLASTER_CANNON,
							PYRO_LAUNCHER,
							SHOTGUN};
	private WeaponType equippedWeapon = WeaponType.BLASTER_CANNON;
	private int blasterInterval = 10;
	private int blasterTimer = 0;

	private int pyroInterval = 25;
	private int pyroTimer = 0;

	private float shotgunRadius = 20.0f;

	private CharacterController controller;
	private Vector3 moveDirection;

	private bool gunsEnabled = false;

	private bool prologueDone = false;

	private bool isPaused = false;

	// STUN VARIABLES
	public bool Hstun;
	public bool stun;
	public float stunTime = 5.0f;

	private Animator anim;
	private int isMovingHash = Animator.StringToHash("isMoving");
	private int normalizedDegreesHash = Animator.StringToHash("normalizedDegrees");

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		weaponText.text = "Weapon: " + getWeapon();
		controller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection.Normalize ();
		moveDirection *= speed;
		controller.Move (moveDirection * Time.deltaTime);



		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			bulletDirection = hit.point - transform.position;
			bulletDirection.y = 0.0f;
			rb.rotation = Quaternion.LookRotation(bulletDirection);

		}

		// Set animation parameters

		Vector3 mouseDir = hit.point - transform.position;
		if (moveDirection.magnitude > 0)
		{
			anim.SetBool (isMovingHash, true);
			float normalizedDegrees = Vector3.Angle(
								new Vector3(moveDirection.x, 0, moveDirection.z),
								new Vector3(mouseDir.x, 0, mouseDir.z));
			normalizedDegrees /= 180;
			anim.SetFloat (normalizedDegreesHash, normalizedDegrees);
        }
        else
        	anim.SetBool (isMovingHash, false);

		if (gunsEnabled)
		{
			weaponImage.enabled = true;
			weaponText.enabled = true;
			DisplayWeapon ();
			// Space bar to cycle through weapons
			if (Input.GetKeyDown (KeyCode.Space)) {
					ChangeWeapon ();
					DisplayWeapon();
			}


			// Left click to shoot
			if (equippedWeapon == WeaponType.BLASTER_CANNON && Input.GetMouseButton (0)) {
					if (blasterTimer >= blasterInterval) {
							blasterTimer = 0;
							ShootWeapon (hit.point);
					} else
							blasterTimer++;
			} else {
					blasterTimer = blasterInterval;
			}

			if (equippedWeapon == WeaponType.PYRO_LAUNCHER && Input.GetMouseButton (0)) {
				if (pyroTimer >= pyroInterval) {
					pyroTimer = 0;

					GameObject pyroBullet = Instantiate (pyroBulletPrefab, weapon.position + weapon.forward * 4.5f, weapon.rotation) as GameObject;
					Rigidbody pyroBulletRigidbody = pyroBullet.GetComponent<Rigidbody> ();
					Vector3 velocity = PyroLauncherController.targetPosToVelocityVector (hit.point, transform.position);
					velocity.x *= 30.0f;
					velocity.z *= 30.0f;
					velocity.y *= 10.0f;
					pyroBulletRigidbody.velocity = velocity;

				} else
					pyroTimer++;
			} else {
				pyroTimer = pyroInterval;
			}

		}

		if (equippedWeapon == WeaponType.SHOTGUN && Input.GetMouseButtonDown (0)) {

			Collider[] enemiesInRange = Physics.OverlapSphere(weapon.transform.position, shotgunRadius);


		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			TogglePause();
		}
	}

	private void ChangeWeapon()
	{
		equippedWeapon = (WeaponType)(((int)equippedWeapon + 1) % NUM_WEAPONS);

	}

	private void DisplayWeapon()
	{
		weaponText.text = getWeapon ();
		if (equippedWeapon == WeaponType.BLASTER_CANNON)
			weaponImage.sprite = blasterSprite; 
		else if(equippedWeapon == WeaponType.PYRO_LAUNCHER)
			weaponImage.sprite = pyroSprite;
		else if(equippedWeapon == WeaponType.SHOTGUN)
			weaponImage.sprite = shotgunSprite;
	}

	private void ShootWeapon(Vector3 mouseHit)
	{
		switch(equippedWeapon)
		{
		case WeaponType.BLASTER_CANNON:
			GameObject blasterBullet = Instantiate (blasterBulletPrefab, weapon.position, Quaternion.identity)as GameObject;
			BlasterBulletController blasterBulletController = blasterBullet.GetComponent<BlasterBulletController>();
			blasterBulletController.Initialize(bulletDirection);
			break;

		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "TMpiece") {
			Destroy (col.gameObject);
		}
	}

	public string getWeapon()
	{
		if (equippedWeapon == WeaponType.BLASTER_CANNON)
				return "Blaster Cannon";
		else if (equippedWeapon == WeaponType.PYRO_LAUNCHER)
				return "Pyro Launcher";
		else if (equippedWeapon == WeaponType.SHOTGUN)
				return "Shotgun";
		else
				return null;

	}

	public bool isEquipped(string weaponName)
	{
		return getWeapon () == weaponName;
	}

	public int getPyroTimer()
	{
		return pyroTimer;
	}

	public void EnableGuns()
	{
		gunsEnabled = true;
	}

	// STUN FUNCTIONS
	public void PlayerStun() {
		// If player is already stunned, quit; 
		// this is to keep from being stunned 
		// again while already stunned
		if (stun) {
			Debug.Log("Player Stunned");
			return;
		}
	
		StartCoroutine(WaitStun());
	}

	
	private IEnumerator WaitStun() {
		StopCoroutine ("WaitStun");
		Debug.Log ("Stuning");
		stun = true;
		float tmpspeed = speed;
		speed = 10;
		yield return new WaitForSeconds (stunTime);
		Debug.Log ("Stun over");
		stun = false;
		speed = tmpspeed;
	}

	bool isWithinBlastCone()
	{
		return true;
	}

	void TogglePause()
	{
		if (isPaused) { //unpause the game
			isPaused = false;
			Time.timeScale = 1;
		} else { // pause the game
			isPaused = true;
			Time.timeScale = 0;
		}
	}
}

