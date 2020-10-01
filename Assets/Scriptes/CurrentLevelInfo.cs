using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CurrentLevelInfo : MonoBehaviour
{
    public Text textLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       textLevel.text = "Level : "+(SceneManager.GetActiveScene().buildIndex).ToString();
    }
}
