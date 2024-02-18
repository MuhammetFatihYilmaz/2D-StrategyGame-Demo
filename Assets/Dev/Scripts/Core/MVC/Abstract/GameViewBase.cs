using StrategyGame.Management.ObjectPoolManagement;
using StrategyGame.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.GameCore.MVC
{
    public abstract class GameViewBase<T> : MVCBase<T> where T: IMVCDriver
    {
        private List<UIDisplayBase> currentWindowsList = new();

        protected async Task<U> LoadWindow<U>() where U : UIDisplayBase
        {
            if (currentWindowsList.Any(x => x is U)) return null;
            var task = ObjectPoolManager.Instance.PullPrefab<U>(parent: this.transform);
            await task;
            currentWindowsList.Add(task.Result);
            task.Result.Show();
            return task.Result;
        }
        protected void UnLoadWindow<U>() where U : UIDisplayBase
        {
            if (currentWindowsList.Any(x => x is U))
            {
                var window = currentWindowsList.Find(x => x.GetType() == typeof(U));
                window.Hide();
                currentWindowsList.Remove(window);
            }
        }
    }
}
