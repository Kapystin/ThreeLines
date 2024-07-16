using UnityEngine;

namespace TestGame.Scripts.Enemies
{
    public class EnemySupport : Enemy
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyHitDetection _enemyHitDetection;
        
        private int _damage;

        public override int Damage => _damage;

        public override void SetMoveSpeedRange(Vector2 moveSpeedRange)
        {
            _enemyMovement.SetMoveSpeed(moveSpeedRange);
        }

        public override void SetHealth(int health)
        {
            _enemyHitDetection.Initialize(this, health);
        }

        public override void SetDamage(int damage)
        {
            _damage = damage;
        }
    }
}