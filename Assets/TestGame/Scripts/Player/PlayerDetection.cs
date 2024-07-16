using System;
using TestGame.Scripts.Enemies;
using UnityEngine;

namespace TestGame.Scripts.Player
{
    public class PlayerDetection : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        private Collider2D[] _hitsBuffer;

        private float _radius;
        private float _detectionDelay;

        private float _nextAttackTime;
        
        private Enemy _activeTarget;
        
        private void Start()
        {
            _hitsBuffer = new Collider2D[30];
            _radius = Boot.Instance.GameSettings.PlayerAttackRadius;
            _detectionDelay = Boot.Instance.GameSettings.PlayerAttackSpeed;

            _nextAttackTime = _detectionDelay;
        }

        private void Update()
        {
            int numHits = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _hitsBuffer, layerMask.value);
            _nextAttackTime -= Time.deltaTime;
            
            if (_nextAttackTime > 0) return;
            
            if (numHits < 0) return;
            
            if (_activeTarget != null && _activeTarget.gameObject.activeSelf) return;
            
            FindTarget(_hitsBuffer, numHits);
        }

        private void FindTarget(Collider2D[] hitsBuffer, int numHits)
        {
            for(int i = 0; i < numHits; i++)
            {
                var enemy = hitsBuffer[i].GetComponent<Enemy>();
                
                if (enemy is null) continue;

                _activeTarget = enemy;
                
                GameEventBus.Instance.OnEnemyDetectedAction(enemy);
                _nextAttackTime = _detectionDelay;
                break;
            }
        }
    }
}