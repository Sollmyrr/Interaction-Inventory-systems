using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OpenInteractionComponent))]
public class Door : InteractableObject
{
    private InteractionComponent interactionComponent;
    public bool InsertedKey = false;

    private void Awake()
    {
        interactionComponent = GetComponent<InteractionComponent>();
    }

    private void Start()
    {
        isRequiredItem = true;
        isActive = true;
    }

    public override void Interact()
    {
        if (!isRequiredItem)
        {
            interactionComponent.Perform();
            SetObjectAsActivated();
            isRequiredItem = false;
        }
    }


}
