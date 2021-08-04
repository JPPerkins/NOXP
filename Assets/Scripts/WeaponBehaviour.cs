using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] float accuracy;
    [SerializeField] float secondsBetweenShots;
	[SerializeField] float numberOfProjectiles;
    float secondsSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShot = secondsBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        secondsSinceLastShot += Time.deltaTime;
    }

    public void Fire(Vector3 targetPosition)
	{
		if (secondsSinceLastShot > secondsBetweenShots)
		{
			References.spawner.activated = true;
			//Ready to fire
			for (int i = 0; i < numberOfProjectiles; i++)
			{
				FireBullet(targetPosition);
			}
			secondsSinceLastShot = 0;
		}   
	}

	private void FireBullet(Vector3 targetPosition)
	{
		GameObject newBullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
		float inaccuracy = Vector3.Distance(transform.position, targetPosition) / accuracy;
		//Offset that target position by a random amount, according to our inaccuracy
		Vector3 inaccuratePosition = targetPosition;
		inaccuratePosition.x += Random.Range(-inaccuracy, inaccuracy);
		inaccuratePosition.z += Random.Range(-inaccuracy, inaccuracy);
		newBullet.transform.LookAt(inaccuratePosition);
	}
}
