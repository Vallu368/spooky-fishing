using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fishing : MonoBehaviour
{
    [SerializeField] AudioClip siimanKelaus;
    [SerializeField] AudioClip splashSound;

    [SerializeField] private float delayBeforeChange = 3f;
    private float timeElapsed;

    public Animator anim;
    public Animator anim_vapa;

    public GameObject tutorialText;

    public bool isFishing = false;
    public bool waitingForFish = false;
    public bool gotFish = false;
    public bool finishedFishing = false;
    public bool ending = false;
    public int endWait = 0;
    public int checkpointFish = 0;

    public bool caughtFish = false;

    public int i = 0;
    public int wait = 0;
    public int catchFishTimer = 0;

    private int nextUpdate = 1;



    public CameraMovement cameraMovement;
    public GameObject fish;
    public FishScript fishScript;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!gotFish)
        {
            anim_vapa.SetBool("VapaCaughtFish", false);
        }

        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }

        if (GlobalGameState.instance.totalFishCaught >= fishScript.totalFishForCheckpoint1 && GlobalGameState.instance.progression == 0)
        {
            checkpointFish = 1;
        }
        else if (GlobalGameState.instance.totalFishCaught >= fishScript.totalFishForCheckpoint2 && GlobalGameState.instance.progression == 1)
        {
            checkpointFish = 2;
        }
        else if (GlobalGameState.instance.totalFishCaught >= fishScript.HowManyFishesToEnd && GlobalGameState.instance.progression == 2)
        {
            checkpointFish = 3;
        }
        else checkpointFish = 0;

        if (Input.GetKey("space") && cameraMovement.lookDown == true && isFishing == false) //alottaa kalastuksen jos katot alas ja et oo kalastamassa jo
        {
            Debug.Log("started fishing"!);
            anim_vapa.SetBool("VapaStartFishing", true);
            SFX.instance.PlayClip(siimanKelaus, 1f);
            
            
            anim.SetBool("startedFishing", true);
            anim.SetBool("stoppedFishing", false);

            isFishing = true;
            waitingForFish = true;

            if (tutorialText.active)
            {
                tutorialText.SetActive(false);
            }
            
        }
        if (Input.GetKey("space") && gotFish && cameraMovement.lookDown) //ottaa kalan kiinni
        {
            CatchFish();
            SFX.instance.PlayClip(siimanKelaus, 1f);
            anim_vapa.SetBool("VapaStartFishing", false);
        }
        if (catchFishTimer >= 15) //jos et paina space menetät kalan
        {
            MissedFish();
            anim_vapa.SetBool("VapaStartFishing", true);
        }




        void UpdateEverySecond()
        {
            if (isFishing) // kalastus tapahtuu 
            {
                Fish();
            }
            if (gotFish) //aloittaa ajastimen kalan menettämiseen
            {
                SFX.instance.PlayClip(splashSound, 1f);
                catchFishTimer++;
                anim_vapa.SetBool("VapaCaughtFish", true);
            }

            if (finishedFishing == true) //kun kalastus loppuu timeri menee vähän aikaa ennenku voit alottaa uudestaan että se ei ota tuota start fishing inputtia kun otat sen kiinni
            {        
                wait++;
                if (wait >= 3)
                {
                    finishedFishing = false;
                    isFishing = false;
                    caughtFish = false;
                    wait = 0;
                }
            }
            if (ending)
            {
                wait++;
                if (wait > 6f)
                {
                    SceneManager.LoadScene("LoppuCutscene");
                }
            }

        }

        void Fish()
        {
            if (waitingForFish) 
            {
                wait++;
            }

            bool randomNumber = false; 
            
            if (wait >= 5)
            {
                randomNumber = true; //kun on oottanut 55 sekunttia pysty alkaan saamaan kalaa
            }
            if (randomNumber)
            {
                i = Random.Range(0, 40);  //aluksi kattoo 0 - 50 numeroista
            }

            if (wait >= 20 && randomNumber)
            {
                i = Random.Range(0, 5); //jos menee yli 40s niin 0 - 5
            }

            if (i == 1) //random numero on 1 = saat kalan
            {
                if (checkpointFish == 1)
                {
                    anim.SetBool("caughtFish", true);
                    Debug.Log("checkpoint Fish!!");
                    fishScript.SpawnCheckpoint1();
                    gotFish = true;
                }
                if (checkpointFish == 2)
                {
                    anim.SetBool("caughtFish", true);
                    Debug.Log("checkpoint Fish!!");
                    fishScript.SpawnCheckpoint2();
                    gotFish = true;
                }
                if (checkpointFish == 3)
                {
                    anim.SetBool("caughtFish", true);
                    Debug.Log("END!!");
                    fishScript.SpawnEndingFish();
                    gotFish = true;
                    ending = true;
                }
                if (checkpointFish == 0)
                {
                    anim.SetBool("caughtFish", true);
                    Debug.Log("fish!!");
                    fishScript.SpawnRandomPrefab();
                    gotFish = true;
                }
            }

            if (gotFish) //saat kalan kiinni ja kaikki resettaa
            {
                waitingForFish = false;
                randomNumber = false;
                i = 0;
                wait = 0;
            }
        }

        void CatchFish()
        {
            fishScript.DestroyFish();
            anim.SetBool("stoppedFishing", true);
            anim.SetBool("startedFishing", false);
            anim.SetBool("caughtFish", false);
            Debug.Log("caught fish!");
            if (checkpointFish == 1)
            {
                fishScript.CaughtCheckpoint1Fish();

            }
            if (checkpointFish == 2)
            {
                fishScript.CaughtCheckpoint2Fish();
            }
            if (checkpointFish == 0)
            {
                fishScript.CaughtFish();
            }
            if (checkpointFish == 3)
            {
                fishScript.CaughtEndingFish();
                
            }
            caughtFish = true;
            fishScript.SetGameObjectActive();
           // fish.transform.position = new Vector3(0f, 0.5f, 2f);
            gotFish = false;
            finishedFishing = true;
        }
        void MissedFish()
        {
            fishScript.DestroyFish();
            anim.SetBool("stoppedFishing", true);
            anim.SetBool("startedFishing", false);
            Debug.Log("missed fish!");
            gotFish = false;
            catchFishTimer = 0;
            finishedFishing = true;
        }
    }
}
