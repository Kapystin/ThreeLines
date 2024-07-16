using TestGame.Scripts.Interfaces;
using UnityEngine.SceneManagement;

namespace TestGame.Scripts.UI.WinPanel
{
    public class WinPanelViewModel : IViewModel
    {
        private readonly WinPanelView _view;
        private readonly WinPanelModel _model;
        
        public WinPanelViewModel(WinPanelView view, WinPanelModel model)
        {
            _view = view;
            _model = model;
        }
        
        public void AddListeners()
        {
            _view.OnRestartButtonClick += OnRestartButtonClick;
        }

        public void RemoveListeners()
        {
            _view.OnRestartButtonClick -= OnRestartButtonClick;
        }

        private void OnRestartButtonClick()
        {
            var sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }
    }
}