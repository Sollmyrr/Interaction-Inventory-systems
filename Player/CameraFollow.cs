using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    public float offset;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        // We store current camera's position in variable temp - temporary position.
        Vector3 temp = transform.position;

        // We set the camera's position.x to be equal to the player's position.x.
        temp.x = playerTransform.position.x;

        // This will add the offset value to the temporary camera's position.x.
        temp.x += offset;

        // We set back the camera's temp position to the camera's current position.x.
        transform.position = temp;
    }
}
