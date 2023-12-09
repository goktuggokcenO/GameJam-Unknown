// Libraries and files
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Player health
public class PlayerHealth : MonoBehaviour
{
    // Veriables
    public float health;
    public float maxHealth;
    public Image helthBar;

    public GameOver gameOver;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        helthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
