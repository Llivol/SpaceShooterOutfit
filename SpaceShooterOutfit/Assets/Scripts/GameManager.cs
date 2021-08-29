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
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI enemiesLeftText;

    public static GameManager Instance = null;

    private int score;
    private bool isPaused = false;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    private void Start()
    {
        checkEnemiesLeft();
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

    private void checkEnemiesLeft()
    {
        int enemiesLeft = GameObject.FindGameObjectsWithTag("Enemies").Length;
        enemiesLeftText.text = String.Format("Enemies left: {0}", enemiesLeft);
        if (enemiesLeft == 0) Victory();
    }

    private void checkHighScore()
    {
        int curHighScore = PlayerPrefs.GetInt("highscore");
        if (curHighScore < score) PlayerPrefs.SetInt("highscore", score);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        checkHighScore();
        Time.timeScale = 0;
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
        checkHighScore();
        Time.timeScale = 0;
    }

    public void SetPause(bool value)
    {
        isPaused = value;
        pausePanel.SetActive(value);
        backgroundMusic.volume = (value) ? .2f : .5f;
        Time.timeScale = (value) ? 0 : 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
