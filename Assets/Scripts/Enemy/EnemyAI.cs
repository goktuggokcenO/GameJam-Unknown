// Libraries
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Enemy AI
public class EnemyAI : MonoBehaviour
{
    // Veriables
    public GameObject player;
    public Rigidbody2D rb;
    public float speed;
    public float detectionRange;
    //public Animator animator;

    private float distance;

    // Update is called once per frame

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;    
    }
    void Update()
    {
        // Calculate the distance and direction
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // Change the direction of the enemy acorfing to the player.
        if (player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(3, 3, 3);
        }
        else if (player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-3, 3, 3);
        }

        // Move the enemy to the player
        if (distance < detectionRange)
        {
            //rb.bodyType = RigidbodyType2D.Dynamic;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //animator.SetBool("isIdle", false);
        }
        else
        {
            //rb.bodyType = RigidbodyType2D.Static;
            //animator.SetBool("isIdle", true);
        }
    }
}
