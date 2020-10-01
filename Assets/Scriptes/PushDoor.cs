using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDoor : MonoBehaviour
{
    private ControllerColliderHit _contact;
    public float pushForce = 5.0f;

    //столкновение с Player
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
        }
    }
}
