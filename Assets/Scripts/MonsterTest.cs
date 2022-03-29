using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    public GameObject spooks;
    public bool canSpawn = false;   
    public int i = 0;

    private int nextUpdate = 1;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f"))
        {
            canSpawn = true;
        }
        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }

        if (i == 1)
        {
            i = 0;
            Instantiate(spooks);
            Debug.Log("spawned marko");
            canSpawn = false;
        }

    }

    void UpdateEverySecond()
    {
        if (canSpawn)
        {
            i = Random.Range(0, 10);
        }
    }
}
