using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemClass> items = new List<ItemClass>();

    public void Add(ItemClass item)
    {
        items.Add(item);
    }
}
