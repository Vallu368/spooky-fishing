using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "new Fishable Item", menuName = "Fishable Item")]
public class FishableItem : ItemClass
{
    public ItemType itemType;
    public GameObject prefab;
    public enum ItemType
    {
        fish,
        item
    }
    public override ItemClass GetItem() { return this; }
    public override FishableItem GetFishableItem() { return this; }
}
