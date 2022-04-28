using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineHolder : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(lineSequence());
    }

    private IEnumerator lineSequence()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Deactivate();
            transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitUntil(()=> transform.GetChild(i).GetComponent<CutsceneLine>().finished);
        }
        gameObject.SetActive(false);
        SceneManager.LoadScene("Main Scene");
    }

    private void Deactivate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
