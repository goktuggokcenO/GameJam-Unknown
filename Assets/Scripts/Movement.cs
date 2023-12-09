// Libraries
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

// Player controller
public class Movement : MonoBehaviour
{
    // Veriables
    private Rigidbody2D rb;
    float vertical;
    float horizontal;
    public Animator animator;
    public float moveSpeed;
    public float speedLimit = 0.5f;
    public GameObject playerSprite;
    public GameObject armSprite;

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
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        animator.SetFloat("speed", Math.Abs(horizontal) + Math.Abs(vertical));

        if (currentMousePosition.x > gameObject.transform.position.x)
        {
            playerSprite.transform.localScale = new Vector3(1, 1, 1);
            armSprite.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (currentMousePosition.x < gameObject.transform.position.x)
        {
            playerSprite.transform.localScale = new Vector3(-1, 1, 1);
            armSprite.transform.localScale = new Vector3(1, -1, 1);
        }
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
