using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private AsyncOperation loadGameSceneAsync;
    private void Start()
    {
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
