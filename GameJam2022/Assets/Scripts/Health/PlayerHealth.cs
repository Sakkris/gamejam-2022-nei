using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] AudioSource damageTaken;
    [SerializeField] HealthHearts healthHearts;
    [SerializeField] AudioSource FoodpickUpSound;
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
            GameOverHandler.instance.OnDie();
            Destroy(gameObject);
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
            damageTaken.Play();
            takeDamageUI();
            invul_cooldown = invul_time;
        }
    }

    public void GiveHealth(int i)
    {
        FoodpickUpSound.Play();
        if (health.getHealth() == maxHealth)
            return;

        if (invul_cooldown <= 0)
        {
            health.setHealth(health.getHealth() + i);
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
