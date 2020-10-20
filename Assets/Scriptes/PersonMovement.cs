using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PersonMovement : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private Rigidbody Player = null;
    [SerializeField]
    private float forceFactor = 0.025f;

    public void OnDrag(PointerEventData eventData)
    {
        Player.AddForce(new Vector3(eventData.delta.x / Screen.width * 320,
                                  0,
                                  eventData.delta.y / Screen.height * 526) * forceFactor, ForceMode.Impulse);
    }
}
