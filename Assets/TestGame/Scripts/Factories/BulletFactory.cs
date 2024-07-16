namespace TestGame.Scripts.Factories
{
    public abstract class BulletFactory<T> where T : Bullet.Bullet
    {
        public abstract T FactoryMethod();
    }
}