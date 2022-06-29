using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

// usunięcie ontrigger  i wrzucenie input do OnTriggerEnter

public class Interactor : MonoBehaviour
{
    public InventorySO inventorySO;
    private InteractionController interactionActivator;

    public delegate void InteractSend(InteractableObject interactableObject);
    public InteractSend interactSendCallBack;

    Collider2D myCollision;
    public bool inTrigger;

    private void Start()
    {
        interactionActivator = GameObject.FindGameObjectWithTag("Main").GetComponent<InteractionController>();
        inTrigger = false;
    }

    private void Update()
    {
        COllisionService();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
        myCollision = collision;
        interactSendCallBack(collision.gameObject.GetComponent<InteractableObject>());

    }

    private void COllisionService()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && myCollision.CompareTag("Item"))
            {
                bool isComponent = myCollision.TryGetComponent<Item>(out Item item);
                if (isComponent)
                {
                    PlayerInventory.Instance.AddItem(item.itemSO);
                    Destroy(myCollision.gameObject);
                }
            }

            else if (Input.GetKeyDown(KeyCode.E) && myCollision.gameObject.CompareTag("InteractiveObject"))
            {
                //ItemSendCallBack(collision.gameObject);
                interactionActivator.SetInteraction(myCollision);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}