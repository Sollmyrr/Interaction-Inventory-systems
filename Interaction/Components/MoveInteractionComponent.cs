using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInteractionComponent : InteractionComponent
{
    public override void Perform()
    {
        Debug.Log(this.name + "Moved");

    }
}
