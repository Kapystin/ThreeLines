using TestGame.Scripts.Interfaces;
using UnityEngine.SceneManagement;

namespace TestGame.Scripts.UI.LosePanel
{
    public class LosePanelViewModel : IViewModel
    {
        private readonly LosePanelView _view;
        private readonly LosePanelModel _model;
        
        public LosePanelViewModel(LosePanelView view, LosePanelModel model)
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