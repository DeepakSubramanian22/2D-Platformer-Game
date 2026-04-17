using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public ScoreCard scoreCard;    
    public Animator animator;
    public float speed ;
    private Rigidbody2D rb2d;
    public float jump;
    public GameOver gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void KillPlayer()
    {
        Debug.Log("Player Killed");
        gameOver.PlayerDied();
        this.enabled = false; 
        
    }


    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical);
        PlayerMovementAnimation(horizontal, vertical); 
        CrouchControll();
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
        
    }

    private void MoveCharacter(float horizontal ,float vertical)
    {

        // move character horizotally 

        Vector3 position = transform.position;
        position.x += horizontal* speed * Time.deltaTime;
        transform.position = position;
    }

    private bool isGrounded;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (horizontal > 0)
        {    
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void CrouchControll()
    {
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)){
            animator.SetBool("Crouch", true); 
        }
            else
            {
                animator.SetBool("Crouch", false);
            }
    }

    public void PickKey()
    {
       Debug.Log("Player Picked up the Key");
       scoreCard.IncreaseScore(10);
    }
} 