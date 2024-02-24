using StrategyGame.ScriptableScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace StrategyGame.Management.ObjectPoolManagement
{
    public class ObjectPoolManager : ManagerBase
    {
        public static ObjectPoolManager Instance { get; private set; }
        [SerializeField] private List<ManagerBase> managerList;
        [SerializeField] private List<PoolPrefabSO> poolPrefabList;
        [SerializeField] private List<GameBaseSO> SOList;
        private List<ObjectPoolRegisterType> objectPoolRegisterTypeList;
        private List<ObjectPoolUnit> currentObjectPoolUnitList;


        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        protected override IEnumerator InitSequence()
        {
            Debug.Log("ObjectPoolManager Init");
            objectPoolRegisterTypeList ??= new List<ObjectPoolRegisterType>();
            currentObjectPoolUnitList ??= new List<ObjectPoolUnit>();
            foreach (var prefabUnits in poolPrefabList)
            {
                foreach (var unit in prefabUnits.RegisterPrefabType())
                {
                    RegisterPrefab(unit);
                }
            }
            yield return new WaitForSeconds(2f);
        }

        private void RegisterPrefab(ObjectPoolRegisterType unit)
        {
            objectPoolRegisterTypeList.Add(unit);
        }

        public void PushPrefab<T>(T Prefab, string UID = "") where T: IObjectPoolItem
        {
            if (Prefab == null) return;
            if (!(Prefab is MonoBehaviour)) return;
            var unit = currentObjectPoolUnitList.Find(x => x.ObjectUnitType.Type == typeof(T) && x.ObjectUnitType.UID == UID);

            if (unit != null)
            {
                unit.AddPrefabToPool(Prefab);
            }
            else
            {
                var prefabRegisterType = objectPoolRegisterTypeList.Find(x => x.Type == typeof(T) && x.UID == UID);
                unit = new ObjectPoolUnit(prefabRegisterType);
                unit.AddPrefabToPool(Prefab);
                currentObjectPoolUnitList.Add(unit);
            }

            (Prefab as MonoBehaviour).gameObject.SetActive(false);
            (Prefab as MonoBehaviour).transform.SetParent(this.transform);
        }

        public async Task<T> PullPrefab<T>(Transform parent = null, string UID = "") where T: IObjectPoolItem
        {
            var unit = currentObjectPoolUnitList.Find(x => x.ObjectUnitType.Type == typeof(T) && x.ObjectUnitType.UID == UID);

            if (unit == null)
            {
                var prefabType = objectPoolRegisterTypeList.Find(x => x.Type == typeof(T) && x.UID == UID);
                var addressableObj = AddressableInstantiate(prefabType.AssetReference);
                await addressableObj;

                addressableObj.Result.TryGetComponent<T>(out T prefab);
                addressableObj.Result.SetActive(true);
                addressableObj.Result.transform.SetParent(parent);
                return prefab;
            }
            else
            {
                var prefab = unit.PullPrefabToPool();
                if (!unit.IsHaveAnyPooledPrefab())
                    currentObjectPoolUnitList.Remove(unit);
                (prefab as MonoBehaviour).gameObject.SetActive(true);
                (prefab as MonoBehaviour).transform.SetParent(parent);
                return (T)prefab;
            }
        }

        public T PullScriptable<T>() where T : GameBaseSO
        {
            var scriptableObject = SOList.Find(x => x.GetType() == typeof(T));
            if (scriptableObject == null) return default;
            return scriptableObject as T;
        }

        public T PullManager<T>() where T : ManagerBase
        {
            var manager = managerList.Find(x => x is T);
            if (!manager) return default;
            return manager as T;
        }

        public async Task<GameObject> AddressableInstantiate(AssetReference assetReference)
        {
            AsyncOperationHandle<GameObject> task = Addressables.InstantiateAsync(assetReference);
            await task.Task;
            return task.Result;
        }
    }
}
