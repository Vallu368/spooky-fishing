using System.Collections;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int itemID;
    public string description;

    public abstract ItemClass GetItem();
    public abstract FishableItem GetFishableItem();
}
