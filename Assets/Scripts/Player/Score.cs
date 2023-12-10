// Libraries and files
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Track the player score
public class Score : MonoBehaviour
{
    // Veriable for tracking score
    public static int scoreValue = 0;
    public TextMeshProUGUI scoreText;


    // Update score text
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreValue.ToString();
    }


    // When enemy died score will increase by 10
    public void KillEnemy()
    {
        scoreValue += 10;
        gameObject.GetComponent<UnstableControl>().AddCounter();
        UpdateScoreText();
    }


    // Start function
    void Start()
    {
        scoreValue = 0;
        UpdateScoreText();
    }
}
