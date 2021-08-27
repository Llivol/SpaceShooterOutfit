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
    [SerializeField] private Transform enemyContainer;

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

        if (enemyContainer.childCount == 0) Victory();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
