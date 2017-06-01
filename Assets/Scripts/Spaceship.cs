using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	public GameObject bullet; //reference to bullet prefab
	public Vector3 velocity;

	public float shipSpeed = 8f;
	public float rotSpeed = 15f;

	public Crosshair crosshair;
	public Vector3 direction;

	void Awake()
	{
		Debug.Log ("I Have Awaken");
	}

	void OnEnable()
	{
		Debug.Log ("Activating Systems");
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Let's Get Started!");
	}

	// Update is called once per frame
	void Update () {

		Orientation ();
		Movement ();
		Firing ();

		/*
		if (Input.GetKey (KeyCode.UpArrow)) {
			this.transform.Translate (Vector3.up * Time.deltaTime * shipSpeed);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			this.transform.Translate (Vector3.down * Time.deltaTime * shipSpeed);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.Translate (Vector3.left * Time.deltaTime * shipSpeed);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Translate (Vector3.right * Time.deltaTime * shipSpeed);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (bullet, this.transform.position, this.transform.rotation);
		}
		*/
	}

	void Orientation()
	{
		Vector3 direction = crosshair.worldMousePos - this.transform.position;
		direction.z = 0f;
		transform.LookAt (transform.forward + transform.position, direction);

		/*
		direction = crosshair.transform.position - this.transform.position;
		direction.Normalize ();
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		this.transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 0, angle - 90), Time.deltaTime * rotSpeed);
		*/
	}

	void Movement()
	{
		velocity.x = Input.GetAxis ("Horizontal");
		velocity.y = Input.GetAxis ("Vertical");

		this.transform.Translate (velocity * Time.deltaTime * shipSpeed, Space.World);
		//this.transform.Translate(Input.GetAxis ("Horizontal"));
	}

	void Firing()
	{
		if (Input.GetButton ("Fire1")) {
			Instantiate (bullet, this.transform.position, this.transform.rotation);
		}
	}
}