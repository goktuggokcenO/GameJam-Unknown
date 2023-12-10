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
    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            score.KillEnemy();
        }
    }
}
