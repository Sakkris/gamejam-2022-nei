using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] HealthHearts healthHearts;
    private HealthSystem health;
    
    void Start()
    {
        health = new HealthSystem(maxHealth);
        if (healthHearts != null)
        {
            healthHearts.SetMaxHealth(maxHealth);
        }
    }

    void Update()
    {
        if (health.getHealth() <= 0)
        {
            Debug.Log("Dead");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            health.GiveDamage(1);
            takeDamageUI();
        }

    }

    void GiveDamage(int i)
    {
        health.GiveDamage(i);
        takeDamageUI();
    }


    void takeDamageUI()
    {
        healthHearts.SetHealth(health.getHealth());
    }

    
}
