// Libraries and files
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

// Unstable control scripth
public class UnstableControl : MonoBehaviour
{
    // Veriables for the animatin
    public GameObject unstableControl;
    public GameObject unstableControl2;
    public GameObject unstableControl3;


    // Unstable controller veriables
    public bool isUnstable = false;       // Track the player is stable or not
    public int unstableCounter = 0;       // Unstable counter 
    public int unstableLimit = 10;        // Unstable limit for the effect

    private int unstableID;                // Unstable ID for the effects
    private int unstableCounterMin = 5;    // Minimum unstable counter increase
    private int unstableCounterMax = 20;   // Maximum unstable counter increase


    // Increase unstable counter
    public void AddUnstablePoint()
    {
        unstableCounter += Random.Range(unstableCounterMin, unstableCounterMax);
    }


    // Veriables for unstable walk effect
    private float unstableWalkTime = 3f; // Unstable walk effect time

    // Unstable walk effect
    public IEnumerator unstableWalk()
    {
        Debug.Log("Unstable Walk");
        unstableControl.SetActive(true);
        gameObject.GetComponent<PlayerMovement>().DisableControl();
        yield return new WaitForSecondsRealtime(unstableWalkTime);
        gameObject.GetComponent<PlayerMovement>().EnableControl();
        unstableControl.SetActive(false);
        isUnstable = false;
        unstableID = 0;
    }


    // Veriables for unstable dash effect
    private float unstableDashTime = 3f;

    // Unstable dash effect
    public IEnumerator UnstableDash()
    {
        Debug.Log("Unstable Dash");
        unstableControl.SetActive(true);
        gameObject.GetComponent<PlayerMovement>().DisableDash();
        yield return new WaitForSecondsRealtime(unstableDashTime);
        gameObject.GetComponent<PlayerMovement>().EnableDash();
        unstableControl.SetActive(false);
        isUnstable = false;
        unstableID = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        unstableControl.SetActive(false);
        unstableControl2.SetActive(false);
        unstableControl3.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // Make the playre unstable
        if (isUnstable == false 
            && unstableCounter >= unstableLimit)
        {
            unstableCounter = 0;
            isUnstable = true;
            unstableID = Random.Range(1, 3);
            switch (unstableID)
            {
                // Natural state
                case 0: 
                    break;

                // Unstable dash effect
                case 1:
                    StartCoroutine(unstableWalk());
                    break;

                // Unstable dash effect
                case 2:
                    StartCoroutine(UnstableDash());
                    break;
            }
        }
    }
}
