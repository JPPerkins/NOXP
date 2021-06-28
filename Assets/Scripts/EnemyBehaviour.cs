using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   	Rigidbody ourRigidbody;
    [SerializeField] GameObject player;
    [SerializeField] float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
	{
		MoveToPlayer();
	}

	private void MoveToPlayer()
	{
		Vector3 vectorToPlayer = player.transform.position - transform.position;
		ourRigidbody.velocity = vectorToPlayer.normalized * speed;
	}
}
