using System;
using UnityEngine;

namespace BC.BestGame
{
    public class GameStorageSystem
    {
        public event Action<int> OnCoinsChangedEvent;

        private const string COINS_PREF_NAME = "Coins";
        private const int DEFAULT_COINS_VALUE = 0;

        private int _coins;

        public GameStorageSystem()
        {
            _coins = PlayerPrefs.GetInt(COINS_PREF_NAME, DEFAULT_COINS_VALUE);
        }

        public int GetCoins()
        {
            return _coins;
        }

        public void SetCoins(int newCoins)
        {
            _coins = newCoins;
            PlayerPrefs.SetInt(COINS_PREF_NAME, newCoins);
            OnCoinsChangedEvent?.Invoke(_coins);
        }
    }
}