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
    public void Update()
    {
        CoinsCount.text = coins.ToString();
    }
    public void UpdateData(int coins, int MaxCoins)
    {
        this.coins = coins;
        this.MaxCoins = MaxCoins;
    }
   
    public void ChangeCoinsCount()
    {
        int value = 10;
        coins += value;

        if (coins < 0)
        {
            coins = 0;
        }else if(coins > MaxCoins)
        {
            coins = MaxCoins;
        }

        ManagerController.Data.SaveGameState();
    }
}
