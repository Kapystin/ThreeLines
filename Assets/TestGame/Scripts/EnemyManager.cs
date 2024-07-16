using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TestGame.Scripts.Enemies;
using TestGame.Scripts.Enums;
using TestGame.Scripts.Factories;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestGame.Scripts
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private Boot _boot;
        [SerializeField] private Transform _enemyParent;
        [SerializeField] private Transform[] _enemySpawnPoints;
        
        private ObjectPool<EnemyTank> _enemyTankPool;
        private ObjectPool<EnemySupport> _enemySupportPool;
        private ObjectPool<EnemySprinter> _enemySprinterPool;

        private EnemyTankFactory _enemyTankFactory;
        private EnemySupportFactory _enemySupportFactory;
        private EnemySprinterFactory _enemySprinterFactory;
        
        private Vector2 _timeBetweenEnemySpawn;
        private GameStateType _gameState;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        
        private void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            
            _timeBetweenEnemySpawn = _boot.GameSettings.TimeBetweenEnemySpawn;
            
            _enemyTankFactory = new EnemyTankFactory(_boot.GameSettings.EnemyTankPrefab, _enemyParent);
            _enemyTankPool = new ObjectPool<EnemyTank>(_enemyTankFactory.FactoryMethod, TurnOnEnemy, TurnOffEnemy );
                        
            _enemySupportFactory = new EnemySupportFactory(_boot.GameSettings.EnemySupportPrefab, _enemyParent);
            _enemySupportPool = new ObjectPool<EnemySupport>(_enemySupportFactory.FactoryMethod, TurnOnEnemy, TurnOffEnemy );
                        
            _enemySprinterFactory = new EnemySprinterFactory(_boot.GameSettings.EnemySprinterPrefab, _enemyParent);
            _enemySprinterPool = new ObjectPool<EnemySprinter>(_enemySprinterFactory.FactoryMethod, TurnOnEnemy, TurnOffEnemy );
        }

        private void OnEnable()
        {
            GameStateMachine.Instance.OnGameStateChangeEvent += OnOnGameStateChangeEvent;
            GameEventBus.Instance.OnPlayerGetDamageEvent += ReturnObject;
            GameEventBus.Instance.OnEnemyDeathEvent += ReturnObject;
        }

        private void OnDisable()
        {
            GameStateMachine.Instance.OnGameStateChangeEvent -= OnOnGameStateChangeEvent;
            GameEventBus.Instance.OnPlayerGetDamageEvent -= ReturnObject;
            GameEventBus.Instance.OnEnemyDeathEvent -= ReturnObject;
            
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        private void OnOnGameStateChangeEvent(GameStateType stateType)
        {
            _gameState = stateType;

            switch (stateType)
            {
                case GameStateType.None:
                    break;
                case GameStateType.Intro:
                    break;
                case GameStateType.Play:
                    EnemySpawner();
                    break;
                case GameStateType.Lose:
                    _cancellationTokenSource.Cancel();
                    break;
                case GameStateType.Win:
                    _cancellationTokenSource.Cancel();
                    break;
            }
        }

        private void TurnOnEnemy(Enemy enemy)
        {
            var spawnPosition = _enemySpawnPoints[Random.Range(0, _enemySpawnPoints.Length)];
            
            enemy.gameObject.transform.position = spawnPosition.position;
            
            enemy.SetMoveSpeedRange(_boot.GameSettings.EnemySpeedMovement);
            enemy.SetHealth(_boot.GameSettings.EnemyHealth);
            enemy.SetDamage(_boot.GameSettings.EnemyDamage);
            
            enemy.gameObject.SetActive(true);
        }
        
        private void TurnOffEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }

        private async UniTask EnemySpawner()
        {
            if (_gameState != GameStateType.Play || _cancellationToken.IsCancellationRequested) return;

            var random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                    _enemySupportPool.GetObject();
                    break;
                case 1:
                    _enemySprinterPool.GetObject();
                    break;
                case 2:
                    _enemyTankPool.GetObject();
                    break;
                default:
                    _enemyTankPool.GetObject();
                    break;
            }
            
            var time = Random.Range(_timeBetweenEnemySpawn.x, _timeBetweenEnemySpawn.y);
            
            await UniTask.WaitForSeconds(time, cancellationToken: _cancellationToken);
            
            EnemySpawner();
        }
        
        
        private void ReturnObject(Enemy enemy)
        {
            if (enemy is EnemyTank enemyTank)
            {
                _enemyTankPool.ReturnObject(enemyTank);
            }
            else if (enemy is EnemySupport enemySupport)
            {
                _enemySupportPool.ReturnObject(enemySupport);
            }
            else if (enemy is EnemySprinter enemySprinter)
            {
                _enemySprinterPool.ReturnObject(enemySprinter);
            }
        }
        
    }
}
