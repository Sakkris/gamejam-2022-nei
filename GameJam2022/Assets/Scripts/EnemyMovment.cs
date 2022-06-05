using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovment : MonoBehaviour {

    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Animator animator;

    private bool side = true;
    private Transform target;
    private float movementCooldown = 2;
    private float cooldown = 0;
    Vector3 lastPosition;
    bool exited = false;

    private HealthSystem health;
    [SerializeField] Material material;

    private void Awake()
    {
        health = new HealthSystem(1);
    }
    void Update ()
    {
        //Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude > 1.5 * speed)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        if (target != null)
        {
            Flip(transform.position.x - target.position.x);
            transform.position =
                Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
        }
        else
        {
            if(cooldown <= 0) {     
                lastPosition = new Vector2(Random.Range(-90, 90), Random.Range(-90, 90));
                Flip(transform.position.x - lastPosition.x);
                transform.position = Vector3.MoveTowards(transform.position, lastPosition, speed * Time.deltaTime); 
                    
                cooldown = movementCooldown;
            }
            else
            {
                cooldown -= Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, lastPosition, speed * Time.deltaTime);
            }
        }
        CheckHealth();
    }
    
    private void CheckHealth()
    {
        if(health.getHealth()<= 0)
        {
            StartCoroutine(Die());
        }
    }
    public void Damage(int i)
    {
        health.GiveDamage(i);
    }

    private void Flip(float x)
    {
        if ( x > 0 || !side)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else if (x < 0 || !side)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    /*
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && target == null)
        {
            target = col.transform;
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D col)
    {
        exited = false;
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TimerToAttack(col));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            exited = true;
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);
        Manager.instance.enemyDeath();
        speed = 0;
        GetComponent<Animator>().speed = 0;
        gameObject.GetComponent<SpriteRenderer>().material = material;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    IEnumerator TimerToAttack(Collision2D col)
    {
        print(exited);
        yield return new WaitForSeconds(0.55f);
        if(!exited){
            if(col.transform.Find("Player") != null)
            {
                animator.SetTrigger("Attack");
                target = col.transform;
                col.transform.Find("Player").GetComponent<PlayerHealth>().GiveDamage(1);
            }
        }
    }
}