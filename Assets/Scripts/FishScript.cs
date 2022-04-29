using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishScript : MonoBehaviour
{


    public List<FishableItem> fishes;
    public List<FishableItem> checkpoint1Fishes;
    public List<FishableItem> checkpoint2Fishes;
    public FishableItem checkpoint1;
    public FishableItem checkpoint2;
    public FishableItem masterFish;
    public int HowManyFishesToEnd;
    public int i = 0;
    public Fishing fishing;
    public int index = 0;
    public InventoryManager inventory;
    public int totalFishForCheckpoint1 = 1;
    public int totalFishForCheckpoint2 = 2;
    public Animator animator;
    private GameObject test; //kala jonka se spawnaa menee tähän että sen voi poistaa
    public bool repeat;
    public int spawnedFishIndex = 0;
    public int count1 = 0;
    public int count2 = 0;
    public int count3 = 0;


    private void Update()
    {
        count1 = fishes.Count;
        count2 = checkpoint1Fishes.Count;
        count3 = checkpoint2Fishes.Count;
        
        if (fishing.caughtFish)
        {
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);

    }
    public void SpawnRandomPrefab()
    {
        if (GlobalGameState.instance.progression == 0)
        {
            index = Random.Range(0, count1);
            //valitsee randomi kalan
            var fish = Instantiate(fishes[index].prefab, this.transform); // spawnaa kalan
            repeat = fishes[index].canSpawnMultipleTimes;
            test = fish;
            spawnedFishIndex = index;
        }
        if (GlobalGameState.instance.progression == 1)
        {
            index = Random.Range(0, count2);
            //valitsee randomi kalan
            var fish = Instantiate(checkpoint1Fishes[index].prefab, this.transform); // spawnaa kalan
            repeat = checkpoint1Fishes[index].canSpawnMultipleTimes;
            test = fish;
            spawnedFishIndex = index;
        }
        if (GlobalGameState.instance.progression == 2)
        {
            if (GlobalGameState.instance.totalFishCaught >= HowManyFishesToEnd)
            {
                var fish = Instantiate(masterFish.prefab, this.transform);
                test = fish;
                SceneManager.LoadScene("LoppuCutscene");

            }
            else
            {
                index = Random.Range(0, count3);
                //valitsee randomi kalan
                var fish = Instantiate(checkpoint2Fishes[index].prefab, this.transform); // spawnaa kalan
                repeat = checkpoint2Fishes[index].canSpawnMultipleTimes;
                test = fish;
                spawnedFishIndex = index;
            }
        }
        if (repeat)
        {
            Debug.Log("its a normal fish :D");
        }

        if (!repeat)
        {
            Debug.Log("oh no spooky");
        }
       
        
        

    }
    public void DestroyFish()
    {
        Destroy(test, 3);
    }
    public void SpawnCheckpoint1()
    {
        var fish = Instantiate(checkpoint1.prefab, this.transform);
        test = fish;


    }

    public void SpawnCheckpoint2()
    {
        var fish = Instantiate(checkpoint2.prefab, this.transform);
        test = fish;
    }

    public void SetGameObjectActive()
    {
        gameObject.SetActive(true);
    }


    public void CaughtFish()
    {
        GlobalGameState.instance.totalFishCaught++;
        animator.Play("fish up");
        inventory.RefreshUI();
        if (GlobalGameState.instance.progression == 0)
        {
            inventory.Add(fishes[index]);
        }
        if (GlobalGameState.instance.progression == 1)
        {
            inventory.Add(checkpoint1Fishes[index]);
        }
        if (!repeat)
        {
            Debug.Log("removing item");
            if (GlobalGameState.instance.progression == 1)
            {
                checkpoint1Fishes.Remove(checkpoint1Fishes[spawnedFishIndex]);
                Debug.Log("removed " + checkpoint1Fishes[spawnedFishIndex].itemName);
            }
            if (GlobalGameState.instance.progression == 2)
            {
                checkpoint2Fishes.Remove(checkpoint2Fishes[spawnedFishIndex]);
                Debug.Log("removed " + checkpoint2Fishes[spawnedFishIndex].itemName);
            }
        }

    }
    public void CaughtCheckpoint1Fish()
    {
        GlobalGameState.instance.totalFishCaught++;
        animator.Play("fish up");
        inventory.RefreshUI();
        inventory.Add(checkpoint1);
    }
    public void CaughtCheckpoint2Fish()
    {        GlobalGameState.instance.totalFishCaught++;
        animator.Play("fish up");
        inventory.RefreshUI();
        inventory.Add(checkpoint2);

    }
}
