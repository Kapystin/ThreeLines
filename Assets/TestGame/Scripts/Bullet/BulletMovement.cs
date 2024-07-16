using Cysharp.Threading.Tasks;
using TestGame.Scripts.Enemies;
using UnityEngine;

namespace TestGame.Scripts.Bullet
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        private Enemy _target;
        private float _moveSpeed;
        private Vector2 _direction;
        
        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }

        public void SetTarget(Enemy target)
        {
            _target = target;
            _direction = new Vector2(_target.transform.position.x, _target.transform.position.y) -
                         _rigidbody2D.position;
        }
        
        public void SetMoveSpeed(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }
        
        private void Move(float deltaTime)
        {
            _direction = _direction.normalized;
            _rigidbody2D.velocity = _direction * (_moveSpeed * 100) * deltaTime;
        }
    }
}