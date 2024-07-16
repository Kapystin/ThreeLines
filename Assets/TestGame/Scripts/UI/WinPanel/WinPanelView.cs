using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TestGame.Scripts.UI.WinPanel
{
    public class WinPanelView: BaseView
    {
        [SerializeField] private Button _restartButton;

        public Action OnRestartButtonClick;
        
        public override void AddListeners()
        {
            _restartButton.onClick.AddListener(() => OnRestartButtonClick?.Invoke());    
        }

        public override void RemoveListeners()
        {
            _restartButton.onClick.RemoveAllListeners();
        }
    }
}