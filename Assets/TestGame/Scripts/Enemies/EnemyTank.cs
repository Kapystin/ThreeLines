using UnityEngine;

namespace TestGame.Scripts.Enemies
{
    public class EnemyTank : Enemy
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyHitDetection _enemyHitDetection;
        
        private int _damage;
        private int _additionalHealth;

        public override int Damage => _damage;

        public override void SetMoveSpeedRange(Vector2 moveSpeedRange)
        {
            _enemyMovement.SetMoveSpeed(moveSpeedRange);
        }

        public override void SetHealth(int health)
        {
            _enemyHitDetection.Initialize(this, health + _additionalHealth);
        }

        public override void SetDamage(int damage)
        {
            _damage = damage;
        }

        public void SetAdditionalHealth(int value)
        {
            _additionalHealth = value;
        }
    }
}