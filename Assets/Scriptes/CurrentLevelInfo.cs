using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrentLevelInfo : MonoBehaviour
{
    public Text textLevel;
   //указатель на каком уровне игрок находится
    void Update()
    {
       textLevel.text = "Level : "+(SceneManager.GetActiveScene().buildIndex).ToString();
    }
}
