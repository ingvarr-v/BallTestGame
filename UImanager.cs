using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{

    public GameObject ScoreObj, GameOverObj, dark, restartButton, exitButton, startButton, resumeButton, pauseButton;

    private void Awake()
    {
        Time.timeScale = 0;
        startButton.SetActive(true);
        dark.SetActive(false);
        GameOverObj.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
        resumeButton.SetActive(false);
        pauseButton.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        dark.SetActive(true);
        exitButton.SetActive(true);
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        dark.SetActive(false);
        exitButton.SetActive(false);
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startButton.SetActive(false);
        pauseButton.SetActive(true);
    }
}
