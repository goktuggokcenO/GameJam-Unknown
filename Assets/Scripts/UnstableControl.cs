using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnstableControl : MonoBehaviour
{
    public bool isUnstable = false;
    public int whichUnstable;
    public int scoreMax = 100;
    public int scoreMin = 0;
    public GameObject unstableControl; //unstable animation için

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        unstableControl.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (isUnstable == false)
        {
            if (Score.unstableCounter >= 50)
            {
                Score.unstableCounter = 0;
                isUnstable = true;
                whichUnstable = Random.Range(1, 2);
                switch (whichUnstable)
                {
                    case 0: break;
                    case 1:
                       StartCoroutine(unstableDash()); break;
                    case 2:
                        StartCoroutine(unstableDash()); break;
                    case 3:
                        StartCoroutine(unstableFiring()); break;
                }

            }
        }


        //if (Input.GetKeyDown(KeyCode.LeftAlt))
        //{
        //    kills += Random.Range(scoreMin, scoreMax); ;
        //}




    }

    private IEnumerator unstableWalk()
    {
        Debug.Log("unstable walk");
        playerMovement.DisableControl();
        unstableControl.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        playerMovement.EnableControl();
        unstableControl.SetActive(false);
        isUnstable = false;
        whichUnstable = 0;
        
    }

    private IEnumerator unstableDash()
    {
        Vector3 mousePosition = new Vector3(1, 1, 1);

        Debug.Log("unstable dash");
        playerMovement.Dash(mousePosition);
        unstableControl.SetActive(true);
        isUnstable = false;
        whichUnstable = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        unstableControl.SetActive(false);

    }

    private IEnumerator unstableFiring()
    {
        unstableControl.SetActive(true);
        Debug.Log("unstable firing");
        yield return new WaitForSecondsRealtime(3);
        unstableControl.SetActive(false);
    }
}
