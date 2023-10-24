using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steps2D : MonoBehaviour
{
    private Transform characterTransform;
    private Vector2 currentPosition;
    private int stepCount;
    private bool isRunning;

    [SerializeField] private float stepDistance = 0.5f;
    [SerializeField] private Text stepCountText;

    private bool isJumping;

    private void Start()
    {
        characterTransform = transform;
        currentPosition = characterTransform.position;
        stepCount = 0;
        isRunning = false;
        isJumping = false;
    }

    private void Update()
    {
        Vector2 lastPosition = characterTransform.position;
        float distanceMoved = Vector2.Distance(lastPosition, currentPosition);

        // Check if the player is not jumping to count steps.
        if (!isJumping)
        {
            if (distanceMoved >= stepDistance)
            {
                // Character has taken a step.
                if (!isRunning)
                {
                    stepCount++;
                    // Update step count with leading zeros
                    stepCountText.text = "Step Count: " + stepCount.ToString("D3");
                }
            }
            else
            {
                isRunning = false;
            }
        }

        currentPosition = lastPosition;
    }

    // Method to handle jumping detection.
    public void Run()
    {
        isJumping = true;
    }

    // Method to handle landing detection.
    public void Jump()
    {
        isJumping = false;
    }
}
