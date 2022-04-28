using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    public bool finished { get; private set; }

    protected IEnumerator WriteText(string input, Text textHolder, float delay)//, float delayBetweenLines)
    {
        for(int i = 0; i < input.Length; i++)
        {
            textHolder.text += input[i];
            yield return new WaitForSeconds(delay);
        }

        //yield return new WaitForSeconds(delayBetweenLines); tää ois sekunti versio
        yield return new WaitUntil(() => Input.GetKeyDown("space")); // space painaa nii siirtyy seuraavaan lineen
        finished = true;
    }
}
