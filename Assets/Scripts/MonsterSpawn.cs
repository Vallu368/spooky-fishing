using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject Marko;
    public GameObject Kakkonen;
    public GameObject[] SpawnPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
