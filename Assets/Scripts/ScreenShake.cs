using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    Vector3 normalPosition;
    [SerializeField] Vector3 joltVector;

    [SerializeField] float joltDecayVector;
    [SerializeField] float maxMoveSpeed;

    

	private void Awake()
	{
        References.screenShake = this;
	}

	// Start is called before the first frame update
	void Start()
    {
        normalPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, normalPosition + joltVector, maxMoveSpeed * Time.deltaTime);
        joltVector *= joltDecayVector;
    }

    public void Jolt(Vector3 newJolt)
	{
        joltVector = newJolt;
	}
}
