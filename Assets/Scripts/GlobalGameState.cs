using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isGamePaused = false;
    public static GlobalGameState instance;
    void Awake() //Make static singleton instance
    {
        if (instance != null)
            GameObject.Destroy(instance);
        else
            instance = this;
        DontDestroyOnLoad(this);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        isGamePaused = true;
    }

    public void ResetGame()
    {
        Unpause();
        isGameOver = false;
    }
}

