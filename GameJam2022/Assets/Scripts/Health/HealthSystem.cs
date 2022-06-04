using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    int health;

    public HealthSystem(int health)
    {
        this.health = health;
    }

    public void GiveDamage(int damage)
    {
        health -= damage;
    }

    public int getHealth()
    {
        return health;
    }
    public void setHealth(int health)
    {
        this.health = health;
    }


}

