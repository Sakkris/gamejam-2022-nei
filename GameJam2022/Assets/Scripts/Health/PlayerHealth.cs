using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] HealthHearts healthHearts;
    private HealthSystem health;
    private float invul_time = 1;
    private float invul_cooldown;
    
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

        if(invul_cooldown > 0)
        {
            invul_cooldown -= Time.deltaTime;
        }
    }

    public void GiveDamage(int i)
    {
        if(invul_cooldown <= 0) { 
            health.GiveDamage(i);
            takeDamageUI();
            invul_cooldown = invul_time;
        }
    }


    void takeDamageUI()
    {
        healthHearts.SetHealth(health.getHealth());
        transform.parent.GetComponent<Animator>().SetTrigger("Damage");
    }

    
}
