using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreDisplay : MonoBehaviour
{
    public Text scoreText;  

    void Start()
    {
        UpdateFinalScore();
    }

    void UpdateFinalScore()
    {
        int finalScore = ScoreManager.Instance.GetScore();

        scoreText.text = "Final Score: " + finalScore.ToString();
    }
}