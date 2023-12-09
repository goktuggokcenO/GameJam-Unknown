// Libraries and files
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements.Experimental;

// Enemy bullet script
public class EnemyBullet : MonoBehaviour
{
    // Veriables
    public float force;
    public int damage;
    public PlayerHealth health;

    private GameObject player;
    private Rigidbody2D rb;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player objects and rigidbody
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        // Create the bullet object and add velocity
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        // Rotate the bullet acording to angle
        float rotation = MathF.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    // Destroy the bullet when colliding with player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= damage;
            Destroy(gameObject);
        }
    }
}
