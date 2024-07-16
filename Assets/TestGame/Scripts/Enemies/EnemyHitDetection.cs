using UnityEngine;

namespace TestGame.Scripts.Enemies
{
    public class EnemyHitDetection : MonoBehaviour
    {
        private Enemy _enemy;
        private int _health;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Bullet.Bullet>())
            {
                GetDamage(other.gameObject.GetComponent<Bullet.Bullet>().GetDamage());
            }
        }

        public void Initialize(Enemy enemy, int health)
        {
            _enemy = enemy;
            _health = health;
        }

        private void GetDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                GameEventBus.Instance.OnEnemyDeathAction(_enemy);
            }
        }
    }
}