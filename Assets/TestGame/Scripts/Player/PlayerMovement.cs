using System;
using TestGame.Scripts.Enums;
using TestGame.Scripts.Interfaces;
using UnityEngine;

namespace TestGame.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(0, 10)] 
        [SerializeField] private float _moveSpeed = 5;
        
        private GameStateType _gameStateType;
        private IMovementInput _movementInput;

        private float _leftBorder;
        private float _rightBorder;
        private float _topBorder;
        private float _bottomBorder;
        
        private void OnEnable()
        {
            GameStateMachine.Instance.OnGameStateChangeEvent += SetGameState;
        }

        private void OnDisable()
        {
            GameStateMachine.Instance.OnGameStateChangeEvent -= SetGameState;
        }
        
        private void Update()
        {
            if (_gameStateType != GameStateType.Play) return;
            
            Move(Time.deltaTime);
        }
        
        public void SetMovementType(IMovementInput movementInput)
        {
            _movementInput = movementInput;
        }

        public void SetMovementBorder(Transform border)
        {
            _leftBorder = border.position.x - border.localScale.x * 0.5f;
            _rightBorder = border.position.x + border.localScale.x * 0.5f;
            
            _bottomBorder = border.position.y - border.localScale.y * 0.5f;
            _topBorder = border.position.y + border.localScale.y * 0.5f;
        }
        
        public void SetGameState(GameStateType gameStateType)
        {
            _gameStateType = gameStateType;
        }

        private void Move(float deltaTime)
        {
            var movementInput = _movementInput.GetMovementInput().MovementInput;
            
            if (transform.position.x - transform.localScale.x * 0.5f <= _leftBorder)
            {
                movementInput.x = 1;
            }
            
            if (transform.position.x + transform.localScale.x * 0.5f >= _rightBorder)
            {
                movementInput.x = -1;
            }   
            
            if (transform.position.y - transform.localScale.y * 0.5f  <= _bottomBorder)
            {
                movementInput.y = 1;
            }
            
            if (transform.position.y + transform.localScale.y * 0.5f  >= _topBorder)
            {
                movementInput.y = -1;
            }
            
            movementInput = movementInput.normalized;
            transform.Translate(movementInput * _moveSpeed * deltaTime);
        }
    }
}