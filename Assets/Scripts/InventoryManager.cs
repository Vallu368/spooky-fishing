using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private List<ItemClass> items = new List<ItemClass>();

    private GameObject[] slots;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private bool inventoryOpen = false;
    public int itemsFishedTotal = 0;

    public GameObject pilkkivapa;
    public GameObject spawnManager;
    public FishScript fishScript;
    public MonsterSpawn monsterSpawn;

    private void Start()
    {
        spawnManager.GetComponent<MonsterSpawn>();
        pilkkivapa.GetComponentInChildren<FishScript>();
        inventoryPanel.SetActive(false);
        inventoryOpen = false;
        slots = new GameObject[slotHolder.transform.childCount];
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        Debug.Log(slotHolder.transform.childCount);

        RefreshUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown("i") && !GlobalGameState.instance.isGameOver && !GlobalGameState.instance.isGamePaused)
        {
            if (inventoryOpen == false)
            {
                inventoryPanel.SetActive(true);
                inventoryOpen = true;
                GlobalGameState.instance.Stop();
                GlobalGameState.instance.isInventoryOpen = true;
            } else
            {
                inventoryPanel.SetActive(false);
                inventoryOpen = false;
                GlobalGameState.instance.Resume();
                GlobalGameState.instance.isInventoryOpen = false;
            }
        }
        if (items.Contains(fishScript.checkpoint1) & GlobalGameState.instance.progression == 0) {
            GlobalGameState.instance.progression = 1;
            Debug.Log("marko can spawn");
            
        }
        if (items.Contains(fishScript.checkpoint2) & GlobalGameState.instance.progression == 1)
        {
            GlobalGameState.instance.progression = 2;
            Debug.Log("kakkonen can spawn");

        }
        if (GlobalGameState.instance.progression >= 1 && !items.Contains(fishScript.checkpoint1))
        {
            Add(fishScript.checkpoint1);
            
        }
        if (GlobalGameState.instance.progression >= 2 && !items.Contains(fishScript.checkpoint2))
        {
            Add(fishScript.checkpoint2);
        }

    }



    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemIcon;
                slots[i].transform.GetChild(0).GetComponent<Button>().descriptionText = items[i].description;
                slots[i].transform.GetChild(0).GetComponent<Button>().sprite = items[i].itemIcon;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(0).GetComponent<Button>().descriptionText = "oh fuck";
                slots[i].transform.GetChild(0).GetComponent<Button>().sprite = null;
            }
        }
    }
    public void Add(ItemClass item)
    {
        itemsFishedTotal++;
        if (!items.Contains(item))
        {
            items.Add(item);
            Debug.Log("add item");
            RefreshUI();
        } else
        {
            Debug.Log("didnt add item");
        }
        
    }
}
