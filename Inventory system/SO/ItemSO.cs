using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { UTILITY, INTERACTIVE }
public abstract class ItemSO : ScriptableObject
{
    public Sprite iconGO;
    public ItemType type;
    public string description;
    
    public bool isAllowCombine;
    public int ID;

    //public bool multiplyUsage;
}
