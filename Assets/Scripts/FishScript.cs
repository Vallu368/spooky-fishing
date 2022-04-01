using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public GameObject[] fishes;
    public int i = 0;
    public Fishing fishing;


    private void Update()
    {
        if (fishing.caughtFish)
        {
            
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);

    }
    public void SpawnRandomPrefab()
    {
        int index = Random.Range(0, fishes.Length);  //valitsee randomi kalan
        var fish = Instantiate(fishes[index], this.transform); // spawnaa kalan

        Destroy(fish, 2);


        
    }

    public void SetGameObjectActive()
    {
        gameObject.SetActive(true);
    }

}
