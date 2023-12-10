// Libraries
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

// Shooting code for the player
public class Shooting : MonoBehaviour
{
    // Shooting veribles
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire = true;
    public bool animateFire = false;
    public float timeBetweenFireing;
    public Animator animator;
    private Camera mainCam;
    private Vector3 mousePos;
    private float timer;
    public AudioSource audioControl;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    } 

    // Update is called once per frame
    void Update()
    {
        // Rotate the player weapon
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
 
    
        // Check the player can fire or not
        if (canFire == false)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFireing)
            {
                canFire = true;
                timer = 0;
            }    
        }

        // Spawn the bullet object
        if (Input.GetMouseButton(0) && canFire)
        {
            animator.SetTrigger("isFiring");
            audioControl.Play();
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
