using System;
using TestGame.Scripts.Enemies;
using UnityEngine;

namespace TestGame.Scripts.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletMovement _bulletMovement;
        [SerializeField] private LayerMask _layerMask;
        
        private int _damage = 1;
        private Action<Bullet> OnReturnBullet;
        
        public int GetDamage()
        {
            return _damage;
        }

        public void Initialize(float moveSpeed, int damage, Enemy enemy, Action<Bullet> onReturnBullet)
        {
            _bulletMovement.SetMoveSpeed(moveSpeed);
            _bulletMovement.SetTarget(enemy);
            _damage = damage;

            OnReturnBullet += onReturnBullet;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((_layerMask.value & (1 << other.transform.gameObject.layer)) <= 0) return;
            
            OnReturnBullet?.Invoke(this);
            OnReturnBullet = null;
        }
    }
}