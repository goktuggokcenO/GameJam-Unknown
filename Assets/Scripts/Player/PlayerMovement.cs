// Libraries
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

// Player controller
public class PlayerMovement : MonoBehaviour
{
    // Veriables
    public GameObject playerSprite;
    public GameObject armSprite;
    public float moveSpeed;
    public float speedLimit = 0.5f;
    public Animator animator;

    private bool isControlEnabled = true;
    private Rigidbody2D rb;
    private float vertical;
    private float horizontal;


    // Start is called before the first frame update
    void Start()
    {
        // Set rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player if it is not stable
        if (isControlEnabled)
        {
            // Get keybindings from player
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            // Move the character
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.SetFloat("speed", Math.Abs(horizontal) + Math.Abs(vertical));

            // Flip the character and the arms
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
    }

    // Speed limit for diagonal movement
    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= speedLimit;
            vertical *= speedLimit;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

    // Stop the characer
    public void OnEnable()
    {
        isControlEnabled = true;
    }
    public void DisableControl()
    {
        isControlEnabled = false;
    }
}
