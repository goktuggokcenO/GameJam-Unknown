// Libraries and files
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Player health
public class PlayerHealth : MonoBehaviour
{
    // Veriables
    public float health;
    public float maxHealth;
    public Image helthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        helthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
}
