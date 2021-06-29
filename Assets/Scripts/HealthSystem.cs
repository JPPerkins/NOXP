using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour
{
	// Start is called before the first frame update

	[FormerlySerializedAs("health")] // we write this to tell unity not to lose our data when we rename a variable. this was its old name
	[SerializeField] float maxHealth;
	[SerializeField] float currentHealth;
	[SerializeField] GameObject healthBarPrefab;
	HealthBar myHealthBar;

	void Start() {
		GameObject healthBarObject = Instantiate(healthBarPrefab, References.theCanvas.transform);
		myHealthBar = healthBarObject.GetComponent<HealthBar>();

		currentHealth = maxHealth;
	}

	void Update() {
		// Make our healthbar reflect our health - myHealthBar.ShowHealth()
		// Make our healthbar follow us - move it to our current position    
		myHealthBar.ShowHealthFraction(currentHealth / maxHealth);
		myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
	}
	public void TakeDamage(float damageAmount)
	{
		currentHealth -= damageAmount;
		if (IsDead())
		{
			Destroy(gameObject);
		}
	}

	private void OnDestroy()
	{ 
		if (myHealthBar != null)
		{ 
			Destroy(myHealthBar.gameObject);
		}
	}
	
	public bool IsDead()
	{
		return (currentHealth <= 0);
	}
}
