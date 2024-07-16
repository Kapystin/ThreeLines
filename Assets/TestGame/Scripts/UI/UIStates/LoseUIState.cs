using TestGame.Scripts.UI.LosePanel;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TestGame.Scripts.UI.UIStates
{
    public class LoseUIState: UIBaseState
    {
        public override void Init(Transform canvasTransform, object data)
        {
            Addressables.LoadAssetAsync<GameObject>("UI/LosePanel").Completed += (asyncOperationHandle) =>            
            {
                if (asyncOperationHandle.Status != UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError($"Can't load asset (status:{asyncOperationHandle.Status}): UI/LosePanel");
                    return;
                }

                _view = Object.Instantiate(asyncOperationHandle.Result.GetComponent<LosePanelView>(), canvasTransform);
                _view.OnInitComplete += (v) =>
                {
                    _model = new LosePanelModel();
                    _viewModel = new LosePanelViewModel((LosePanelView)_view, (LosePanelModel)_model);
                    
                    _viewModel.AddListeners();
                    _model.AddListeners();
                };
            };
        }
    }
}