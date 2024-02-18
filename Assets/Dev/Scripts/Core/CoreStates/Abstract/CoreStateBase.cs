using StrategyGame.GameCore.MVC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StrategyGame.GameCore.CoreStates
{
    public abstract class CoreStateBase : MonoBehaviour, IState, IMVCDriver
    {
        protected IStateDriver StateDriver { get; private set; }
        public CoreStateCommonValue CommonValue { get; private set; }

        protected virtual void Awake()
        {
            var mvcList = GenerateMVC()?.Where(x=> x != null).ToList();
            if (mvcList == null) return;

            foreach (var item in mvcList)
            {
                item?.InitializeDriver(this);
            }
        }

        public abstract void OnSet();
        public abstract void OnUnSet();
        protected abstract IEnumerable<IMVC> ApplyMVCValues();

        public void SetStateDriver(IStateDriver stateDriver)
        {
            StateDriver = stateDriver;
        }

        public void SetCommonValues(IStateCommonValue commonValue)
        {
            CommonValue = (CoreStateCommonValue)commonValue;
        }

        public IEnumerable<IMVC> GenerateMVC()
        {
            return ApplyMVCValues();
        }
    }
}
