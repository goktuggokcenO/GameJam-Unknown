using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (currentMousePosition.x > gameObject.transform.position.x)
        {
            gameObject.transform.position = new Vector3(-1.216f, 0.12f, 0);
        }
        else if (currentMousePosition.x < gameObject.transform.position.x)
        {
            gameObject.transform.position = new Vector3(1.216f, 0.12f, 0);
        }
    }
}
