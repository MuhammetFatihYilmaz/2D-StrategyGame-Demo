using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace StrategyGame.UI.Window.LoadingWindow
{
    public class LoadingWindow : UIDisplayBase
    {
        private bool isLoadingStarted;
        private List<CustomYieldInstruction> loadingTasks = new();

        private IEnumerator LoadingTaskSequence()
        {
            isLoadingStarted = true;
            Show();
            while (loadingTasks.Any())
            {
                yield return loadingTasks[0];
                loadingTasks.RemoveAt(0);
            }
            Hide();
            isLoadingStarted = false;
        }

        public void StartLoadingTask(CustomYieldInstruction yieldInstruction)
        {
            loadingTasks.Add(yieldInstruction);
            if (isLoadingStarted) return;
                StartCoroutine(LoadingTaskSequence());
        }
    }
}
