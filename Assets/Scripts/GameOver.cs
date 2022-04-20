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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restarted");
    }

    public void MainMenu()
    {
        GlobalGameState.instance.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void GameEnded()
    {
        GlobalGameState.instance.Stop();
        GlobalGameState.instance.isGameOver = true;
    }
}
