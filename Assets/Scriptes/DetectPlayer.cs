using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectPlayer : MonoBehaviour
{
    
    [SerializeField] private Image imagePanel;
   
    void Start()
    {
        //в начале ставим панель Рестарта неактивной
        imagePanel.gameObject.SetActive(false);
        
    }
    //при обнаружении Игрока появляется панель Restart и уничтожается игрок
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            imagePanel.gameObject.SetActive(true);
            StartCoroutine(PlayerDie(other.gameObject));
        }
    }

    private IEnumerator PlayerDie(GameObject player)
    {
         yield return new WaitForSeconds(0.5f);
        Destroy(player);
    }
}
