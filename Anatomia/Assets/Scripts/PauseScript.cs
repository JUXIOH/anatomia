using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game by setting time scale to 0
            Debug.Log("Game paused");
        }
        else
        {
            Time.timeScale = 1f; // Resume the game by setting time scale to 1
            Debug.Log("Game resumed");
        }
    }
}
