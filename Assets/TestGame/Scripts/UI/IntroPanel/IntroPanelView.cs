using System;
using UnityEngine;
using UnityEngine.UI;

namespace TestGame.Scripts.UI.IntroPanel
{
    public class IntroPanelView : BaseView
    {
        [SerializeField] private Button _startButton;

        public Action OnStartButtonClick;
        
        public override void AddListeners()
        {
            _startButton.onClick.AddListener(() => OnStartButtonClick?.Invoke());    
        }

        public override void RemoveListeners()
        {
            _startButton.onClick.RemoveAllListeners();
        }
    }
}