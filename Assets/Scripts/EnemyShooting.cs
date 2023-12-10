// Libraries and files
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// Eenemy shooting script
public class EnemyShooting : MonoBehaviour
{
    // Veriables
    public GameObject bullet;
    public Transform bulletPosition;
    public float enemyRange;
    private float timer;
    private GameObject player;

    public AudioSource audioControl;

    // Enemy shoot function
    void shoot()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot the player
        timer += Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);
       
        if (distance < enemyRange)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                shoot();
                audioControl.Play();
            }
        }
    }
}
