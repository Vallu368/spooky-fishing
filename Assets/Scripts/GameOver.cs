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

        Debug.Log("restarted");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {

    }
}
