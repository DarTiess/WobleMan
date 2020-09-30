using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerController : MonoBehaviour
{
    public int curLevel { get; private set; }
    public int maxLevel { get; private set; }

    void Start()
    {
        UpdateData(1, 3);
    }

    // Update is called once per frame
     public void UpdateData(int curLevel, int maxLevel)
    {
        this.curLevel = curLevel;
        this.maxLevel = maxLevel;
    }

    public void OnStart()
    {
        SceneManager.LoadScene("Scene_"+curLevel);
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("Scene_"+curLevel);
    }
    public void NextLevel()
    {
        curLevel++;
        SceneManager.LoadScene("Scene_" + curLevel); 
        Time.timeScale = 1;
    }
}
