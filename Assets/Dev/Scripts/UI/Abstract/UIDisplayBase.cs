using StrategyGame.Management.ObjectPoolManagement;
using UnityEngine;

namespace StrategyGame.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIDisplayBase : MonoBehaviour, IObjectPoolItem
    {
        private CanvasGroup canvasGroup;

        protected virtual void Awake()
        {
            TryGetComponent(out canvasGroup);
        }

        public void Show()
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }
        public void Hide()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
    }
}
