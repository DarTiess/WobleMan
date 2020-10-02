using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public int coins { get; private set; }
    public int MaxCoins { get; private set; }
    public Text CoinsCount;
    public void Startup()
    {
        UpdateData(0, 50);
    }

    private void LateUpdate()
    { 
        //получаем актуальные данные о заработанных очках
        ManagerController.Data.LoadLastGameCoins();
    }
   
    public void UpdateData(int coins, int MaxCoins)
    {
        this.coins = coins;
        this.MaxCoins = MaxCoins;
       
    }
    public void DisplayCoins(int coinsCount)
    {
        //выводим очки на экран
        coins = coinsCount; 
        CoinsCount.text = coins.ToString();
    }
   
    public void ChangeCoinsCount()
    {
        //добавляем очки игроку
        int value = 10;
        coins += value;
        CheckCoins();
        //сохраняем данные в файл
        ManagerController.Data.SaveGameState();
    }
    public void ChangeCoinsMinusCount()
    {
        //отнимаем очки у игрока
        int value = 10;
        coins -= value;
        CheckCoins();
        //сохраняем данные в файл
        ManagerController.Data.SaveGameState();
    }

    public void CheckCoins()
    {
        //проверка количества очков, чтоб не выходило в минус, и больше максимума
        if (coins < 0)
        {
            coins = 0;
        }
        else if (coins > MaxCoins)
        {
            coins = MaxCoins;
        }
        
    }
}
