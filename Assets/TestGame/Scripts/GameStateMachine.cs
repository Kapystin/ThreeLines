using System;
using TestGame.Scripts.Enums;
using TestGame.Scripts.UI;
using TestGame.Scripts.UI.UIStates;

namespace TestGame.Scripts
{
    public class GameStateMachine
    {
        public static GameStateMachine Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameStateMachine();
                }

                return _instance;
            }
        }

        private static GameStateMachine _instance = null;
        private GameStateType _currentState;

        public delegate void OnGameStateChange(GameStateType stateType);
        public event OnGameStateChange OnGameStateChangeEvent;
        

        public GameStateType GetCurrentState()
        {
            return _currentState;
        }

        public void SetState(GameStateType state)
        {
            _currentState = state;
            OnGameStateChangeEvent?.Invoke(state);

            switch (state)
            {
                case GameStateType.None:
                    break;
                case GameStateType.Intro:
                    UIStateMachine.Instance.SetState(new IntroUIState());
                    break;
                case GameStateType.Play:
                    UIStateMachine.Instance.SetState(new PlayUIState());
                    break;
                case GameStateType.Lose:
                    UIStateMachine.Instance.SetState(new LoseUIState());
                    break;
                case GameStateType.Win:
                    UIStateMachine.Instance.SetState(new WinUIState());
                    break;
            }
        }
    }
}