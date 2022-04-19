using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isGamePaused = false;
    public bool isInventoryOpen = false;
    public static GlobalGameState instance;
    void Awake() //Make static singleton instance
    {
        if (instance != null)
            GameObject.Destroy(instance);
        else
            instance = this;
        DontDestroyOnLoad(this);
    }

    public void Stop()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void ResetGame()
    {
        Resume();
        isGamePaused = false;
        isInventoryOpen = false;
        isGameOver = false;
    }
}

