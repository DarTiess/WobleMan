using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectPlayer : MonoBehaviour
{
    
    [SerializeField] private Image restartPanel;
    [SerializeField] private Image touchPanel;

    void Start()
    {
        //в начале ставим панель Рестарта неактивной
        restartPanel.gameObject.SetActive(false);
        
    }
    //при обнаружении Игрока появляется панель Restart и уничтожается игрок
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            touchPanel.gameObject.SetActive(false);
            restartPanel.gameObject.SetActive(true);
            StartCoroutine(PlayerDie(other.gameObject));
        }
    }

    private IEnumerator PlayerDie(GameObject player)
    {
         yield return new WaitForSeconds(0.5f);
        Destroy(player);
    }
}
