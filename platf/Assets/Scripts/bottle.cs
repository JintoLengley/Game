using UnityEngine;

public class bottle : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject bottleExpEffect;
    public GameObject PlayerExpEffect;
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
            private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(bottleExpEffect, transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
           Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
    
}
