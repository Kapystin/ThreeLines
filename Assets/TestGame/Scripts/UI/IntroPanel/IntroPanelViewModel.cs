using TestGame.Scripts.Enums;
using TestGame.Scripts.Interfaces;
using TestGame.Scripts.UI.UIStates;

namespace TestGame.Scripts.UI.IntroPanel
{
    public class IntroPanelViewModel : IViewModel
    {
        private readonly IntroPanelView _view;
        private readonly IntroPanelModel _model;
        
        public IntroPanelViewModel(IntroPanelView view, IntroPanelModel model)
        {
            _view = view;
            _model = model;
        }
        
        public void AddListeners()
        {
            _view.OnStartButtonClick += OnStartButtonClick;
        }

        public void RemoveListeners()
        {
            _view.OnStartButtonClick -= OnStartButtonClick;
        }
        
        private void OnStartButtonClick()
        {
            _view.Destroy();
            GameStateMachine.Instance.SetState(GameStateType.Play);
        }
    }
}