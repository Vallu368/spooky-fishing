using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{

    [SerializeField] AudioClip secondBG;

    public List<FishableItem> fishes;
    public FishableItem checkpoint1;
    public FishableItem checkpoint2;
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
    public int count = 0;


    private void Update()
    {
        count = fishes.Count;
        
        if (fishing.caughtFish)
        {
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);

    }
    public void SpawnRandomPrefab()
    {
        index = Random.Range(0, count);
        //valitsee randomi kalan
        var fish = Instantiate(fishes[index].prefab, this.transform); // spawnaa kalan
        repeat = fishes[index].canSpawnMultipleTimes;
        if (repeat)
        {
            Debug.Log("its a normal fish :D");
        }

        if (!repeat)
        {
            Debug.Log("oh no spooky");
        }
        spawnedFishIndex = index;
        test = fish;
        

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
        inventory.Add(fishes[index]);
        if (!repeat)
        {
            fishes.Remove(fishes[spawnedFishIndex]);
            Debug.Log("removed " +  fishes[spawnedFishIndex].itemName);
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
    {
        AudioSource.PlayClipAtPoint(secondBG, Camera.main.transform.position);
        GlobalGameState.instance.totalFishCaught++;
        animator.Play("fish up");
        inventory.RefreshUI();
        inventory.Add(checkpoint1);

    }
}
