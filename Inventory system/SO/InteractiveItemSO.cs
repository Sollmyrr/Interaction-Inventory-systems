using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "default item", menuName = "Inventory system/Items/Interactive Item")]
public class InteractiveItemSO : ItemSO
{
    // partOf;
    //public bool multiplyUsage;
    
    public void Awake()
    {
        type = ItemType.INTERACTIVE;
    }
}
