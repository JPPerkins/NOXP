using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	// never set the value of a public variable here - the inspector will override it without telling you.
	// if you need to, set it in Start() instead

	[SerializeField] float speed; // 'float' is short for floating point number, basically a normal number
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] float secondsBetweenShots;
	[SerializeField] float shotsPerSecond;
	Rigidbody ourRigidbody;
	float secondsSinceLastShot;


	// Start is called before the first frame update
	void Start()
	{
		ourRigidbody = GetComponent<Rigidbody>();
		References.thePlayer = gameObject;
		secondsSinceLastShot = secondsBetweenShots;
		secondsBetweenShots = 1 / shotsPerSecond;
	}

	// Update is called once per frame
	void Update()
	{
		secondsBetweenShots = 1 / shotsPerSecond;
		GetMousePosition();
		ProcessMovement();
		ProcessMouseInput();
	}

	private void GetMousePosition()
	{
		Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
		Vector3 mousePosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

		transform.LookAt(mousePosition);
	}

	//WASD to move
	private void ProcessMovement()
	{
		Vector3 rawMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		ourRigidbody.velocity = rawMovementInput * speed;
	}

	private void ProcessMouseInput()
	{
		if (Input.GetButton("Fire1") && secondsSinceLastShot > secondsBetweenShots)
		{
			Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
			secondsSinceLastShot = 0;
		}   
		secondsSinceLastShot += Time.deltaTime;
	}
}