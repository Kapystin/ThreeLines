using UnityEngine;

namespace TestGame.Scripts.UI
{
    public class UIStateMachine : MonoBehaviour
    {
        public static UIStateMachine Instance => _instance;
        private static UIStateMachine _instance;
            
        [SerializeField] private Canvas _mainCanvas;
        
        private UIBaseState _currentUIState;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != null)
            {
                Destroy(gameObject);
            }
        }
        
        public void SetState(UIBaseState state)
        {
            object data = null;
            var parentTransform = _mainCanvas.transform;
            
            _currentUIState = state;
            _currentUIState.Init(parentTransform, data);
        }
    }
}