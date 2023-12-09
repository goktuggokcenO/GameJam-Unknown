// Libraries and files
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bullet wich shoot by the player
public class PlayerBullet : MonoBehaviour
{
    // Veriables
    public float force;
    public float destroyTime = 10f;
    public int damage;
    public EnemyHealth health;

    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody2D rb;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        Vector3 rotation = transform.position - mousePosition;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        startTime = Time.time;
    }

    // Update funvtion
    void Update()
    {
        if (Time.time - startTime >= destroyTime)
        {
            Destroy(gameObject);
        }
    }

    // Destroy the bullet when colliding with player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().health -= damage;
            Destroy(gameObject);
        }
    }
}
