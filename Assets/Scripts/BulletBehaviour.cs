using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	[SerializeField] float secondsUntilDestroyed;
	[SerializeField] float bulletSpeed;
	// Update is called once per frame
	void Start()
	{
		Rigidbody ourRigidbody = GetComponent<Rigidbody>();
		ourRigidbody.velocity = transform.forward * bulletSpeed;
	}

	void Update() 
	{
		secondsUntilDestroyed -= Time.deltaTime;

		if (secondsUntilDestroyed <= 1)
		{
			transform.localScale *= secondsUntilDestroyed;
		}

		if (secondsUntilDestroyed <= 0)
		{
			Destroy(gameObject);
		}
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
