using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level2move : MonoBehaviour
{
    public Text stepCountText; // Reference to the Text component for displaying step count

    // This method is called from the Steps2D script to update the step count
    public void UpdateStepCount(int stepCount)
    {
        // Update the Score Num text field with the total step count
        if (stepCountText != null)
        {
            stepCountText.text = "Score: " + stepCount.ToString("D3");
        }

        // You can optionally store the step count in a variable or perform other actions here.
    }

    public void MoveLevel2()
    {
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
