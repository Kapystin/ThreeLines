using TestGame.Scripts.UI.IntroPanel;
using TestGame.Scripts.UI.PlayPanel;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TestGame.Scripts.UI.UIStates
{
    public class PlayUIState: UIBaseState
    {
        public override void Init(Transform canvasTransform, object data)
        {
            Addressables.LoadAssetAsync<GameObject>("UI/PlayPanel").Completed += (asyncOperationHandle) =>            
            {
                if (asyncOperationHandle.Status != UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError($"Can't load asset (status:{asyncOperationHandle.Status}): UI/PlayPanel");
                    return;
                }

                _view = Object.Instantiate(asyncOperationHandle.Result.GetComponent<PlayPanelView>(), canvasTransform);
                _view.OnInitComplete += (v) =>
                {
                    _model = new PlayPanelModel();
                    _viewModel = new PlayPanelViewModel((PlayPanelView)_view, (PlayPanelModel)_model);
                    
                    _viewModel.AddListeners();
                    _model.AddListeners();
                };
            };
        }
    }
}