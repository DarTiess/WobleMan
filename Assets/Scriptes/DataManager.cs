﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour, IGameManager
{
    private string fileName;

    public void Startup()
    {
        //создаем файл на устройстве для дальнейшей записи данных
        fileName = Path.Combine(Application.persistentDataPath, "wobbleGame.dat");
    }

    public void SaveGameState()
    { 
        //Сохраняем данные в dictionary (ключ, значение), для удобства дальнейшего извлечения данных
        Dictionary<string, object> _gameState = new Dictionary<string, object>();
        _gameState.Add("curLevel", ManagerController.Mission.curLevel);
        _gameState.Add("maxLevel", ManagerController.Mission.maxLevel);
        _gameState.Add("coins", ManagerController.Player.coins);
        _gameState.Add("maxCoins", ManagerController.Player.MaxCoins);

        //Запись в файл потоком
        FileStream stream = File.Create(fileName);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, _gameState);
        stream.Close();
    }

    public void LoadGameState()
    {
        //получаем данные
        Dictionary<string, object> _savedGameState= LoadSaveFile();
      
        ManagerController.Mission.UpdateData((int)_savedGameState["curLevel"], (int)_savedGameState["maxLevel"]);
        ManagerController.Player.UpdateData((int)_savedGameState["coins"], (int)_savedGameState["maxCoins"]); ManagerController.Mission.RestatrCurrent((int)_savedGameState["curLevel"]);
      
    }
    public void LoadLastGameCoins()
    {
        //получаем данные
        Dictionary<string, object> _savedGameState=LoadSaveFile();
        
        ManagerController.Player.UpdateData((int)_savedGameState["coins"], (int)_savedGameState["maxCoins"]);
        ManagerController.Player.DisplayCoins((int)_savedGameState["coins"]);
    }

    public Dictionary<string, object> LoadSaveFile()
    {
        //проверка существует ли сохраненный файл
        if (!File.Exists(fileName))
        {
            return null;
        }
        //если файл существует, данные распаковываются
        Dictionary<string, object> _savedGameState;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(fileName, FileMode.Open);
        _savedGameState = formatter.Deserialize(stream) as Dictionary<string, object>;
        stream.Close();

        //возвращаем данные в виде dictionary
        return _savedGameState;
    }

}
