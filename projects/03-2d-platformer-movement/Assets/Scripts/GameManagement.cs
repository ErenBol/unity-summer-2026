using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    
    private int score = 0;
    public int winScore;

    public bool isGameOver = false;

    private CoinScript[] coins;

    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI HPRemainingText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coins = FindObjectsByType<CoinScript>(FindObjectsInactive.Include);
        winText.gameObject.SetActive(false);
        UpdateScoreText();
    }

   

    public void AddScore()
    {
        score +=1;
        UpdateScoreText();
    }
    // Update is called once per frame

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
        foreach (CoinScript coin in coins)
        {
        coin.gameObject.SetActive(true);
        }
    }
    
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
        if (score >= winScore)
        {
            isGameOver = true;
            winText.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        
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

