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
    public GameObject unstableControl; //unstable animation i�in
    public GameObject unstableControl2; //unstable animation i�in
    public GameObject unstableControl3; //unstable animation i�in


    public PlayerMovement playerMovement;

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


        if (isUnstable == false)
        {
            if (Score.unstableCounter >= 50)
            {
                Score.unstableCounter = 0;
                isUnstable = true;
                whichUnstable = Random.Range(1, 3);
                switch (whichUnstable)
                {
                    case 0: break;
                    case 1:
                       StartCoroutine(unstableWalk()); break;
                    case 2:
                        StartCoroutine(unstableDash()); break;
                    
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
}
