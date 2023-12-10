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
<<<<<<< Updated upstream
    public bool isUnstable = false;
    public int whichUnstable;
    public int scoreMax = 100;
    public int scoreMin = 0;
    public GameObject unstableControl; //unstable animation için
    public GameObject unstableControl2; //unstable animation için
    public GameObject unstableControl3; //unstable animation için

=======
    // Unstable controller veriables
    public bool isUnstable = false;       // Track the player is stable or not
    public int unstableCounter = 0;       // Unstable counter 
    public int unstableLimit = 10;        // Unstable limit for the effect
    public GameObject unstableControl;    // Unstable control for animation

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
    private IEnumerator unstableWalk()
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
    private IEnumerator unstableDash()
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
>>>>>>> Stashed changes


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
        if (isUnstable == false && unstableCounter >= unstableLimit)
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
                    StartCoroutine(unstableDash());
                    break;
            }
        }
<<<<<<< Updated upstream


        //if (Input.GetKeyDown(KeyCode.LeftAlt))
        //{
        //    kills += Random.Range(scoreMin, scoreMax); ;
        //}




    }

    private IEnumerator unstableWalk()
    {
        Debug.Log("unstable walk");
        playerMovement.DisableControl();
        unstableControl2.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        playerMovement.EnableControl();
        unstableControl2.SetActive(false);
        isUnstable = false;
        whichUnstable = 0;
        
    }

    private IEnumerator unstableDash()
    {
        Vector3 mousePosition = new Vector3(1, 1, 1);

        Debug.Log("unstable dash");
        playerMovement.Dash(mousePosition);
        unstableControl3.SetActive(true);
        isUnstable = false;
        whichUnstable = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        unstableControl3.SetActive(false);

    }

    private IEnumerator unstableFiring()
    {
        unstableControl.SetActive(true);
        Debug.Log("unstable firing");
        yield return new WaitForSecondsRealtime(3);
        unstableControl.SetActive(false);
=======
>>>>>>> Stashed changes
    }
}
