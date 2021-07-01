using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	// never set the value of a public variable here - the inspector will override it without telling you.
	// if you need to, set it in Start() instead
	[SerializeField] float speed; // 'float' is short for floating point number, basically a normal number
	[SerializeField] WeaponBehaviour currentWeapon;
	Rigidbody ourRigidbody;

	// Start is called before the first frame update
	void Start()
	{
		ourRigidbody = GetComponent<Rigidbody>();
		References.thePlayer = gameObject;

	}

	// Update is called once per frame
	void Update()
	{
		ProcessMouseInput();
		ProcessMovement();
	}

	private void ProcessMouseInput()
	{
		Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
		Vector3 mousePosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

		transform.LookAt(mousePosition);

		if (Input.GetButton("Fire1"))
		{
			currentWeapon.Fire(mousePosition);
		}   
	}

	//WASD to move
	private void ProcessMovement()
	{
		Vector3 rawMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		ourRigidbody.velocity = rawMovementInput * speed;
	}
}