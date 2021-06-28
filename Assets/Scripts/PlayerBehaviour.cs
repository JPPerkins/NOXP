using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	// never set the value of a public variable here - the inspector will override it without telling you.
	// if you need to, set it in Start() instead

	[SerializeField] float speed; // 'float' is short for floating point number, basically a normal number
	[SerializeField] GameObject bulletPrefab;
	Rigidbody ourRigidbody;


	// Start is called before the first frame update
	void Start()
	{
		ourRigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		ProcessMovement();
		ProcessMouse();
	}

	//WASD to move
	void ProcessMovement()
	{
		//Find the new position we'll move to

		Vector3 rawMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		ourRigidbody.velocity = rawMovementInput * speed;
		
		Vector3 lookAtPosition = transform.position + rawMovementInput;
		transform.LookAt(lookAtPosition); //Face the new position
	}

	void ProcessMouse()
	{
		if (Input.GetButton("Fire1"))
		{
			Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
		}   
	}
}