using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaZombie : MonoBehaviour
{
    [SerializeField] EnemyMovment zombie;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") )
        {
            zombie.SetTarget(col.transform);
        }
    }
}
