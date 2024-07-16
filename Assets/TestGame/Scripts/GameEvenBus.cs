using TestGame.Scripts.Enemies;
using UnityEngine;

namespace TestGame.Scripts
{
    public class GameEventBus 
    {
        public static GameEventBus Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameEventBus();
                }

                return _instance;
            }
        }

        private static GameEventBus _instance = null;

        public delegate void OnPlayerGetDamage(Enemy enemy);
        public event OnPlayerGetDamage OnPlayerGetDamageEvent;
        
        public delegate void OnEnemyDeath(Enemy enemy);
        public event OnEnemyDeath OnEnemyDeathEvent;
        
        public delegate void OnEnemyDetected(Enemy enemy);
        public event OnEnemyDetected OnEnemyDetectedEvent;
        
        public void OnPlayerGetDamageAction(Enemy enemy)
        {
            OnPlayerGetDamageEvent?.Invoke(enemy);
        }
        
        public void OnEnemyDeathAction(Enemy enemy)
        {
            OnEnemyDeathEvent?.Invoke(enemy);
        }
        
        public void OnEnemyDetectedAction(Enemy enemy)
        {
            OnEnemyDetectedEvent?.Invoke(enemy);
        }
    }
}