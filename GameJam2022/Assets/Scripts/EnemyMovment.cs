using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovment : MonoBehaviour {

    public float speed = 10.0f;
    public Rigidbody2D rb;

    private Transform target;
    private float movementCooldown = 2;
    private float cooldown = 0;
    Vector3 lastPosition;

    void Update ()
    {
        if (target != null)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            if(cooldown <= 0) {     
                lastPosition = new Vector2(Random.Range(-90, 90), Random.Range(-90, 90));
                transform.position = Vector3.MoveTowards(transform.position, lastPosition, speed * Time.deltaTime); 
                    
                cooldown = movementCooldown;
            }
            else
            {
                cooldown -= Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, lastPosition, speed * Time.deltaTime);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && target == null)
        {
            Debug.Log("Here");
            target = col.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            target = col.transform;
            col.transform.Find("Player").GetComponent<PlayerHealth>().GiveDamage(1);
        }
    }

    public void Die()
    {
        Manager.instance.enemyDeath();
        Destroy(gameObject);
    }
}