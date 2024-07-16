using TestGame.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestGame.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerDetection _playerDetection;
        [SerializeField] private PlayerMovement _playerMovement;

        public void Initialize(Transform movementBorder, IMovementInput input)
        {
            _playerMovement.SetMovementType(input);
            _playerMovement.SetGameState(GameStateMachine.Instance.GetCurrentState());
            _playerMovement.SetMovementBorder(movementBorder);
        }
    }
}