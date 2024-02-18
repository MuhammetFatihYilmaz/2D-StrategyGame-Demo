using UnityEngine;

namespace StrategyGame.GameCore.MVC
{
    public abstract class MVCBase<T> : MonoBehaviour, IMVC where T : IMVCDriver
    {
        protected T MVCDriver { get; private set; }

        public void InitializeDriver(IMVCDriver driver)
        {
            MVCDriver = (T)driver;
        }
    }
}
