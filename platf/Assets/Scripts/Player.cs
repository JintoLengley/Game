using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float maxWidht;
    public float minWidht;
    public GameObject effect1;
    public GameObject effect2;
    public Text healthDisplay;
    
    public int health = 5;

    private void Update()

    {
        healthDisplay.text = health.ToString();

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x < maxWidht)
        {
            Instantiate(effect1 , transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x > minWidht)
        {
            Instantiate(effect2, transform.position, Quaternion.identity);
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
