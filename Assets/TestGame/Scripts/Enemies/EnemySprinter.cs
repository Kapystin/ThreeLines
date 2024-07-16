using UnityEngine;

namespace TestGame.Scripts.Enemies
{
    public class EnemySprinter : Enemy
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyHitDetection _enemyHitDetection;
        
        private int _damage;
        private float _additionalSpeed;

        public override int Damage => _damage;

        public override void SetMoveSpeedRange(Vector2 moveSpeedRange)
        {
            _enemyMovement.SetMoveSpeed(new Vector2(moveSpeedRange.x + _additionalSpeed, 
                                                    moveSpeedRange.y + _additionalSpeed));
        }

        public override void SetHealth(int health)
        {
            _enemyHitDetection.Initialize(this, health);
        }

        public override void SetDamage(int damage)
        {
            _damage = damage;
        }

        public void SetAdditionalSpeed(float value)
        {
            _additionalSpeed = value;
        }
    }
}