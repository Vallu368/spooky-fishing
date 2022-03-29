using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public GameObject[] fishes;

    public void SpawnRandomPrefab()
    {
        int index = Random.Range(0, fishes.Length);  //valitsee randomi
        Instantiate(fishes[index], this.transform);
    }
}
