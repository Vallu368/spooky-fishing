using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taustaÄänet : MonoBehaviour
{
    [SerializeField] AudioSource yleinen;
    [SerializeField] AudioSource kakkosen;

    void Start()
    {
        yleinen.enabled = true;
        kakkosen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalGameState.instance.progression == 2)
        {
            yleinen.enabled = false;
            kakkosen.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            GlobalGameState.instance.progression++;
            Debug.Log("progression increased to "+GlobalGameState.instance.progression);
        }
    }
}
