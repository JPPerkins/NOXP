using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	// never set the value of a public variable here - the inspector will override it without telling you.
	// if you need to, set it in Start() instead
	[SerializeField] float speed; // 'float' is short for floating point number, basically a normal number
	[SerializeField] List<WeaponBehaviour> weapons = new List<WeaponBehaviour>();
	[SerializeField] int selectedWeaponIndex;
	Rigidbody ourRigidbody;

	// Start is called before the first frame update
	void Start()
	{
		ourRigidbody = GetComponent<Rigidbody>();
		References.thePlayer = gameObject;
		selectedWeaponIndex = 0;
	}

	// Update is called once per frame
	void Update()
	{
		ProcessMouseInput();
		ProcessKeyboardInput();
	}

	private void ProcessMouseInput()
	{
		Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
		Vector3 mousePosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

		transform.LookAt(mousePosition);

		if (Input.GetButton("Fire1") && weapons.Count > 0)
		{
			weapons[selectedWeaponIndex].Fire(mousePosition);
		}  

		if (Input.GetButtonDown("Fire2"))
		{
			ChangeWeaponIndex();
		}
	}

	private void ChangeWeaponIndex()
	{
		selectedWeaponIndex += 1;
		if (selectedWeaponIndex >= weapons.Count)
		{
			selectedWeaponIndex = 0;
		}

		for (int i = 0; i < weapons.Count; i++)
		{
			if (i == selectedWeaponIndex)
			{
				weapons[i].gameObject.SetActive(true);
			}
			else
			{
				weapons[i].gameObject.SetActive(false);
			}
		}
	}

	//WASD to move
	private void ProcessKeyboardInput()
	{
		Vector3 rawMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		ourRigidbody.velocity = rawMovementInput * speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		WeaponBehaviour newWeapon = other.GetComponentInParent<WeaponBehaviour>();
		if (newWeapon)
		{
			weapons.Add(newWeapon);
			newWeapon.transform.position = transform.position;
			newWeapon.transform.rotation = transform.rotation;
			newWeapon.transform.SetParent(transform);
			ChangeWeaponIndex();
		}
	}
}