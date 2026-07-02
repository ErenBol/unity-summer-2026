using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManagement : MonoBehaviour
{
    public string nextSceneName;
    private int score = 0;
    public int winScore;

    public bool isGameOver = false;

    private CoinScript[] coins;

    private Coroutine messageCoroutine;
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
            StartCoroutine(WinThenLoadNextLevel());
        }
        else
        {
            if (messageCoroutine != null)
            {
                StopCoroutine(messageCoroutine);
            }

            messageCoroutine = StartCoroutine(ShowTemporaryMessage("Collect all coins first!", 2f));
        }
    }
    public void LoseGame()
    {
        isGameOver = true;
        winText.SetText("You Lose: Press R to restart again");
        winText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private IEnumerator WinThenLoadNextLevel()
    {
        isGameOver = true;

        winText.SetText("You Win!");
        winText.gameObject.SetActive(true);

        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(2f);

        Time.timeScale = 1f;

        SceneManager.LoadScene(nextSceneName);
    }
    private IEnumerator ShowTemporaryMessage(string message, float seconds)
    {
        winText.SetText(message);
        winText.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(seconds);

        winText.gameObject.SetActive(false);
    }
    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

