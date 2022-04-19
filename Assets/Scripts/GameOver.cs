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
        GlobalGameState.instance.ResetGame();
        isPlayerDead = false;
        SceneManager.LoadScene("Main Scene");
        Debug.Log("restarted");
    }

    public void MainMenu()
    {
        isPlayerDead = false;
        GlobalGameState.instance.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void GameEnded()
    {
        GlobalGameState.instance.Stop();
        GlobalGameState.instance.isGameOver = true;
    }
}
