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
    private bool canBeUnstable = true;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        canBeUnstable = false;
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
                whichUnstable = Random.Range(1, 1);
                switch (whichUnstable)
                {
                    case 0: break;
                    case 1:
                        StartCoroutine(unstableWalk()); break;
                    case 2:
                        StartCoroutine(unstableBomb()); break;
                    case 3:
                        StartCoroutine(unstableDash()); break;
                    case 4:
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
        yield return new WaitForSecondsRealtime(3);
        playerMovement.EnableControl();
        isUnstable = false;
        whichUnstable = 0;
        
    }

    private IEnumerator unstableBomb()
    {
        Debug.Log("unstable bomb");
        yield return new WaitForSecondsRealtime(3);

    }

    private IEnumerator unstableDash()
    {
        Debug.Log("unstable dash");
        yield return new WaitForSecondsRealtime(3);

    }

    private IEnumerator unstableFiring()
    {
        Debug.Log("unstable firing");
        yield return new WaitForSecondsRealtime(3);

    }
}
