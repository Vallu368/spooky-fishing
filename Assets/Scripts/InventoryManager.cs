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

    private void Start()
    {
        inventoryPanel.SetActive(false);
        inventoryOpen = false;
        slots = new GameObject[slotHolder.transform.childCount];
        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

        RefreshUI();
    }

    private void Update()
    {
        if (Input.GetKey("i"))
        {
            inventoryOpen = true;
        }
        if (inventoryOpen)
        {
            inventoryPanel.SetActive(true);
        }
        else inventoryPanel.SetActive(false);
    }


    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemIcon;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }
    public void Add(ItemClass item)
    {
        items.Add(item);
    }
}
