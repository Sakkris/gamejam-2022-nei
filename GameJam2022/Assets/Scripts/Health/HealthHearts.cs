using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHearts : MonoBehaviour
{
    [SerializeField] GameObject healthHeart;
    [SerializeField] GameObject noHealthHeart;
    [SerializeField] GameObject hearts;
    int maxHealth;

    public void SetHealth(int health)
    {
        for(int i = 0; i<hearts.transform.childCount; i++)
        {
            Destroy(hearts.transform.GetChild(i));
        }
        int noHealthHears = maxHealth - health;

        for(int i = 0; i< health; i++)
        {

            GameObject heartClone = Instantiate(healthHeart, hearts.transform);
            RectTransform cloneRect = heartClone.GetComponent<RectTransform>();

            //CONTINUAR
        }
    }
    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }
}
