using UnityEngine;
using UnityEngine.UI;

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
