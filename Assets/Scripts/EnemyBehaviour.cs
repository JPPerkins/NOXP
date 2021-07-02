using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   	Rigidbody ourRigidbody;
    [SerializeField] float speed;
    [SerializeField] float enemyDamage;
	[SerializeField] float visionRange;
	[SerializeField] float visionConeAngle;
	[SerializeField] bool isAlerted;
	[SerializeField] Light myLight;
	[SerializeField] float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody>();
		myLight = GetComponentInChildren<Light>();
		isAlerted = false;
		myLight.color = Color.white;
    }

    // Update is called once per frame
    void Update()
	{
		ProcessPlayer();
	}

	private void ProcessPlayer()
	{
        if (References.thePlayer != null)
        {
			Vector3 playerPosition = References.thePlayer.transform.position;
            Vector3 vectorToPlayer = playerPosition - transform.position;
				
			if (isAlerted)
			{
				FollowPlayer(playerPosition, vectorToPlayer);
			}
			else
			{
				LookForPlayer(playerPosition, vectorToPlayer);
			}
		}
	}

	private void LookForPlayer(Vector3 playerPosition, Vector3 vectorToPlayer)
	{
		Vector3 rotatePosition = transform.right * Time.deltaTime * rotateSpeed;
		transform.LookAt(transform.position + transform.forward + rotatePosition);
		ourRigidbody.velocity = transform.forward * speed;

		if (Vector3.Distance(transform.position, playerPosition) <= visionRange)
		{
			if (Vector3.Angle(transform.forward, vectorToPlayer) <= visionConeAngle)
			{

				isAlerted = true;
			}
		}
	}

	private void FollowPlayer(Vector3 playerPosition, Vector3 vectorToPlayer)
	{
		ourRigidbody.velocity = vectorToPlayer.normalized * speed;
		Vector3 playerPositionAtOurHeight = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
		transform.LookAt(playerPositionAtOurHeight);
		myLight.color = Color.red;
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
