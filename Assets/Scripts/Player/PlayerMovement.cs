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

    // Dash veriables
    public float dashSpeed;
    public float dashLength = 5f;
    public float dashCoolDown = 1f;

    private float activeMoveSpeed;
    private float dashCounter;
    private float dashCoolCounter;


    // Start is called before the first frame update
    void Start()
    {
        // Set rigidbody
        rb = GetComponent<Rigidbody2D>();

        activeMoveSpeed = moveSpeed;
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

            if (Input.GetMouseButton(1))
            {
                if (dashCoolCounter <= 0 && dashCoolCounter <= 0)
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter = dashLength;
                }
            }

            if (dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;

                if (dashCounter <= 0)
                {
                    activeMoveSpeed = moveSpeed;
                    dashCoolCounter = dashCoolDown;

                }
            }

            if (dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
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
