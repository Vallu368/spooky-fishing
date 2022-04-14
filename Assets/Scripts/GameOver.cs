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
        isPlayerDead = false;
        SceneManager.LoadScene("Main Scene");
        Debug.Log("restarted");
    }

    public void MainMenu()
    {
        isPlayerDead = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameEnded()
    {
        isPlayerDead = true;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I))
        {
            if (isPlayerDead)
            {
                isPlayerDead=false;
                ReloadScene();
            }
        }
    }
}
