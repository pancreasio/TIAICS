using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameObject instance;
    public Scene currentScene;
    public static int score;
    private int lastPlayedLevelIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
            currentScene = SceneManager.GetActiveScene();
            lastPlayedLevelIndex = currentScene.buildIndex;
            score = 0;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(4);
        currentScene = SceneManager.GetSceneByBuildIndex(4);
    }

    public void Menu()
    {
        score = 0;
        SceneManager.LoadScene(0);
        currentScene = SceneManager.GetSceneByBuildIndex(0);
    }

    public void UpdateCurrent()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetRetryLevel()
    {
        lastPlayedLevelIndex = currentScene.buildIndex;
    }

    public void Retry()
    {
        SceneManager.LoadScene(lastPlayedLevelIndex);
        score = 0;
    }
}