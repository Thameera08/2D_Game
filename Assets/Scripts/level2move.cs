using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level2move : MonoBehaviour
{
    public Text stepCountText; // Reference to the Text component for displaying step count

    public void MoveLevel2()
    {
        int totalStepCount = 0; // Initialize the total step count to 0

        // Find all the GameObjects with the Steps2D script
        Steps2D[] steps2DScripts = FindObjectsOfType<Steps2D>();

        // Iterate through all the Steps2D scripts and add their step counts
        foreach (Steps2D steps2D in steps2DScripts)
        {
            totalStepCount += steps2D.GetStepCount();
        }

        // Update the Score Num text field with the total step count
        if (stepCountText != null)
        {
            stepCountText.text = "Score: " + totalStepCount.ToString("D3");
        }

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
