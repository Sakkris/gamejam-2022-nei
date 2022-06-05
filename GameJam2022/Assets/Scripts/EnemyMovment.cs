using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovment : MonoBehaviour {

    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Animator animator;
    [SerializeField] AudioSource hitSound;
    [SerializeField] AudioSource atackSound;

    private bool side = true;
    private Transform target;
    private float movementCooldown = 2;
    private float cooldown = 0;
    Vector3 lastPosition;
    bool exited = false;

    private HealthSystem health;
    [SerializeField] Material material;
    [SerializeField] float knockbackSpeed = 2f;
    [SerializeField] Sprite knockbackSprite;
    [SerializeField] Sprite deadSprite;
    bool atacked = false;
    string facingAttack;
    bool dead = false;
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
        if (atacked)
        {
            KnockBack();
        }
        CheckHealth();
    }
    
    private void CheckHealth()
    {
        if(health.getHealth()<= 0)
        {
            dead = true;
            StartCoroutine(Die());
        }
    }
    public void Damage(int i, string facing)
    {
        atacked = true;
        facingAttack = facing;
        
        health.GiveDamage(i);
        hitSound.Play();
    }

    private void KnockBack()
    {
        Destroy(gameObject.GetComponent<Animator>());
        GetComponent<SpriteRenderer>().sprite = knockbackSprite;
        Vector2 knockPosition;
        if (facingAttack.Equals("north"))
        {
            knockPosition = new Vector2(transform.position.x, transform.position.y + 1);
            transform.position = Vector3.MoveTowards(transform.position, knockPosition, knockbackSpeed * Time.deltaTime);
        }
        if (facingAttack.Equals("south"))
        {
            knockPosition = new Vector2(transform.position.x, transform.position.y - 1);
            transform.position = Vector3.MoveTowards(transform.position, knockPosition, knockbackSpeed * Time.deltaTime);
        }
        if (facingAttack.Equals("east"))
        {
            knockPosition = new Vector2(transform.position.x + 1, transform.position.y);
            transform.position = Vector3.MoveTowards(transform.position, knockPosition, knockbackSpeed * Time.deltaTime);
        }
        if (facingAttack.Equals("west"))
        {
            knockPosition = new Vector2(transform.position.x - 1, transform.position.y);
            transform.position = Vector3.MoveTowards(transform.position, knockPosition, knockbackSpeed * Time.deltaTime);
        }
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
            print(col.gameObject.name);
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
        GetComponent<SpriteRenderer>().sprite = deadSprite;
        Manager.instance.enemyDeath();
        speed = 0;
        gameObject.GetComponent<SpriteRenderer>().material = material;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    IEnumerator TimerToAttack(Collision2D col)
    {
        yield return new WaitForSeconds(0.5f);
        atackSound.Play();
        yield return new WaitForSeconds(0.3f);
        if (!exited){
            CheckHealth();
            if (!dead)
            {
                animator.SetTrigger("Attack");
                target = GameObject.Find("Player").transform;
                GameObject.Find("Player").GetComponent<PlayerHealth>().GiveDamage(1);
            }
        }
    }
}