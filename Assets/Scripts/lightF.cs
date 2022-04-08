using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightF : MonoBehaviour
{
    [SerializeField] GameObject Flashlight;
    [SerializeField] GameObject EnemyRip;
    private bool FlashlightActive = true;
    markoscript marko;


    void Start()
    {
        Flashlight.gameObject.SetActive(true);
        marko = EnemyRip.GetComponent<markoscript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightActive == false)
            {
                Flashlight.gameObject.SetActive(true);
                FlashlightActive = true;
                marko.isLightOn = true;
            }
            else
            {
                Flashlight.gameObject.SetActive(false);
                FlashlightActive = false;
                marko.isLightOn = false;
            }
        }
    }
}
