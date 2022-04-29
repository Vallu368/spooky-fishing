using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class skipButton : MonoBehaviour
{
    public void SkiptoGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Scene");
    }
}
