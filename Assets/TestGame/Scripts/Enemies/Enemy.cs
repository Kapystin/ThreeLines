using UnityEngine;

namespace TestGame.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public abstract int Damage { get; }
        public abstract void SetMoveSpeedRange(Vector2 moveSpeedRange);
        public abstract void SetHealth(int health);
        public abstract void SetDamage(int damage);
    }
}
