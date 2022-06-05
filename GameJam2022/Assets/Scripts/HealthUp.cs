using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.Find("Player").GetComponent<PlayerHealth>().GiveHealth(1);
            Destroy(gameObject);
        }
    }
}
