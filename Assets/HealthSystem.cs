using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float health;

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (IsDead())
        {
            Destroy(gameObject);
        }
    }
    
    public bool IsDead()
    {
        return (health <= 0);
    }
}
