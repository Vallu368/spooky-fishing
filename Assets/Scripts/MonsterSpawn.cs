using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject Marko;
    public GameObject Kakkonen;
    public GameObject[] spawnPoints;
    private int nextUpdate = 1;
    public int nextSpawn = 0;
    public int nextSpawnTimer = 40;
    private MonsteriKakkonen kakkonenScript;
    private markoscript markoScript;
    public GameOver go;
    public bool canSpawn = false;
    public int i;

    

    public bool canSpawnKakkonen = false;
    public bool canSpawnMarko = false;

    public int index;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i = Random.Range(0, 2);
        if (GlobalGameState.instance.progression == 2)
        {
            nextSpawnTimer = nextSpawnTimer - 10;
        }
        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }

        index = Random.Range(0, spawnPoints.Length);

        if (nextSpawn >= nextSpawnTimer) //15 -> 45
        {
            canSpawn = true;
            if (GlobalGameState.instance.progression == 1)
            {
                canSpawnMarko = true;
            }
            if (GlobalGameState.instance.progression == 2)
            {

                canSpawnKakkonen = true;
                canSpawnMarko = false;
                
            }
            if (GlobalGameState.instance.progression == 0)
            {
                nextSpawn = 0;
                Debug.Log("not spawning anyone");
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnKakkonen();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnMarko();
        }



    }
    void UpdateEverySecond()
    {

        nextSpawn++;
        if (canSpawnKakkonen)
        {
            SpawnRandom();
        }
        if (canSpawnMarko)
        {
            SpawnMarko();
        }
    }

    void SpawnKakkonen()
    {
        var mon = Instantiate(Kakkonen, spawnPoints[index].transform);
        //mon.transform.localRotation = spawnPoints[index].transform.rotation;
        mon.SetActive(true);
        canSpawnKakkonen = false;
        kakkonenScript = mon.GetComponent<MonsteriKakkonen>();
        kakkonenScript.WhichSide(spawnPoints[index].tag);
        nextSpawn = 0;
        canSpawn = false;
        
    }

    void SpawnMarko()
    {
        var mon = Instantiate(Marko, spawnPoints[index].transform);
        //mon.transform.localRotation = spawnPoints[index].transform.rotation;
        mon.SetActive(true);
        canSpawnMarko = false;
        markoScript = mon.GetComponent<markoscript>();
        markoScript.WhichSide(spawnPoints[index].tag);
        nextSpawn = 0;
        canSpawn = false;

    }

    void SpawnRandom()
    {
        
        if (i == 0)
        {
            var mon = Instantiate(Marko, spawnPoints[index].transform);
            //mon.transform.localRotation = spawnPoints[index].transform.rotation;
            mon.SetActive(true);
            canSpawnMarko = false;
            canSpawnKakkonen = false;
            markoScript = mon.GetComponent<markoscript>();
            markoScript.WhichSide(spawnPoints[index].tag);
            nextSpawn = 0;
        }
        else
        {
            var mon = Instantiate(Kakkonen, spawnPoints[index].transform);
            //mon.transform.localRotation = spawnPoints[index].transform.rotation;
            mon.SetActive(true);
            canSpawnKakkonen = false;
            kakkonenScript = mon.GetComponent<MonsteriKakkonen>();
            kakkonenScript.WhichSide(spawnPoints[index].tag);
            nextSpawn = 0;
        }
    }
}
