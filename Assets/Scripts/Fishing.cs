using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public bool isFishing = false;
    public bool waitingForFish = false;
    public bool gotFish = false;
    public bool finishedFishing = false;

    public int i = 0;
    public int wait = 0;
    public int catchFishTimer = 0;

    private int nextUpdate = 1;


    public CameraMovement cameraMovement;
    public GameObject test;
    void Start()
    {
        test.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }

        if (isFishing == false) //jos ei kalasta tuo laatikko ei näy
        {
            test.SetActive(false);
        }

        if (Input.GetKey("space") && cameraMovement.lookDown == true && isFishing == false) //alottaa kalastuksen jos katot alas ja et oo kalastamassa jo
        {
            Debug.Log("started fishing"!);
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
            test.SetActive(true); 

            bool randomNumber = false; 
            
            if (wait >= 10)
            {
                randomNumber = true; //kun on oottanut 10 sekunttia pysty alkaan saamaan kalaa
            }
            if (randomNumber)
            {
                i = Random.Range(0, 50);  //aluksi kattoo 0 - 50 numeroista
            }

            if (wait >= 40 && randomNumber)
            {
                i = Random.Range(0, 5); //jos menee yli 40s niin 0 - 5
            }

            if (i == 1) //random numero on 1 = saat kalan
            {
                Debug.Log("fish!!");
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
            Debug.Log("caught fish!");
            gotFish = false;
            finishedFishing = true;
        }
        void MissedFish()
        {
            Debug.Log("missed fish!");
            gotFish = false;
            catchFishTimer = 0;
            finishedFishing = true;
        }
    }
}
