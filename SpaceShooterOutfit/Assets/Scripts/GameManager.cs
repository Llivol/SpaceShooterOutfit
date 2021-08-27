using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string SCORE_TEMPLATE = "SCORE: {0}";
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TextMeshProUGUI scoreText;

    public static GameManager Instance = null;

    private int score;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
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

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
