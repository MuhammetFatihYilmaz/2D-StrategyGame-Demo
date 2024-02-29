using UnityEngine;
using UnityEngine.UI;
using StrategyGame.UI.Window.InGameplayWindow.Production;
using StrategyGame.UI.Window.InGameplayWindow.Settings;

namespace StrategyGame.UI.Window.InGameplayWindow
{
    public class InGameplayWindow : UIDisplayBase
    {
        [SerializeField] private ProductionPanel productionPanel;
        [SerializeField] private SettingsPanel settingsPanel;
        [SerializeField] private Button settingsButton;

        protected override void Awake()
        {
            base.Awake();
            settingsButton.onClick.AddListener(settingsPanel.Show);
        }
    }
}
