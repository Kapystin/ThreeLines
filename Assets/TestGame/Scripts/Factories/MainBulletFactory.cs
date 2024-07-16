using UnityEngine;

namespace TestGame.Scripts.Factories
{
    public class MainBulletFactory : BulletFactory<Bullet.Bullet>
    {
        private readonly Bullet.Bullet _enemyTankPrefab;
        private readonly Transform _parent;

        public MainBulletFactory(Bullet.Bullet enemyTankPrefab, Transform parent)
        {
            _enemyTankPrefab = enemyTankPrefab;
            _parent = parent;
        }
        
        public override Bullet.Bullet FactoryMethod()
        {
            return Object.Instantiate(_enemyTankPrefab, _parent);
        }
    }
}