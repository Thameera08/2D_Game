using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    private bool isPaused = false;
    private int originalSceneIndex;

    private void Start()
    {
        originalSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void MoveToSettings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void Resume()
    {
        if (isPaused)
        {
            Time.timeScale = 1; // Unpause the game
            isPaused = false;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Time.timeScale = 0; // Pause the game by setting time scale to 0
            isPaused = true;
        }
    }
}
