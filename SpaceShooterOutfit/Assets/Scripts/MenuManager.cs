using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    private AsyncOperation loadGameSceneAsync;
    private void Start()
    {
        highScoreText.text = String.Format("High Score: {0}", PlayerPrefs.GetInt("highscore"));
        loadGameSceneAsync = SceneManager.LoadSceneAsync("GameScene");
        loadGameSceneAsync.allowSceneActivation = false;
    }

    public void Play()
    {
        loadGameSceneAsync.allowSceneActivation = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
