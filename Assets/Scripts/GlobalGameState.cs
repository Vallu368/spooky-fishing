using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour
{
    public static GlobalGameState instance;

    void Awake() //Make static singleton instance
    {
        if (instance != null)
            GameObject.Destroy(instance);
        else
            instance = this;
        DontDestroyOnLoad(this);
    }

    public void CallGameState()
    {
        Debug.Log("GlobalGameState.instance. can be called from anywhere");
    }
}

