using UnityEngine;

namespace StrategyGame.GameCore.MVC
{
    public abstract class MVCBase<T> : MonoBehaviour, IMVC where T : IMVCDriver
    {
        protected T MVCDriver { get; private set; }

        protected virtual void OnEnable()
        {
            
        }

        protected virtual void OnDisable()
        {
            
        }

        public void InitializeDriver(IMVCDriver driver)
        {
            MVCDriver = (T)driver;
        }
    }
}
