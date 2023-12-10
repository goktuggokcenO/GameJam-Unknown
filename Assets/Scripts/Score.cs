using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public TextMeshProUGUI scoreText;
    public static int unstableCounter = 0;

    void Start()
    {
        scoreValue = 0;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: "+ scoreValue.ToString();
        Debug.Log(scoreText.text);
        PlayerPrefs.SetInt("Score", scoreValue);
    }

    //when enemy died score will increase by 10
    public void KillEnemy()
    {
        scoreValue += 10;
        unstableCounter += 10;
        UpdateScoreText();
    }

}
