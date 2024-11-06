using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform catocPos;
    public float checkRadius;
    public LayerMask whatisGround;
   
    private Animator animator;

    public float maxWidht;
    public float minWidht;
    public GameObject effect1;
    public GameObject effect2;
    public Text healthDisplay;

    public int health = 5;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        if (moveInput == 0)
        {
            animator.SetBool("isrun", false);
        }
        else 
        {
            animator.SetBool("isrun", true);
        }
    }
    private void Update()
    {
        healthDisplay.text = health.ToString();
        isGrounded = Physics2D.OverlapCircle(catocPos.position, checkRadius, whatisGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            animator.SetTrigger("jump");
        }
        if(isGrounded == true)
        {
            animator.SetBool("isjump", false);

        }
        else
        {
            animator.SetBool("isjump", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            Instantiate(effect1, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) )
        {
            Instantiate(effect2, transform.position, Quaternion.identity);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("monet"))
        {
          Pickup.monetCount += 1;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health <= 0)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

}


