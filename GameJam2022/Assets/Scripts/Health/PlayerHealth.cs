using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] HealthBar healthBar;
    private HealthSystem health;
    
    void Start()
    {
        health = new HealthSystem(maxHealth);
        if (healthBar != null)
        {
            healthBar.setMaxHealth(maxHealth);
        }
    }

    void Update()
    {
        if(health.getHealth() <= 0)
        {
            //DEAD
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            health.GiveDamage(1);
            takeDamageUI();
        }
        */
    }

    void takeDamageUI()
    {
        healthBar.setHealth(health.getHealth());
    }

    
}
