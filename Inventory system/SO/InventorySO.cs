using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory system/Inventory")]
public class InventorySO : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();

}

[System.Serializable]
public class InventorySlot
{
    public ItemSO item;

    public InventorySlot(ItemSO item)
    {
        this.item = item;
    }
}
