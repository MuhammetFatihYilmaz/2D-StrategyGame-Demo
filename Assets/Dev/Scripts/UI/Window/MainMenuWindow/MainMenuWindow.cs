using StrategyGame.Events;
using System;
using UnityEngine;

namespace StrategyGame.UI.Window.MainMenuWindow
{
    public class MainMenuWindow : UIDisplayBase
    {
        [SerializeField] private MainPanel mainPanel;
        [SerializeField] private SelectMapPanel selectMapPanel;

        private void OnEnable()
        {
            GameEvents.MainMenuEvents.OnStartGameButtonClicked += OnStartGameButtonClicked;
        }

        private void OnDisable()
        {
            GameEvents.MainMenuEvents.OnStartGameButtonClicked -= OnStartGameButtonClicked;   
        }

        #region Events
        private void OnStartGameButtonClicked()
        {
            selectMapPanel.Show();
        }
        #endregion
    }
}
