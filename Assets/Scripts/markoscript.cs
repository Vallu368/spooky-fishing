using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markoscript : MonoBehaviour
{
    public bool isLightOn;
    MeshRenderer rend;

    private bool isPlayerAlive = true;

    public CameraMovement cam;
    public GameObject Marko;
    public GameObject gameOverScreen;
    private GameOver gameOverScript;
    public GameObject gameOverCanvas;

    public bool leftSide = false;
    public bool rightSide = false;
    public bool front = false;
    public bool backRight = false;
    public bool backLeft = false;

    private int nextUpdate = 1;

    public bool playerNoticed = false;

    public int timer = 0;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        gameOverScript = gameOverCanvas.GetComponent<GameOver>();
    }


    void Update()
    {
        if (!GlobalGameState.instance.isGameOver)
        {
            if (isLightOn)
            {
                rend.enabled = true;
            }
            else
            {
                rend.enabled = false;
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
            }
            else if (backLeft) //takavasen
            {
                LookBackLeft();
            }
            else if (backRight) //takaoikee
            {
                LookBackRight();
            }


            if (Time.time >= nextUpdate)
            {

                nextUpdate = Mathf.FloorToInt(Time.time) + 1;
                UpdateEverySecond();
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

    private void PlayerDies()
    {
        if (isPlayerAlive)
        {
            isPlayerAlive = false;
            gameOverScript.GameEnded();
            gameOverScreen.SetActive(true);
            GameObject.Find("Player").GetComponentInChildren<InventoryManager>().enabled = false;
            GameObject.Find("Canvas").GetComponent<Pause>().enabled = false;
        }

    }

    private void FadeOut()
    {
        Destroy(Marko);
        Debug.Log("he ded");
    }

    private void LookLeft()
    {
        if (cam.lookLeft)
        {
            playerNoticed = true;       //pelaaja huomattu
        }

        if (playerNoticed && cam.lookLeft && cam.time == 2)         //jos pelaaja on huomattu ja katotaan monsteria p‰in 2sek niin kuollaan
        {
            PlayerDies();
        }

        if (!cam.lookLeft && !isLightOn && cam.time == 5)            //jos k‰‰ntyy pois monsterista ja valot on pois p‰‰lt‰ pari sekkaa niin monsteri katoaa
        {
            FadeOut();
        }
    }

    private void LookRight()
    {
        if (cam.lookRight)
        {
            playerNoticed = true;
        }

        if (playerNoticed && cam.lookRight && cam.time == 2)
        {
            PlayerDies();
        }

        if (!cam.lookRight && !isLightOn && cam.time == 5)
        {
            FadeOut();
        }
    }

    private void LookForward()
    {
        if (cam.lookForward)
        {
            playerNoticed = true;
        }

        if (playerNoticed && cam.lookForward && cam.time == 2)
        {
            PlayerDies();
        }

        if (!cam.lookForward && !isLightOn && cam.time == 5)
        {
            FadeOut();
        }
    }

    private void LookBackLeft()
    {
        if (cam.lookBackLeft)
        {
            playerNoticed = true;
        }

        if (playerNoticed && cam.lookBackLeft && cam.time == 2)
        {
            PlayerDies();
        }

        if (!cam.lookBackLeft && !isLightOn && cam.time == 5)
        {
            FadeOut();
        }
    }

    private void LookBackRight()
    {
        if (cam.lookBackRight)
        {
            playerNoticed = true;
        }

        if (playerNoticed && cam.lookBackRight && cam.time == 2)
        {
            PlayerDies();
        }

        if (!cam.lookBackRight && !isLightOn && cam.time == 5)
        {
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
