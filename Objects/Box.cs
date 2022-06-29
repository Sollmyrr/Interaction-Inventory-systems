using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OpenInteractionComponent))]
[RequireComponent(typeof(MoveInteractionComponent))]
public class Box : InteractableObject
{
    private InteractionComponent interactionComponent;

    private void Awake()
    {
        interactionComponent = GetComponent<InteractionComponent>();
    }

    private void Start()
    {
        isRequiredItem = false;
        isActive = true;
    }

    public override void Interact()
    {
        interactionComponent.Perform();
        SetObjectAsActivated();
    }
}
