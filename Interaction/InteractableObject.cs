using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public int ID;
    //public InteractionType type;
    public string description;
    public bool isActive;
    public bool isRequiredItem;

    public ItemSO requiredItem = null;

    public abstract void Interact();
    public ItemSO GetRequiredItem() => requiredItem;
    public int GetInteractableObjectID() => ID;

    public void SetObjectAsActivated()
    {
        isActive = false;
    }



}

//różnica getter, =>, funkcja 
