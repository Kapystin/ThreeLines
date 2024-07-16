using TestGame.Scripts.Enemies;
using UnityEngine;

namespace TestGame.Scripts.Factories
{
    public class EnemySupportFactory : EnemyFactory<EnemySupport>
    {
        private readonly EnemySupport _enemySupportPrefab;
        private readonly Transform _parent;

        public EnemySupportFactory(EnemySupport enemySupportPrefab, Transform parent)
        {
            _enemySupportPrefab = enemySupportPrefab;
            _parent = parent;
        }
        
        public override EnemySupport FactoryMethod()
        {
            return Object.Instantiate(_enemySupportPrefab, _parent);
        }
    }
}
