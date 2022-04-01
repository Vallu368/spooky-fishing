using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public Animator anim;

    public bool isFishing = false;
    public bool waitingForFish = false;
    public bool gotFish = false;
    public bool finishedFishing = false;

    public bool caughtFish = false;

    public int i = 0;
    public int wait = 0;
    public int catchFishTimer = 0;

    private int nextUpdate = 1;



    public CameraMovement cameraMovement;
    public GameObject test;
    public GameObject fish;
    public FishScript fishScript;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }

        if (Input.GetKey("space") && cameraMovement.lookDown == true && isFishing == false) //alottaa kalastuksen jos katot alas ja et oo kalastamassa jo
        {
            Debug.Log("started fishing"!);
            anim.SetBool("startedFishing", true);
            anim.SetBool("stoppedFishing", false);

            isFishing = true;
            waitingForFish = true;
            
        }
        if (Input.GetKey("space") && gotFish && cameraMovement.lookDown) //ottaa kalan kiinni
        {
            CatchFish();
        }
        if (catchFishTimer >= 10) //jos et paina space menetät kalan
        {
            MissedFish();
        }




        void UpdateEverySecond()
        {
            if (isFishing) // kalastus tapahtuu 
            {
                Fish();
            }
            if (gotFish) //aloittaa ajastimen kalan menettämiseen
            {
                catchFishTimer++;
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

        }

        void Fish()
        {
            if (waitingForFish) 
            {
                wait++;
            }

            bool randomNumber = false; 
            
            if (wait >= 10)
            {
                randomNumber = true; //kun on oottanut 10 sekunttia pysty alkaan saamaan kalaa
            }
            if (randomNumber)
            {
                i = Random.Range(0, 5);  //aluksi kattoo 0 - 50 numeroista
            }

            if (wait >= 40 && randomNumber)
            {
                i = Random.Range(0, 5); //jos menee yli 40s niin 0 - 5
            }

            if (i == 1) //random numero on 1 = saat kalan
            {
                anim.SetBool("caughtFish", true);
                Debug.Log("fish!!");
                fishScript.SpawnRandomPrefab();
                gotFish = true;
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
            anim.SetBool("stoppedFishing", true);
            anim.SetBool("startedFishing", false);
            anim.SetBool("caughtFish", false);
            Debug.Log("caught fish!");
            caughtFish = true;
            fishScript.SetGameObjectActive();
           // fish.transform.position = new Vector3(0f, 0.5f, 2f);
            gotFish = false;
            finishedFishing = true;
        }
        void MissedFish()
        {
            anim.SetBool("stoppedFishing", true);
            anim.SetBool("startedFishing", false);
            Debug.Log("missed fish!");
            gotFish = false;
            catchFishTimer = 0;
            finishedFishing = true;
        }
    }
}
