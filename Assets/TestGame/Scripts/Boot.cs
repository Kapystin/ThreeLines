using System;
using TestGame.Scripts.Enums;
using TestGame.Scripts.GameData;
using UnityEngine;

namespace TestGame.Scripts
{
    public class Boot : MonoBehaviour
    {
        public static Boot Instance => _instance;
        private static Boot _instance;
        
        
        public Player.Player Player => _player;
        public GameSettings GameSettings => _gameSettings;
        
        [SerializeField] private GameSettings _gameSettings;

        private GameStateMachine _gameStateMachine;
        private GameEventBus _gameEventBus;

        private Player.Player _player;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != null)
            {
                Destroy(gameObject);
            }
            
            _gameStateMachine = GameStateMachine.Instance;
            _gameEventBus = GameEventBus.Instance;
        }

        private void Start()
        {
            _gameStateMachine.SetState(GameStateType.Intro);
        }

        public void SetPlayer(Player.Player player)
        {
            _player = player;
        }
    }
}
