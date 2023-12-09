// Libraries and files
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Rendering;

// Enemy bullet script
public class EnemyBullet : MonoBehaviour
{
    // Veriables
    public float force;

    private GameObject player;
    private Rigidbody2D rb;

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
        
    }
}
