using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	float timeUntilDeath = 5f;
	[SerializeField] float bulletSpeed;
	// Update is called once per frame
	void Start()
	{
		Rigidbody ourRigidbody = GetComponent<Rigidbody>();
		ourRigidbody.velocity = transform.forward * bulletSpeed;
	}

	private void OnCollisionEnter(Collision collision) 
	{
		GameObject collisionObject = collision.gameObject;
		if (collisionObject.GetComponent<EnemyBehaviour>())
		{
			Destroy(collisionObject);
			Destroy(gameObject);
		}
	}
}
