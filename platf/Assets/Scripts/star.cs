using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class star : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public GameObject effect;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<PlayerController>().health -= damage;
            Destroy(gameObject);
        }
    }
}
