using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{

    public ItemSO itemSO;
    public Interactor player;
    public bool isEmpty = true;

    private InteractableObject interactableObjectlocal;
    private void Start()
    {
        player.interactSendCallBack += GetInteractable;
    }

    private void GetInteractable(InteractableObject interactableObject)
    {
        interactableObjectlocal = interactableObject;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(player.inTrigger && interactableObjectlocal.requiredItem == itemSO)
        {
            PlayerInventory.Instance.RemoveItem(itemSO);
            interactableObjectlocal.isRequiredItem = false;
        }
        print(itemSO);
    }
}
