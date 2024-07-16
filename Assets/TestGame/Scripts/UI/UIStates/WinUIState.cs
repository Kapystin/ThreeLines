using TestGame.Scripts.UI.LosePanel;
using TestGame.Scripts.UI.WinPanel;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TestGame.Scripts.UI.UIStates
{
    public class WinUIState : UIBaseState
    {
        public override void Init(Transform canvasTransform, object data)
        {
            Addressables.LoadAssetAsync<GameObject>("UI/WinPanel").Completed += (asyncOperationHandle) =>            
            {
                if (asyncOperationHandle.Status != UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError($"Can't load asset (status:{asyncOperationHandle.Status}): UI/WinPanel");
                    return;
                }

                _view = Object.Instantiate(asyncOperationHandle.Result.GetComponent<WinPanelView>(), canvasTransform);
                _view.OnInitComplete += (v) =>
                {
                    _model = new WinPanelModel();
                    _viewModel = new WinPanelViewModel((WinPanelView)_view, (WinPanelModel)_model);
                    
                    _model.AddListeners();
                    _viewModel.AddListeners();
                };
            };
        }
    }
}