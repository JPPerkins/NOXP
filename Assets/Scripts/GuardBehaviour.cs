using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : EnemyBehaviour
{
	[SerializeField] float visionRange;
	[SerializeField] float visionConeAngle;
	[SerializeField] bool isAlerted;
	[SerializeField] Light myLight;
	[SerializeField] float rotateSpeed;

	// this is specifically guard behaviour - anything all enemies do will be handled by our parent, enemybehaviour

	// protected: we have to give it the same 'access' type as we did in the parent - just use protected
	// override: we know our parent has a version of this function, and we're deciding to over-ride it - use our version INSTEAD
	// base.Start() - run our parent's version of this

	// Start is called before the first frame update
	protected override void Start()
	{
		base.Start();
		myLight = GetComponentInChildren<Light>();
		myLight.color = Color.white;
		isAlerted = false;
	}

	// Update is called once per frame
	protected override void Update()
	{
		ProcessPlayer();
	}

	private void ProcessPlayer()
	{
		if (References.thePlayer != null)
		{
			Vector3 playerPosition = References.thePlayer.transform.position;
			Vector3 vectorToPlayer = playerPosition - transform.position;
			myLight.color = Color.white;

			if (isAlerted)
			{
				ChasePlayer();
				myLight.color = Color.red;
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
				References.spawner.activated = true;
			}
		}
	}
}
