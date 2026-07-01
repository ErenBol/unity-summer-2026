using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    
    private int score = 0;
    public int winScore;

    public bool isGameOver = false;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI HPRemainingText;
    
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
            WinGame();
        }
    }
    // Update is called once per frame


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    void UpdateScoreText()
    {
        Time.timeScale = 1f;
        scoreText.text = "Score: " + score;
    }
    
    public void UpdateHP(int hp)
    {
        HPRemainingText.text = "HPs: " +  hp;
    }
    
    public void WinGame()
    {
        isGameOver = true;
        winText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoseGame()
    {
        isGameOver = true;
        winText.SetText("You Lose: Press R to restart again");
        winText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

