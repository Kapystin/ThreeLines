using TestGame.Scripts.Enums;
using TestGame.Scripts.Interfaces;
using TestGame.Scripts.UI.IntroPanel;
using TestGame.Scripts.UI.UIStates;
using UnityEngine;

namespace TestGame.Scripts.UI.PlayPanel
{
    public class PlayPanelViewModel : IViewModel
    {
        private readonly PlayPanelView _view;
        private readonly PlayPanelModel _model;
        
        public PlayPanelViewModel(PlayPanelView view, PlayPanelModel model)
        {
            _view = view;
            _model = model;
        }
        
        public void AddListeners()
        {
            _view.OnMenuButtonClick += OnMenuButtonClick;
            _model.OnHealthChange += OnHealthChange;
            _model.OnEnemyLeftAmountChange += OnEnemyLeftAmountChange;
        }

        public void RemoveListeners()
        {
            _view.OnMenuButtonClick -= OnMenuButtonClick;
            _model.OnHealthChange -= OnHealthChange;
            _model.OnEnemyLeftAmountChange -= OnEnemyLeftAmountChange;
        }

        private void OnHealthChange(int value)
        {
            if (value <= 0)
            {
                _view.RemoveListeners();
                _model.RemoveListeners();
                _view.Destroy();
                GameStateMachine.Instance.SetState(GameStateType.Lose);
            }
            
            _view.SetHealthAmount(value);
        }
        
        private void OnEnemyLeftAmountChange(int value)
        {
            if (value <= 0)
            {
                _view.RemoveListeners();
                _model.RemoveListeners();
                _view.Destroy();
                GameStateMachine.Instance.SetState(GameStateType.Win);
            }
            _view.SetEnemyLeftAmount(value);
        }
        
        private void OnMenuButtonClick()
        {
            // _view.Destroy();
            // UIStateMachine.Instance.SetState(new PlayUIState());
        }
    }
}