using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    private int score = 0;
    public int winScore;

    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winText.gameObject.SetActive(false);
        UpdateScoreText();
    }



    public void AddScore()
    {
        score +=1;
        UpdateScoreText();

        if (score >= winScore)
        {
            winText.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame



    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
