using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnstableControl : MonoBehaviour
{
    public int kills = 0;
    public bool isUnstable = false;
    public int whichUnstable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            kills = kills +1;
        }

        if(kills == 5 && !isUnstable)
        {
            isUnstable = true;
            whichUnstable = Random.Range(1, 4);
        }

        switch (whichUnstable) {
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

    private IEnumerator unstableWalk()
    {
        //Special Beahviour
        yield return new WaitForSecondsRealtime(3);
        isUnstable = false;
        kills = 0;
        whichUnstable = 0;
    }

    private IEnumerator unstableBomb()
    {
        //Special Beahviour
        yield return new WaitForSecondsRealtime(3);
        isUnstable = false;
        kills = 0;
        whichUnstable = 0;
    }

    private IEnumerator unstableDash()
    {
        //Special Beahviour
        yield return new WaitForSecondsRealtime(3);
        isUnstable = false;
        kills = 0;
        whichUnstable = 0;
    }

    private IEnumerator unstableFiring()
    {
        //Special Beahviour
        yield return new WaitForSecondsRealtime(3);
        isUnstable = false;
        kills = 0;
        whichUnstable = 0;
    }
}
