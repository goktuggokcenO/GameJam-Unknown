using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSound : MonoBehaviour
{
    public float vertical;
    public float horizontal;
    public float isMoving;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        isMoving = Math.Abs(horizontal) + Math.Abs(vertical);

        if ( isMoving > 0 && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if(isMoving == 0 && audioSource.isPlaying) 
        {
            audioSource.Stop();
        }
        
        
    }
}
