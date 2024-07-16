using System.Threading;
using Cysharp.Threading.Tasks;
using TestGame.Scripts.Enemies;
using UnityEngine;

namespace TestGame.Scripts
{
    public class FinishLine : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _blinkDelay = 0.1f;
        
        
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        private void OnEnable()
        {
            _spriteRenderer.color = Color.white;
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Enemy>())
            {
                GameEventBus.Instance.OnPlayerGetDamageAction(other.gameObject.GetComponent<Enemy>());
                Blink();
            }
        }

        private async UniTask Blink()
        {
            if (_spriteRenderer == null || _cancellationToken.IsCancellationRequested) return;
                
            _spriteRenderer.color = Color.red;
            await UniTask.WaitForSeconds(_blinkDelay, cancellationToken: _cancellationToken);
            _spriteRenderer.color = Color.white;
        }
    }
}
