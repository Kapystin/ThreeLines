using TestGame.Scripts.Enemies;
using UnityEngine;

namespace TestGame.Scripts.Factories
{
    public class EnemyTankFactory : EnemyFactory<EnemyTank>
    {
        private readonly EnemyTank _enemyTankPrefab;
        private readonly Transform _parent;

        public EnemyTankFactory(EnemyTank enemyTankPrefab, Transform parent)
        {
            _enemyTankPrefab = enemyTankPrefab;
            _parent = parent;
        }
        
        public override EnemyTank FactoryMethod()
        {
            var enemy =  Object.Instantiate(_enemyTankPrefab, _parent);
            
            enemy.SetAdditionalHealth(5);
            
            return enemy;
        }
    }
}
