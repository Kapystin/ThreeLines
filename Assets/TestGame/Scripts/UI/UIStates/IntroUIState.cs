using TestGame.Scripts.UI.IntroPanel;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace TestGame.Scripts.UI.UIStates
{
    public class IntroUIState : UIBaseState
    {
        public override void Init(Transform canvasTransform, object data)
        {
            Addressables.LoadAssetAsync<GameObject>("UI/IntroPanel").Completed += (asyncOperationHandle) =>            
            {
                if (asyncOperationHandle.Status != UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError($"Can't load asset (status:{asyncOperationHandle.Status}): UI/IntroPanel");
                    return;
                }

                _view = Object.Instantiate(asyncOperationHandle.Result.GetComponent<IntroPanelView>(), canvasTransform);
                _view.OnInitComplete += (v) =>
                {
                    _model = new IntroPanelModel();
                    _viewModel = new IntroPanelViewModel((IntroPanelView)_view, (IntroPanelModel)_model);
                    
                    _model.AddListeners();
                    _viewModel.AddListeners();
                };
            };
        }
    }
}