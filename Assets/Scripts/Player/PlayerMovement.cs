// Libraries
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.Rendering;

// Player controller
public class PlayerMovement : MonoBehaviour
{
    // Veriables
    public GameObject playerSprite;
    public GameObject armSprite;
    public float moveSpeed;
    public float speedLimit = 0.5f;
    public Animator animator;
    public GameObject DashAnim; //Dash animation için

    private bool isControlEnabled = true;
    private Rigidbody2D rb;
    private float vertical;
    private float horizontal;

    public float dashDistance = 5f;
    public float dashDuration = 1f;
    public float dashCooldown = 2f;

    private bool isDashing = false;
    private bool isDashEnabled = true;
    private float lastDashTime;

    // Start is called before the first frame update
    void Start()
    {
        DashAnim.SetActive(false);
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

            if (Input.GetMouseButtonDown(1) 
                && !isDashing 
                && Time.time - lastDashTime > dashCooldown
                && isDashEnabled)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                StartCoroutine(Dash(mousePosition));
                lastDashTime = Time.time;
            }
        }
    }

    public IEnumerator Dash(Vector3 targetPosition)
    {
        isDashing = true;
<<<<<<< Updated upstream
        DashAnim.SetActive(true);
=======


>>>>>>> Stashed changes
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < dashDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / dashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isDashing = false;
        DashAnim.SetActive(false);
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


    // Prevent dahing
    public void EnableDash()
    {
        isDashEnabled = true;
    }

    public void DisableDash()
    {
        isDashEnabled = false;
    }


    // Stop the characer
    public void EnableControl()
    {
        isControlEnabled = true;
    }

    public void DisableControl()
    {
        isControlEnabled = false;
    }
}
