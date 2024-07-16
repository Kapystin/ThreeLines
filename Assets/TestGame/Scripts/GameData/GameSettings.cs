using TestGame.Scripts.Enemies;
using UnityEngine;

namespace TestGame.Scripts.GameData
{
    [CreateAssetMenu(menuName = "GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [Header("Bullet Prefabs")]
        public Bullet.Bullet BulletPrefab;
      
        [Space]
        [Header("Bullet Prefabs")]
        public Player.Player PlayerPrefab;
        
        [Space]
        [Header("Enemies Prefab")]
        public EnemyTank EnemyTankPrefab;
        public EnemySupport EnemySupportPrefab;
        public EnemySprinter EnemySprinterPrefab;
        
        [Space] 
        [Header("Enemy Settings")]
        public Vector2Int AmountEnemyForWin;
        public Vector2 TimeBetweenEnemySpawn;
        public Vector2 EnemySpeedMovement;
        public int EnemyHealth;
        public int EnemyDamage;

        [Space] 
        [Header("Player Settings")]
        public float PlayerAttackRadius;
        public int PlayerHealth;
        [Range(0.1f, 2f)]
        public float PlayerAttackSpeed;
        public int PlayerAttackDamage;
        [Range(1f, 10f)]
        public float PlayerBulletSpeedMovement;
    }
}