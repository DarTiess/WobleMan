using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCoin : MonoBehaviour
{
    [SerializeField]
    private float tumble;



        void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ManagerController.Player.ChangeCoinsCount();
            Destroy(this.gameObject);
        }
    }
}
