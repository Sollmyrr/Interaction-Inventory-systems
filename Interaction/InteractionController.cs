using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// playerinventory.instance.itemlist.contains(requiredItem);
public class InteractionController : MonoBehaviour
{
    public void SetInteraction(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.TryGetComponent<InteractableObject>(out var interactableObject))
        {
            ItemSO requiredItem = interactableObject.GetRequiredItem();

            // Item is required and object is active.
            if (interactableObject.isRequiredItem && interactableObject.isActive == true)
            {
                Debug.Log("You have to use " + requiredItem.name);
                if (PlayerInventory.Instance.itemList.Contains(requiredItem))
                {
                    interactableObject.Interact();
                    //PlayerInventory.Instance.RemoveItem(requiredItem);
                }
            }       

            // Item is not required and object has been activated. ***Pierwsza część warunku do usunięcia***
            else if (interactableObject.isRequiredItem == false && interactableObject.isActive == false)
            {
                Debug.Log("object has been deactivated earlier");
            }

            else if (interactableObject.isRequiredItem == false && interactableObject.isActive == true)
            {
                Debug.Log("interactableObject.Interact()");
                interactableObject.Interact();
            }

            else
            {
                Debug.Log("yyy???");
            }
        }
    }
}

/*
    public void SetInteraction(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.TryGetComponent<InteractableObject>(out var interactableObject) && !interactableObject.activated)
        {
            // Item is required.
            if (interactableObject.isRequiredItem)
            {
                Item item = interactableObject.GetRequiredItem();
                bool requiredItemFound = playerInventory.IsRequiredItem(item);
                if (requiredItemFound)
                {
                    Debug.Log("Required item: " + item.name + " found");
                    interactableObject.Interact();
                }
                else
                {
                    Debug.Log("Required item: " + item.name + " not found");
                }
            }
            // Item is not required.
            else
            {
                interactableObject.Interact();
            }
        }
    }


        isLeftMouseButtonDown = Input.GetMouseButtonDown(0);
        if(isLeftMouseButtonDown && gameObject.tag == "ClikableItem")
        {
            Debug.Log(this.gameObject.name);
        }
*/