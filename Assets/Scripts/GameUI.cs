using System;
using TMPro;
using UnityEngine;

namespace BC.BestGame
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsLabel;
        [SerializeField] private TMP_Text _dateLabel;

        private void Start()
        {
            SetCoinsLabel(GameHub.One.Storage.GetCoins());
            GameHub.One.Storage.OnCoinsChangedEvent += SetCoinsLabel;
        }

        private void Update()
        {
            _dateLabel.text = DateTime.Now.ToDayTimeText();
        }

        private void SetCoinsLabel(int coins)
        {
            _coinsLabel.text = GameTextFormatUtils.GetFormattedCoinText(coins);
        }

        private void OnDestroy()
        {
            if (GameHub.One.IsInitialized)
            {
                GameHub.One.Storage.OnCoinsChangedEvent -= SetCoinsLabel;
            }
        }
    }
}