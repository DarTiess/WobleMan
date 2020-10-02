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
    
    public void UpdateData(int curLevel, int maxLevel)
    {
        this.curLevel = curLevel;
        this.maxLevel = maxLevel;
    }

    public void OnStart()
    {
        //Начало игры - загрузка первого уровня, 
        //отчистить заработанные ранее очки, 
        //и сохранить состояние 
        SceneManager.LoadScene("Scene_" + curLevel);
        ManagerController.Player.DisplayCoins(0);
        ManagerController.Data.SaveGameState();
    }

    public void OnRestart()
    {
        //получаем билд активной сцены, и перезапускаем сначала
        curLevel = SceneManager.GetActiveScene().buildIndex; 
        //за проигрыш отнимаем очки
        ManagerController.Player.ChangeCoinsMinusCount();
        SceneManager.LoadScene("Scene_" + curLevel);
       
    }
    public void NextLevel()
    {
        //получаем билд активной сцены, загружаем след по порядку билд сцены
        //сохраняем состояние в файл
        curLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene("Scene_" + curLevel);
        ManagerController.Data.SaveGameState();
        //пауза в игре
        Time.timeScale = 1;
    }
    public void RestatrCurrent(int currentValue)
    {
        curLevel = currentValue;
        SceneManager.LoadScene("Scene_" +curLevel);
    }
    public void OnQuit()
    {
        //завершение приложения
        Application.Quit();

    }
}
