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
        rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, vertical * moveSpeed * Time.deltaTime).normalized;
    }
}
