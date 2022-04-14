using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsteriKakkonen : MonoBehaviour
{
    public CameraMovement cam;
    public GameObject kakkonen;
    public GameObject gameOverScreen;
    private GameOver gameOverScript;
    public GameObject gameOverCanvas;

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
        gameOverScript = gameOverCanvas.GetComponent<GameOver>();
    }
    private void Update()
    {
        if (timer == 30) // jos timer menee tuohon ja et oo kattonu siihen niin game over
        {
            PlayerDies();
        }
        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }


        if (leftSide) //jos pit‰‰ katsoa vasemmalle
        {
            LookLeft();
        }
        else if (rightSide) //pit‰‰ kattoo oikeelle
        {
            LookRight();
        }
        else if (front) //pit‰‰ kattoo eteen
        {
            LookForward();
        } else if (backLeft) //takavasen
        {
            LookBackLeft();
        } else if (backRight) //takaoikee
        {
            LookBackRight();
        }
    }
    private void UpdateEverySecond()
    {
        if (!playerNoticed)
        {
            timer++;
        }
    }

    private void PlayerDies()
    {
        gameOverScreen.SetActive(true);
        gameOverScript.GameEnded();
    }
    private void FadeOut()
    {
        Destroy(kakkonen); //fadeout t‰nne

       
    }
    private void LookLeft()
    {
        if (cam.lookLeft) //playeri kattoo vasemmalle
        {
            playerNoticed = true;
        }
        if (playerNoticed && !cam.lookLeft) //jos playeri katsoi vasemalle ja k‰‰ntyi pois
        {
            PlayerDies();
        }
        if (cam.lookLeft && cam.time == 3) //playeri kattoi monsteria tarpeeksi kauan
        {
            // Debug.Log("fading");
            FadeOut();

        }
    }
    private void LookRight()
    {
        if (cam.lookRight) //playeri kattoo oikeelle
        {
            playerNoticed = true;
        }
        if (playerNoticed && !cam.lookRight) //jos playeri katsoi vasemalle ja k‰‰ntyi pois
        {
            PlayerDies();
        }
        if (cam.lookRight && cam.time == 3) //playeri kattoi monsteria tarpeeksi kauan
        {
            // Debug.Log("fading");
            FadeOut();

        }
    }
    private void LookForward()
    {
        if (cam.lookForward) //playeri kattoo vasemmalle
        {
            playerNoticed = true;
        }
        if (playerNoticed && !cam.lookForward) //jos playeri katsoi vasemalle ja k‰‰ntyi pois
        {
            PlayerDies();
        }
        if (cam.lookForward && cam.time == 3) //playeri kattoi monsteria tarpeeksi kauan
        {
            // Debug.Log("fading");
            FadeOut();

        }
    }
    private void LookBackLeft()
    {
        if (cam.lookBackLeft) //playeri kattoo vasemmalle
        {
            playerNoticed = true;
        }
        if (playerNoticed && !cam.lookBackLeft) //jos playeri katsoi vasemalle ja k‰‰ntyi pois
        {
            PlayerDies();
        }
        if (cam.lookBackLeft && cam.time == 3) //playeri kattoi monsteria tarpeeksi kauan
        {
            // Debug.Log("fading");
            FadeOut();

        }
    }
    private void LookBackRight()
    {
        if (cam.lookBackRight) //playeri kattoo vasemmalle
        {
            playerNoticed = true;
        }
        if (playerNoticed && !cam.lookBackRight) //jos playeri katsoi vasemalle ja k‰‰ntyi pois
        {
            PlayerDies();
            Debug.Log("you died oof ouch");
        }
        if (cam.lookBackRight && cam.time == 3) //playeri kattoi monsteria tarpeeksi kauan
        {
            // Debug.Log("fading");
            FadeOut();

        }
    }

        public void WhichSide(string tag)
    {
        Debug.Log(tag);

        if (tag == "leftSide")
        {
            leftSide = true;
        } else if (tag == "rightSide")
        {
            rightSide = true;
        } else if (tag == "forward")
        {
            front = true;
        } else if (tag == "backLeft")
        {
            backLeft = true;
        } else if (tag == "backRight")
        {
            backRight = true;
        }
    }

}
