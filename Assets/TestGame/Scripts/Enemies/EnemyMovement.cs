using TestGame.Scripts.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestGame.Scripts.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        private float _moveSpeed;
        private Vector2 _movementDirection;
        private GameStateType _gameState;
        
        private void OnEnable()
        {
            _gameState = GameStateMachine.Instance.GetCurrentState();
            GameStateMachine.Instance.OnGameStateChangeEvent += OnOnGameStateChange;
        }

        private void OnDisable()
        {
            GameStateMachine.Instance.OnGameStateChangeEvent -= OnOnGameStateChange;
        }

        private void FixedUpdate()
        {
            if (_gameState != GameStateType.Play) return;
            
            Move(Time.fixedDeltaTime);
        }

        public void SetMoveSpeed(Vector2 moveSpeedRange)
        {
            _moveSpeed = Random.Range(moveSpeedRange.x, moveSpeedRange.y);;
        }
        
        private void Move(float deltaTime)
        {
            _rigidbody2D.velocity = Vector2.down * (_moveSpeed * 10) * deltaTime;
        }
        
        private void OnOnGameStateChange(GameStateType gameState)
        {
            _gameState = gameState;
        }
    }
}