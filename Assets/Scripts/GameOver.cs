using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool isPlayerDead = false;

    [SerializeField] GameObject gameOver;

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Scene");
        isPlayerDead = false;
        Debug.Log("restarted");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        isPlayerDead = false;
    }

    public void GameEnded()
    {
        Time.timeScale = 0;
        isPlayerDead = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I))
        {
            if (isPlayerDead)
            {
                ReloadScene();
                isPlayerDead=false;
            }
        }
    }
}
