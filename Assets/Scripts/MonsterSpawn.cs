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
    private MonsteriKakkonen kakkonenScript;
    private markoscript markoScript;
    public GameOver go;

    public bool canSpawnKakkonen = false;
    public bool canSpawnMarko = false;

    public int index;
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

        index = Random.Range(0, spawnPoints.Length);

        if (nextSpawn == 45) //15 -> 45
        {
            canSpawnKakkonen = true;
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
            SpawnKakkonen();
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

    }


    void KakkonenOrMarko()
    {
        int i = Random.Range(0, 2);
        if (i == 1)
        {
            Debug.Log("marko");
        }
        else Debug.Log("kakkonen");
    }
}
