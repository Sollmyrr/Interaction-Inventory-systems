using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public static PlayerInventory Instance;
    public static InventorySlotHolder InventorySlotHolder;

    public List<ItemSO> itemList = new List<ItemSO>();

    public delegate void SendItemToUI(ItemSO item);
    public SendItemToUI itemSender; 
    
    public delegate void SendItemToUIToRemove(ItemSO item);
    public SendItemToUIToRemove itemRemover;

    [SerializeField] GameObject inventory;
    [SerializeField] bool isInventoryEnabled;
    // playerinventory.instance.itemlist.contains(requiredItem);

    private void Awake()
    {
        if(Instance != null)
        {
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            isInventoryEnabled = !isInventoryEnabled;
        if (isInventoryEnabled)
        {
            inventory.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            inventory.SetActive(false);
            Cursor.visible = false;
        }
    }

    public void AddItem(ItemSO item)
    {
        itemList.Add(item);                     // Dodawanie do listy.
        itemSender(item);                       // Przesłanie itemu delegatem w celu poinformowania GUI.
    }

    public void RemoveItem(ItemSO item)
    {
        itemList.Remove(item);
        //InventorySlotHolder.CleanSlot(item);
        itemRemover(item);
    }

    private void OnApplicationQuit()
    {
        itemList.Clear();
    }
}
