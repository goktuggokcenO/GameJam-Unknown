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
    public GameObject bloodStain;
    float horizontal, vertical;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = gameObject.transform.position.x;
        vertical = gameObject.transform.position.y;

        if (health <= 0)
        {
            lastPosition = gameObject.transform.position;
            Instantiate(bloodStain, lastPosition, Quaternion.identity);
            Destroy(gameObject);
            score.KillEnemy();
        }
    }
}
