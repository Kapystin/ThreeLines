using TestGame.Scripts.Enemies;
using UnityEngine;

namespace TestGame.Scripts.Factories
{
    public class EnemySprinterFactory : EnemyFactory<EnemySprinter>
    {
        private readonly EnemySprinter _enemySprinterPrefab;
        private readonly Transform _parent;

        public EnemySprinterFactory(EnemySprinter enemySprinterPrefab, Transform parent)
        {
            _enemySprinterPrefab = enemySprinterPrefab;
            _parent = parent;
        }
        
        public override EnemySprinter FactoryMethod()
        {
            var enemy =  Object.Instantiate(_enemySprinterPrefab, _parent);
            
            enemy.SetAdditionalSpeed(3f);
            
            return enemy;
        }
    }
}
