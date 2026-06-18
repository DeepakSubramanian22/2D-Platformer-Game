using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // assign these in Inspector
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform currentTarget;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        // cache all components once
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // start moving toward pointB
        currentTarget = pointB;

        // enemy is always walking so set this to true immediately
        animator.SetBool("EnemyWalk", true);
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        // move enemy toward current target
        transform.position = Vector2.MoveTowards(transform.position,currentTarget.position,speed * Time.deltaTime);

        // check how far we are from the target
        float distanceToTarget = Vector2.Distance(transform.position,currentTarget.position);

        // if close enough, flip direction
        if (distanceToTarget < 0.1f)
        {
            FlipDirection();
        }
    }   

    private void FlipDirection()
    {
        
        if (currentTarget == pointB)
        {
            // reached right point, now go left
            currentTarget = pointA;

            // flip sprite to face left
            spriteRenderer.flipX = true;
        }
        else
        {
            // reached left point, now go right
            currentTarget = pointB;

            // restore sprite to face right
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if we hit the player
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
          player.KillPlayer(); 
        }
    }
}