using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour, IGameManager
{
    public int curLevel { get;  private set; }
    public int maxLevel { get; private set; }

   
    public void Startup()
    {
        UpdateData(1, 4);
    }
    // Update is called once per frame
    public void UpdateData(int curLevel, int maxLevel)
    {
        this.curLevel = curLevel;
        this.maxLevel = maxLevel;
    }

    public void OnStart()
    {
        SceneManager.LoadScene("Scene_" + curLevel);
        ManagerController.Data.SaveGameState();
    }

    public void OnRestart()
    {
        curLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Scene_" + curLevel);
    }
    public void NextLevel()
    {
        curLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene("Scene_" + curLevel);
        ManagerController.Data.SaveGameState();
        Time.timeScale = 1;
    }
    public void RestatrCurrent(int currentValue)
    {
        curLevel = currentValue;
        SceneManager.LoadScene("Scene_" +curLevel);
    }
    public void OnQuit()
    {
        Application.Quit();

    }
}
