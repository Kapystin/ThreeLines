using TestGame.Scripts.Interfaces;
using TestGame.Scripts.Structs;
using UnityEngine;

namespace TestGame.Scripts.Player
{
    public class KeyboardInput : IMovementInput
    {
        public MovementVector GetMovementInput()
        {
            var movementVector = new MovementVector();

            movementVector.MovementInput = new Vector3(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"),
                0f
            );

            return movementVector;
        }
    }
}