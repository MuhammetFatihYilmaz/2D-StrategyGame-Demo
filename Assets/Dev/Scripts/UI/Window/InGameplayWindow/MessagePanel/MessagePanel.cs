using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using StrategyGame.Events;
using System;
using StrategyGame.Management.ObjectPoolManagement;

namespace StrategyGame.UI.Window.InGameplayWindow.Message
{
    public class MessagePanel : UIDisplayBase
    {
        [SerializeField] private TextMeshProUGUI messageText;
        private AllMessageSO allMessageSO;
        private List<string> messageTaskList = new();
        private bool isDisplayingStarted;

        protected override void Awake()
        {
            base.Awake();
            allMessageSO = ObjectPoolManager.Instance.PullScriptable<AllMessageSO>();
        }

        private void OnEnable()
        {
            GameEvents.GameplayEvents.OnUnitSpawnPointNotAvailable += OnUnitSpawnPointNotAvailable;
        }

        private void OnDisable()
        {
            GameEvents.GameplayEvents.OnUnitSpawnPointNotAvailable -= OnUnitSpawnPointNotAvailable;
        }

        private IEnumerator MessageDisplaySequence()
        {
            isDisplayingStarted = true;
            while (messageTaskList.Any())
            {
                messageText.text = messageTaskList[0];
                yield return new WaitForSeconds(2.5f);
                messageTaskList.RemoveAt(0);
            }
            messageText.text = string.Empty;
            isDisplayingStarted = false;
        }

        public void StartMessageTask(string message)
        {
            messageTaskList.Add(message);
            if (isDisplayingStarted) return;
            StartCoroutine(MessageDisplaySequence());
        }

        #region Events
        private void OnUnitSpawnPointNotAvailable()
        {
            var messageSO = allMessageSO.AllMessageSOList.Find(x => x.MessageMap.MessageType == MessageType.UnitSpawnPointNotAvailable);

            if (messageTaskList.Contains(messageSO.MessageMap.Message)) return;
            StartMessageTask(messageSO.MessageMap.Message);
        }
        #endregion
    }
}
