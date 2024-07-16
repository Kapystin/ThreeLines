using System.Threading;
using Cysharp.Threading.Tasks;
using TestGame.Scripts.Enemies;
using TestGame.Scripts.Factories;
using UnityEngine;

namespace TestGame.Scripts.Bullet
{
    public class BulletManager : MonoBehaviour
    {
        [SerializeField] private Transform _bulletParent;
        private ObjectPool<Bullet> _bulletPool;
        private MainBulletFactory _mainBulletFactory;
        
        private Boot _boot;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        
        private void Start()
        {
            _boot = Boot.Instance;
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            
            _mainBulletFactory = new MainBulletFactory(_boot.GameSettings.BulletPrefab, _bulletParent);
            _bulletPool = new ObjectPool<Bullet>(_mainBulletFactory.FactoryMethod, TurnOnEnemy, TurnOffEnemy, 10);
        }

        private void OnEnable()
        {
            GameEventBus.Instance.OnEnemyDetectedEvent += OnOnEnemyDetected;
        }

        private void OnDisable()
        {
            GameEventBus.Instance.OnEnemyDetectedEvent -= OnOnEnemyDetected;
            
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        private void TurnOnEnemy(Bullet bullet)
        {
            bullet.gameObject.transform.position = _boot.Player.transform.position;
            bullet.gameObject.SetActive(true);
        }
        
        private void TurnOffEnemy(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }
        
        private void OnOnEnemyDetected(Enemy enemy)
        {
            // var bullet = _bulletPool.GetObject();
            // bullet.Initialize(_boot.GameSettings.PlayerBulletSpeedMovement,
            //                   _boot.GameSettings.PlayerAttackDamage, enemy, ReturnBullet);

            Shoot(enemy);
        }

        private void ReturnBullet(Bullet bullet)
        {
            _bulletPool.ReturnObject(bullet);
        }

        private async UniTask Shoot(Enemy enemy)
        {
            var bullet = _bulletPool.GetObject();
            bullet.Initialize(_boot.GameSettings.PlayerBulletSpeedMovement,
                _boot.GameSettings.PlayerAttackDamage, enemy, ReturnBullet);
            
            await UniTask.WaitForSeconds(_boot.GameSettings.PlayerAttackSpeed, cancellationToken: _cancellationToken);
            
            if (enemy.gameObject.activeSelf == false) return;

            Shoot(enemy);
        }
        
    }
}
