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
            Destroy(hearts.transform.GetChild(i).gameObject);
        }
        int noHealthHears = maxHealth - health;

        int lastPos = 0;
        for(int i = 0; i< health; i++)
        {
            float posX = healthHeart.GetComponent<RectTransform>().anchoredPosition.x;
            float posY = healthHeart.GetComponent<RectTransform>().anchoredPosition.y;
            GameObject heartClone = Instantiate(healthHeart, hearts.transform);
            RectTransform cloneRect = heartClone.GetComponent<RectTransform>();
            cloneRect.gameObject.SetActive(true);
            cloneRect.anchoredPosition = new Vector2(posX - i * 50, posY);
            lastPos = i;
        }
        for(int i = 1; i <= noHealthHears; i++)
        {
            if(noHealthHears == maxHealth)
            {
                i--;
            }
            float posX = healthHeart.GetComponent<RectTransform>().anchoredPosition.x;
            float posY = healthHeart.GetComponent<RectTransform>().anchoredPosition.y;
            GameObject heartClone = Instantiate(noHealthHeart, hearts.transform);
            RectTransform cloneRect = heartClone.GetComponent<RectTransform>();
            cloneRect.gameObject.SetActive(true);
            cloneRect.anchoredPosition = new Vector2(posX - (i+lastPos) * 50, posY);
            if (noHealthHears == maxHealth)
            {
                i++;
            }
        }


    }
    public void SetMaxHealth(int maxHealth)
    {
        for (int i = 0; i < hearts.transform.childCount; i++)
        {
            Destroy(hearts.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < maxHealth; i++)
        {
            float posX = healthHeart.GetComponent<RectTransform>().anchoredPosition.x;
            float posY = healthHeart.GetComponent<RectTransform>().anchoredPosition.y;
            GameObject heartClone = Instantiate(healthHeart, hearts.transform);
            RectTransform cloneRect = heartClone.GetComponent<RectTransform>();
            cloneRect.gameObject.SetActive(true);
            cloneRect.anchoredPosition = new Vector2(posX - i * 50, posY);
        }
        this.maxHealth = maxHealth;
    }
}
