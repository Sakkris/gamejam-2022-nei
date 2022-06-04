using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rbPlayer;
    [SerializeField] Animator animator;
    [SerializeField] float movementSpeed = 5f;
    bool isDoingAction = false;
    short isMoving = 1;
    float lastKey = 0;
    Vector2 movementPlayer;
    float saveMovementSpeed;
    bool ableToAttack = true;

    public enum Facing
    {
        West,
        East,
        North,
        South
    }
    public static Facing CurrentFacing { get; private set; }
    void Update()
    {

        movementPlayer.x = Input.GetAxisRaw("Horizontal");
        movementPlayer.y = Input.GetAxisRaw("Vertical");


        animator.SetFloat("Horizontal", movementPlayer.x);
        animator.SetFloat("Vertical", movementPlayer.y);
        animator.SetFloat("Speed", movementPlayer.sqrMagnitude);
        float key = getLastMovementKey(lastKey);
        animator.SetFloat("LastKey", key);
        lastKey = key;

        if (Input.GetMouseButtonDown(0))
        {
            if (ableToAttack)
            {
                //Atackt
            }
        }

    }

    public void ChangeAbleToAttack()
    {
        ableToAttack = !ableToAttack;
    }

    void FixedUpdate()
    {
        rbPlayer.MovePosition(rbPlayer.position + calculateSpeed());
    }

    Vector2 calculateSpeed()
    {
        return movementPlayer * movementSpeed * Time.fixedDeltaTime * isMoving;
    }


    public float getLastMovementKey(float lastKey)
    {
        if (isDoingAction == true)
        {
            return lastKey;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            CurrentFacing = Facing.West;
            return 1;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            CurrentFacing = Facing.North;
            return 3;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            CurrentFacing = Facing.East;
            return 2;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            CurrentFacing = Facing.South;
            return 4;
        }
        else
            return lastKey;
    }

    public void setMovementSpeed(float newSpeed)
    {
        this.movementSpeed = newSpeed;
    }
    public void setIsDoingAction(bool isMine)
    {
        this.isDoingAction = isMine;
    }

    public string getFacing()
    {
        switch (lastKey)
        {
            case 1:
                return "west";
            case 2:
                return "east";
            case 3:
                return "north";
        }
        return "south";

    }

    public void DeactivateOrActivate()
    {
        if (this.enabled == true)
        {
            saveMovementSpeed = movementSpeed;
            animator.SetFloat("Speed", 0);
            this.enabled = false;
        }
        else
        {
            movementSpeed = saveMovementSpeed;
            this.enabled = true;
        }


    }


}

