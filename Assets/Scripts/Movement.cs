// Libraries
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Player controller
public class Movement : MonoBehaviour
{
    // Veriables
    private Rigidbody2D rb;
    float vertical;
    float horizontal;

    public float moveSpeed;
    public float speedLimit = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    // Fixed update for the character movement
    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= speedLimit;
            vertical *= speedLimit;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}
