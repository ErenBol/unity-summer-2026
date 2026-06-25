using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int winScore = 5;

    public TMP_Text scoreText;
    public TMP_Text winText;

    void Start()
    {
        winText.gameObject.SetActive(false);
        UpdateScoreText();
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();

        if (score >= winScore)
        {
            winText.gameObject.SetActive(true);
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}