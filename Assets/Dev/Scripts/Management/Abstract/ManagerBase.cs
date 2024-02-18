using System.Collections;
using UnityEngine;

namespace StrategyGame.Management
{
    public abstract class ManagerBase : MonoBehaviour
    {
        protected abstract IEnumerator InitSequence();

        public bool IsManagerInitialized { get; private set; }

        public IEnumerator InitManager()
        {
            yield return InitSequence();
            IsManagerInitialized = true;
        }
    }
}
