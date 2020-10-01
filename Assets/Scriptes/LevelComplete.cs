using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private Image completePanel;
    [SerializeField] private GameObject birthdaySpark;
    [SerializeField] private GameObject birthdayConfetti;
   
    // Start is called before the first frame update
    void Start()
    {
        completePanel.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            birthdaySpark.SetActive(true);
            birthdayConfetti.SetActive(true);
            completePanel.gameObject.SetActive(true);
        }
    }
}
