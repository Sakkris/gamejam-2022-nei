using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteMirro : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    void Update()
    {
        if (movement.getFacing().Equals("west"))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else{
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
    }
}
