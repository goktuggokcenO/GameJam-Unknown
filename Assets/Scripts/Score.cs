using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: "+ scoreValue.ToString();
    }

    //when enemy died score will increase by 10
    public void KillEnemy()
    {
        scoreValue += 10;
        UpdateScoreText();
    }

}
