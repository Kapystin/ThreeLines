using TestGame.Scripts.Enums;
using TestGame.Scripts.Player;
using UnityEngine;

namespace TestGame.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private Boot _boot;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private Transform _movementBorder;
        
        private GameStateType _gameState;
        
        private void OnEnable()
        {
            GameStateMachine.Instance.OnGameStateChangeEvent += OnOnGameStateChangeEvent;
        }

        private void OnDisable()
        {
            GameStateMachine.Instance.OnGameStateChangeEvent -= OnOnGameStateChangeEvent;
        }
        
        private void OnOnGameStateChangeEvent(GameStateType stateType)
        {
            _gameState = stateType;
            
            if (_gameState != GameStateType.Play) return;

            var player = Instantiate(_boot.GameSettings.PlayerPrefab, _spawnPosition);
            
            player.Initialize(_movementBorder, new KeyboardInput());
            _boot.SetPlayer(player);
        }
    }
}