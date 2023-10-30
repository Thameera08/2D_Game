using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    private bool isPaused = false;
    private int originalSceneIndex;
    private Vector3 playerPosition;

    private void Start()
    {
        originalSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void MoveToSettings()
    {
        if (!isPaused)
        {
            // Pause the game
            TogglePause();

            // Save the player's position before moving to settings
            playerPosition = transform.position; // Assuming you're controlling the player's position
        }
        
        // Load the settings scene
        SceneManager.LoadScene("Settings");
    }

    public void Resume()
    {
        if (isPaused)
        {
            // Unpause the game
            TogglePause();
            
            // Move the player back to where they left off
            transform.position = playerPosition;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(originalSceneIndex);
        // Make sure to reset any game-specific variables or state if needed
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1; // Unpause the game
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0; // Pause the game by setting time scale to 0
            isPaused = true;
        }
    }
}
