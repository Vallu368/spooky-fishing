using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsteriKakkonen : MonoBehaviour
{
    public CameraMovement cam;
    public GameObject kakkonen;

    public int timer = 0;

    //puoli mihin pit‰‰ kattoa jotta monsteri katoaa
    //sen vois laittaa spawnerista
    public bool leftSide = false;
    public bool rightSide = false;
    public bool front = false;
    public bool backRight = false;
    public bool backLeft = false;

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
            if (cam.lookLeft && cam.time == 10) //playeri kattoi monsteria tarpeeksi kauan
            {
               // Debug.Log("fading");
                FadeOut();

            }
            if (rightSide) //jos pit‰‰ katsoa oikealle
            {
                if (cam.lookRight) //playeri kattoo oikealle
                {
                    playerNoticed = true;
                }
                if (playerNoticed && !cam.lookRight) //jos playeri katsoi oikealle ja k‰‰ntyi pois
                {
                    Debug.Log("you died oof ouch");
                }
                if (cam.lookRight && cam.time == 10) //playeri kattoi monsteria tarpeeksi kauan
                {
                    // Debug.Log("fading");
                    FadeOut();

                }
            }
            if (front) //jos pit‰‰ katsoa eteen
            {
                if (cam.lookForward) //playeri kattoo eteen
                {
                    playerNoticed = true;
                }
                if (playerNoticed && !cam.lookForward) //jos playeri katsoi vasemalle ja k‰‰ntyi pois
                {
                    Debug.Log("you died oof ouch");
                }
                if (cam.lookForward && cam.time == 10) //playeri kattoi monsteria tarpeeksi kauan
                {
                    // Debug.Log("fading");
                    FadeOut();

                }
            }
            if (backLeft) //jos pit‰‰ katsoa takavasemmalle
            {
                if (cam.lookBackLeft) //playeri kattoo takavasemmalle
                {
                    playerNoticed = true;
                }
                if (playerNoticed && !cam.lookBackLeft) //jos playeri katsoi vasemalle ja k‰‰ntyi pois
                {
                    Debug.Log("you died oof ouch");
                }
                if (cam.lookBackLeft && cam.time == 10) //playeri kattoi monsteria tarpeeksi kauan
                {
                    // Debug.Log("fading");
                    FadeOut();

                }
            }
            if (backRight) //jos pit‰‰ katsoa vasemmalle
            {
                if (cam.lookBackRight) //playeri kattoo vasemmalle
                {
                    playerNoticed = true;
                }
                if (playerNoticed && !cam.lookBackRight) //jos playeri katsoi vasemalle ja k‰‰ntyi pois
                {
                    Debug.Log("you died oof ouch");
                }
                if (cam.lookBackRight && cam.time == 10) //playeri kattoi monsteria tarpeeksi kauan
                {
                    // Debug.Log("fading");
                    FadeOut();

                }
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
