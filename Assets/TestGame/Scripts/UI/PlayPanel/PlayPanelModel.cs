using System;
using TestGame.Scripts.Enemies;
using TestGame.Scripts.Interfaces;
using Random = UnityEngine.Random;

namespace TestGame.Scripts.UI.PlayPanel
{
    public class PlayPanelModel : IModel
    {
        private int _healthAmount;
        private int _enemyLeftAmount;

        public Action<int> OnHealthChange;
        public Action<int> OnEnemyLeftAmountChange;
        
        public PlayPanelModel()
        {
            _healthAmount = Boot.Instance.GameSettings.PlayerHealth;
            _enemyLeftAmount = Random.Range(Boot.Instance.GameSettings.AmountEnemyForWin.x,
                                            Boot.Instance.GameSettings.AmountEnemyForWin.y);
        }
        
        public void AddListeners()
        {
            OnHealthChange?.Invoke(_healthAmount);
            OnEnemyLeftAmountChange?.Invoke(_enemyLeftAmount);
            
            GameEventBus.Instance.OnPlayerGetDamageEvent += OnOnPlayerGetDamage;
            GameEventBus.Instance.OnEnemyDeathEvent += OnOnEnemyDeath;
        }

        public void RemoveListeners()
        {
            GameEventBus.Instance.OnPlayerGetDamageEvent -= OnOnPlayerGetDamage;
            GameEventBus.Instance.OnEnemyDeathEvent -= OnOnEnemyDeath;
        }
        
        private void OnOnPlayerGetDamage(Enemy enemy)
        {
            _healthAmount -= enemy.Damage;
            OnHealthChange?.Invoke(_healthAmount);
        }

        private void OnOnEnemyDeath(Enemy enemy)
        {
            _enemyLeftAmount--;
            OnEnemyLeftAmountChange?.Invoke(_enemyLeftAmount);
        }
    }
}
