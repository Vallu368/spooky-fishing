using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public MonsterSpawn mSpawn;
    public FishableItem[] fishes;
    public FishableItem checkpoint1;
    public int i = 0;
    public Fishing fishing;
    public int index = 0;
    public InventoryManager inventory;
    public int totalFishCaught;
    public int totalFishForCheckpoint1 = 2;
    public Animator animator;


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
        index = Random.Range(0, fishes.Length);  //valitsee randomi kalan
        var fish = Instantiate(fishes[index].prefab, this.transform); // spawnaa kalan
        Debug.Log("spawned " + fishes[index].itemName);
        Destroy(fish, 4);

    }
    public void SpawnCheckpoint1()
    {
        Debug.Log("checkpoint 1");
        var fish = Instantiate(checkpoint1.prefab, this.transform);
        Debug.Log("spawned " + checkpoint1.itemName);
        Destroy(fish, 4);
        
    }

    public void SetGameObjectActive()
    {
        gameObject.SetActive(true);
    }

    public void CaughtFish()
    {
        totalFishCaught++;
        animator.Play("fish up");
        inventory.RefreshUI();
        inventory.Add(fishes[index]);
    }
    public void CaughtCheckpoint1Fish()
    {
        totalFishCaught++;
        animator.Play("fish up");
        inventory.RefreshUI();
        inventory.Add(checkpoint1);
        
    }
}
