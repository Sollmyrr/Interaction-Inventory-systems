using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "default item", menuName = "Inventory system/Items/Utility Item")]
public class UtilityItemSO : ItemSO
{
    public bool multiplyUsage;

    public void Awake()
    {
        type = ItemType.UTILITY;
    }
}
