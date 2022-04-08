using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markoscript : MonoBehaviour
{
    public bool isLightOn;
    MeshRenderer rend;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        if (isLightOn)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }


    }
}
