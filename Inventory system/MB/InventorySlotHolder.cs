using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotHolder : MonoBehaviour
{
    PlayerInventory inventory;
    private Slot[] slotTable;
    void Start()
    {
        inventory = PlayerInventory.Instance;                       // hashowanie instance.
        inventory.itemSender += AddItemToSLot;                      // Subskrybcja delegatu.
        inventory.itemRemover += CleanSlot;                        // Subskrybcja delegatu.
        slotTable = GetComponentsInChildren<Slot>();                
        gameObject.SetActive(false);
    }

    // Obsługa delegatu:
    private void AddItemToSLot(ItemSO item)
    {
        for (int i = 0; i < slotTable.Length; i++)
        {
            if (i < inventory.itemList.Count )
            {
                if(slotTable[i].isEmpty)
                {
                    slotTable[i].itemSO = item;
                    slotTable[i].transform.GetChild(0).gameObject.SetActive(true);
                    slotTable[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.iconGO;
                }
                slotTable[i].isEmpty = false;
            }
        }
    }

    public void CleanSlot(ItemSO item)
    {
        for (int i = slotTable.Length - 1; i >= 0; i--)
        {
            print(slotTable[i].itemSO);

            if (slotTable[i].itemSO == item)
            {
                slotTable[i].itemSO = null;
                slotTable[i].transform.GetChild(0).gameObject.SetActive(false);
                slotTable[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = null;
            }
            slotTable[i].isEmpty = true;
        }
    }
}
