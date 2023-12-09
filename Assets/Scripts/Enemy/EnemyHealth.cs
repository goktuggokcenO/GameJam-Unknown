// Libraries and files
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Enemy health
public class EnemyHealth : MonoBehaviour
{
    // Veriables
    public float health;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
