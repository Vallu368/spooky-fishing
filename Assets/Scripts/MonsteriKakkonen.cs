using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsteriKakkonen : MonoBehaviour
{
    public CameraMovement cam;
    public GameObject kakkonen;

    public int phase = 0;
    public int timer = 0;

    //puoli mihin pit‰‰ kattoa jotta monsteri katoaa
    //sen vois laittaa spawnerista
    public bool leftSide = false;
    public bool rightSide = false;
    public bool front = false;
    public bool back = false;

    public int fadeSpeed;

    private int nextUpdate = 1;

    public bool playerNoticed = false;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (timer == 30) // jos timer menee tuohon ja et oo kattonu siihen niin game over
        {
            Debug.Log("you died oof ouch");
        }
        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }


        if (leftSide) //jos pit‰‰ katsoa vasemmalle
        {
            if (cam.lookLeft) //playeri kattoo vasemmalle
            {
                playerNoticed = true; 
            }
            if (playerNoticed && !cam.lookLeft) //jos playeri katsoi vasemalle ja k‰‰ntyi pois
            {
                Debug.Log("you died oof ouch");
            }
            if (cam.lookLeft && cam.time == 10) //playeri kattoi monsteria tarpeeksi kauank
            {
                Debug.Log("fading");
                FadeOut();

            }
        }
    }
    private void UpdateEverySecond()
    {
        if (!playerNoticed)
        {
            timer++;
        }
    }

    private void FadeOut()
    {
        Destroy(kakkonen); //fadeout t‰nne

       
    }

}
