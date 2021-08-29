using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string SCORE_TEMPLATE = "SCORE: {0}";
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TextMeshProUGUI scoreText;

    public static GameManager Instance = null;

    private int score;
    private bool isPaused = false;
    private AsyncOperation loadMenuSceneAsync;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        loadMenuSceneAsync = SceneManager.LoadSceneAsync("MenuScene");
        loadMenuSceneAsync.allowSceneActivation = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SetPause(!isPaused);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = String.Format(SCORE_TEMPLATE, score);

        Invoke("checkEnemiesLeft", 1f);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void checkEnemiesLeft()
    {
        if (GameObject.FindGameObjectsWithTag("Enemies").Length == 0) Victory();
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetPause(bool value)
    {
        isPaused = value;
        pausePanel.SetActive(value);
        Time.timeScale = (value) ? 0 : 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        loadMenuSceneAsync.allowSceneActivation = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
