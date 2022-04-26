using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public FishableItem[] fishes;
    public FishableItem checkpoint1;
    public FishableItem checkpoint2;
    public int i = 0;
    public Fishing fishing;
    public int index = 0;
    public InventoryManager inventory;
    public int totalFishForCheckpoint1 = 1;
    public int totalFishForCheckpoint2 = 2;
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
        Destroy(fish, 3);

    }
    public void SpawnCheckpoint1()
    {
        var fish = Instantiate(checkpoint1.prefab, this.transform);
        Destroy(fish, 4);
        
    }

    public void SpawnCheckpoint2()
    {
        var fish = Instantiate(checkpoint2.prefab, this.transform);
        Destroy(fish, 3);
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
        GlobalGameState.instance.totalFishCaught++;
        animator.Play("fish up");
        inventory.RefreshUI();
        inventory.Add(checkpoint1);

    }
}
