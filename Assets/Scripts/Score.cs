// Libraries and files
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// Score board
public class Score : MonoBehaviour
{
    // Score board veriables
    public int scoreValue = 0;
    public TextMeshProUGUI scoreText;


    // Update score text
    void UpdateScoreText()
    {
<<<<<<< Updated upstream
        scoreText.text = "Score: "+ scoreValue.ToString();
        Debug.Log(scoreText.text);
        PlayerPrefs.SetInt("Score", scoreValue);
=======
        scoreText.text = "Score: " + scoreValue.ToString();
>>>>>>> Stashed changes
    }


    //when enemy died score will increase by 10
    public void KillEnemy()
    {
        scoreValue += 10;
        gameObject.GetComponent<UnstableControl>().AddUnstablePoint();
        UpdateScoreText();
    }


    // Start funvtion
    void Start()
    {
        UpdateScoreText();
    }
}
