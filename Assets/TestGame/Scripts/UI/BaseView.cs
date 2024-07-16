using TestGame.Scripts.Interfaces;
using UnityEngine;

namespace TestGame.Scripts.UI
{
    public class BaseView : MonoBehaviour, IView
    {
        public event ViewInitComplete OnInitComplete;
        
        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void Start()
        {
            OnInitComplete?.Invoke(this);
        }
        
        public virtual void AddListeners() {}

        public virtual void RemoveListeners() {}

        public virtual void Destroy()
        {
            RemoveListeners();
            Destroy(gameObject);
        }
    }
}