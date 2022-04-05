using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightF : MonoBehaviour
{
    [SerializeField] GameObject Flashlight;
    private bool FlashlightActive = true;


    void Start()
    {
        Flashlight.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightActive == false)
            {
                Flashlight.gameObject.SetActive(true);
                FlashlightActive = true;
                Debug.Log("OnOff");
            }
            else
            {
                Flashlight.gameObject.SetActive(false);
                FlashlightActive = false;
            }
        }
    }
}
