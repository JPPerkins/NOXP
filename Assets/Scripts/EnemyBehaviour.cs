using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   	Rigidbody ourRigidbody;
    [SerializeField] float speed;
    [SerializeField] float enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
	{
		MoveToPlayer();
        //transform.LookAt(References.thePlayer.transform);
	}

	private void MoveToPlayer()
	{
        if (References.thePlayer != null)
        {
            Vector3 vectorToPlayer = References.thePlayer.transform.position - transform.position;
            ourRigidbody.velocity = vectorToPlayer.normalized * speed;
        }
	}

    private void OnCollisionEnter(Collision collision) 
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
