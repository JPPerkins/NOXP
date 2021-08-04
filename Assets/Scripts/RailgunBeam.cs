using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunBeam : BulletBehaviour
{
    [SerializeField] LineRenderer myBeam;
    [SerializeField] float beamThickness = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        //Raycast(Starting point, direction, define a new variable to store info about what happened when the ray hit something, distance to check, layermask that only includes things we care about hitting)
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, References.maxDistanceInALevel, References.wallsLayer);
        float distanceToWall = hitInfo.distance;
        //Physics.Raycast()
        RaycastHit[] hitArrayInfo = Physics.SphereCastAll(transform.position, beamThickness, transform.forward, distanceToWall, References.enemiesLayer);

        foreach (RaycastHit hit in hitArrayInfo)
		{
            HealthSystem theirHealthSystem = hit.collider.GetComponentInParent<HealthSystem>();
            if (theirHealthSystem != null)
            {
                theirHealthSystem.TakeDamage(bulletDamage);
            }
		}

        myBeam.SetPosition(0, transform.position);
        myBeam.SetPosition(1, hitInfo.point);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
