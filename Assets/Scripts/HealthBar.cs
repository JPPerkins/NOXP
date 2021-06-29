using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] Image filledPart;
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ShowHealthFraction(float fraction)
	{
		//Scales the filledpart to the fraction provided.
		filledPart.rectTransform.localScale = new Vector3(fraction, 1, 1);
	}
}
