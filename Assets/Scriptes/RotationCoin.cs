using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCoin : MonoBehaviour
{
    [SerializeField]
    private float tumble;
    //запускаем повороты вокруг своей оси GameObject
         void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    //при столкновении с Игроком добавляются очки, и уничтожается объект
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ManagerController.Player.ChangeCoinsCount();
            Destroy(this.gameObject);
        }
    }
}
