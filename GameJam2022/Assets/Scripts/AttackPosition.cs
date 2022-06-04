using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPosition : MonoBehaviour
{
    Transform parentPosition;
    [SerializeField] Transform thisPosition;
    [SerializeField] GameObject mainCharacter;
    [SerializeField] float attackRange = 0.5f;
    public LayerMask layerMask;
    bool ableToAttack = true;


    void Update()
    {
        parentPosition = gameObject.transform.parent;
        thisPosition.position = parentPosition.position + new Vector3(0.7f, 0, 0);
        string facing = mainCharacter.GetComponent<PlayerMovement>().getFacing();
        print(facing);
        transformPosition(facing);

        if (Input.GetMouseButtonDown(0) && ableToAttack) { HandleAttack();}
    }

    private void transformPosition(string facing)
    {
        switch (facing)
        {
            case "east":
                thisPosition.position = parentPosition.position + new Vector3(0.1f, 0, 0);
                break;
            case "west":
                thisPosition.position = parentPosition.position + new Vector3(-0.1f, 0, 0);
                break;
            case "north":
                thisPosition.position = parentPosition.position + new Vector3(0, 0.1f, 0);
                break;
            case "south":
                thisPosition.position = parentPosition.position + new Vector3(0, -0.1f, 0);
                break;
        }
    }

    private void HandleAttack()
    {
        StartCoroutine(WaitTime());
        Collider2D[] objectsInRadious = Physics2D.OverlapCircleAll(thisPosition.position, attackRange, layerMask);

        float shortestDistance = 1000000;
        Collider2D shortestObject= null;
        foreach (Collider2D objectInRadious in objectsInRadious)
        {
            float distance = Vector3.Distance(gameObject.transform.position, objectInRadious.transform.position);
            if(distance < shortestDistance)
            {
                shortestDistance = distance;
                shortestObject = objectInRadious;
            }
        }
        if(shortestObject != null)
        {
           //GIVE DAMAGE
       
        }
    }
    IEnumerator WaitTime()
    {
        ableToAttack = false;
        yield return new WaitForSeconds(0.80f);
        ableToAttack = true;

    }

    private void OnDrawGizmosSelected()
    {
        if (thisPosition.position == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(thisPosition.position, attackRange);

    }



}
