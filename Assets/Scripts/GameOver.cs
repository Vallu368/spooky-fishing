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
        SceneManager.LoadScene("Main Scene");
        Time.timeScale = 1;

        Debug.Log("restarted");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameEnded()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I))
        {
                ReloadScene();
        }
    }
}
