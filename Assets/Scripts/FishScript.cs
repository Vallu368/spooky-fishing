using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
//    public GameObject[] fishes;
    public FishableItem[] fishes;
    public int i = 0;
    public Fishing fishing;
    public int index = 0;
    public InventoryManager inventory;

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
        Destroy(fish, 2);


        
    }

    public void SetGameObjectActive()
    {
        gameObject.SetActive(true);
    }

    public void CaughtFish()
    {
        animator.Play("fish up");
        inventory.RefreshUI();
        inventory.Add(fishes[index]);
    }
}
