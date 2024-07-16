using TestGame.Scripts.Interfaces;
using UnityEngine;

namespace TestGame.Scripts.UI
{
    public abstract class UIBaseState
    {
        protected IViewModel _viewModel;
        protected IModel _model;
        protected IView _view;
        
        public abstract void Init(Transform canvasTransform, object data = null);
    }
}