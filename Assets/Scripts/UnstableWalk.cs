using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableWalk : MonoBehaviour
{
    public PlayerMovement playerController;
    public float disableControlTime = 10f;
    public Transform[] randomPoints;
    public UnstableControl unstableControl;
    public float radius = 1.0f; 

    private bool controlDisabled = false;

    private void Start()
    {
        EnablePlayerControl();
    }
    private void Update()
    {
        if(!controlDisabled)
        {
            if(Score.scoreValue < 100)
            {
                DisablePlayerControl();
                Invoke("EnablePlayerControl", disableControlTime);
            }
            else
            {
                MovePlayerToRandomPoint();
            }
        }
    }
    void DisablePlayerControl()
    {
        playerController.DisableControl();
        controlDisabled = true;
    }
    void EnablePlayerControl()
    {
        playerController.EnableControl();
        controlDisabled = false;
    }
    void MovePlayerToRandomPoint()
    {
        if(randomPoints.Length > 0)
        {
          
        }
    }
    
}
