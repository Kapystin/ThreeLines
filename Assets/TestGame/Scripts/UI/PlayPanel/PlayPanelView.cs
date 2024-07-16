using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Serialization;

namespace TestGame.Scripts.UI.PlayPanel
{
    public class PlayPanelView: BaseView
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private TMP_Text _healthAmount;
        [SerializeField] private TMP_Text _enemyLeftAmount;

        public Action OnMenuButtonClick;
        
        public override void AddListeners()
        {
            _menuButton.onClick.AddListener(() => OnMenuButtonClick?.Invoke());    
        }

        public override void RemoveListeners()
        {
            _menuButton.onClick.RemoveAllListeners();
        }

        public void SetHealthAmount(int value)
        {
            _healthAmount.text = $"{value}";
        }

        public void SetEnemyLeftAmount(int value)
        {
            _enemyLeftAmount.text = $"{value}";
        }
    }
}