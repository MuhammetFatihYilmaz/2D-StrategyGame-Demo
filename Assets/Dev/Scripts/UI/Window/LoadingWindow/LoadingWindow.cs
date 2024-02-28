using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace StrategyGame.UI.Window.LoadingWindow
{
    public class LoadingWindow : UIDisplayBase
    {
        private bool isLoadingStarted;
        private List<CustomYieldInstruction> loadingTaskList = new();

        private IEnumerator LoadingTaskSequence()
        {
            isLoadingStarted = true;
            Show();
            while (loadingTaskList.Any())
            {
                yield return loadingTaskList[0];
                loadingTaskList.RemoveAt(0);
            }
            Hide();
            isLoadingStarted = false;
        }

        public void StartLoadingTask(CustomYieldInstruction yieldInstruction)
        {
            loadingTaskList.Add(yieldInstruction);
            if (isLoadingStarted) return;
                StartCoroutine(LoadingTaskSequence());
        }
    }
}
