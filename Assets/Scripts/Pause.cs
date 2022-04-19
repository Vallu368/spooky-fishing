using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GlobalGameState.instance.isInventoryOpen && !GlobalGameState.instance.isGameOver)
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else PauseGame();
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        GlobalGameState.instance.Resume();
        isGamePaused = false;
        GlobalGameState.instance.isGamePaused = false;
    }
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        GlobalGameState.instance.Stop();
        isGamePaused = true;
        GlobalGameState.instance.isGamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");
    }
}
