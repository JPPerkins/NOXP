using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
	Vector3 normalPosition;
    Vector3 desiredPosition;

	[SerializeField] Vector3 joltVector;
    [SerializeField] float shakeAmount;

    [SerializeField] float joltDecayVector;
    [SerializeField] float shakeDecayFactor;
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
        Vector3 shakeVector = GetRandomShakeVector();
        desiredPosition = normalPosition + joltVector + shakeVector;

        // Set our position to the jolted position
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, maxMoveSpeed * Time.deltaTime);

        // jolt vector decreases
        joltVector *= joltDecayVector;
        shakeAmount *= shakeDecayFactor;
    }

    public void Jolt(Vector3 newJolt)
	{
        joltVector = newJolt;
	}

    private Vector3 GetRandomShakeVector()
	{
        float x = Random.Range(-shakeAmount, shakeAmount);
        float y = Random.Range(-shakeAmount, shakeAmount);
        float z = Random.Range(-shakeAmount, shakeAmount);

        return new Vector3(x, y, z);
    }

    public float ShakeAmount
	{
        get { return shakeAmount; }
        set { shakeAmount = value; }
    }
}
