using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steps : MonoBehaviour
{
    private Transform characterTransform;
    private Vector3 lastPosition;
    private int stepCount;
    private bool isWalking;

    [SerializeField] private float stepDistance = 0.5f; // Adjust this value as needed.
    [SerializeField] private Text stepCountText; // Assign a UI Text component to display the step count.

    private void Start()
    {
        characterTransform = transform;
        lastPosition = characterTransform.position;
        stepCount = 0;
        isWalking = false; // Set it to false initially.
    }

    private void Update()
    {
        Vector3 running = characterTransform.position;
        float distanceMoved = Vector3.Distance(running, lastPosition);

        if (distanceMoved >= stepDistance)
        {
            // Character has taken a step.
            if (!isWalking) // To prevent double counting when continuously moving.
            {
                stepCount++;
                isWalking = true;
                stepCountText.text = "Step Count: " + stepCount; // Update the UI Text.
            }
        }
        else
        {
            isWalking = false;
        }

        lastPosition = running;
    }
}
