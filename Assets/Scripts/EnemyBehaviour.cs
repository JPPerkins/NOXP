using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	protected Rigidbody ourRigidbody;
	[SerializeField] protected float speed;
	[SerializeField] protected  float enemyDamage;

	// this is our parent class for all enemies - code here should be stuff they all use
	// protected: this function can be used by our children and us, but no one else.
		// we probably don't want anything to be 'private'
	// virtual: this can be over-ridden by our children - but if they don't override it, they just use our version.

	protected virtual void Start()
    {
        ourRigidbody = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	protected virtual void Update()
	{
		ChasePlayer();
	}

	protected void ChasePlayer()
	{
        if (References.thePlayer != null)
        {
			Vector3 playerPosition = References.thePlayer.transform.position;
			Vector3 vectorToPlayer = playerPosition - transform.position;
			ourRigidbody.velocity = vectorToPlayer.normalized * speed;
			Vector3 playerPositionAtOurHeight = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
			transform.LookAt(playerPositionAtOurHeight);
		}
	}

	protected void OnCollisionEnter(Collision collision) 
	{
		GameObject collisionObject = collision.gameObject;
		if (collisionObject.GetComponent<PlayerBehaviour>())
		{
			HealthSystem objectHealth = collisionObject.GetComponent<HealthSystem>();
			if (objectHealth != null)
			{
				objectHealth.TakeDamage(enemyDamage);
			}
		}
	}
}
