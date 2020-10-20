using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    //По достижению цели активируется панель Перехода на след уровень
    //и салют на заднем плане
    [SerializeField] private Image completePanel;
    [SerializeField] private Image touchPanel;
    [SerializeField] private GameObject birthdaySpark;
    [SerializeField] private GameObject birthdayConfetti;
   
    // Start is called before the first frame update
    void Start()
    {
        completePanel.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            touchPanel.gameObject.SetActive(false);
            birthdaySpark.SetActive(true);
            birthdayConfetti.SetActive(true);
            completePanel.gameObject.SetActive(true);
        }
    }
}
