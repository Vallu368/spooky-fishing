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

    private int nextUpdate = 1;
    private void Start()
    {
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
        if (Input.GetKeyDown("i"))
        {
            if (inventoryOpen == false)
            {
                inventoryPanel.SetActive(true);
                inventoryOpen = true;
            } else
            {
                inventoryPanel.SetActive(false);
                inventoryOpen = false;
            }
        }

        if (inventoryOpen)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;

        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
    }

    private void UpdateEverySecond()
    {

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
