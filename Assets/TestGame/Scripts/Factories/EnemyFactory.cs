using TestGame.Scripts.Enemies;

namespace TestGame.Scripts.Factories
{
    public abstract class EnemyFactory<T> where T : Enemy
    {
        public abstract T FactoryMethod();
    }
}
