using StrategyGame.Events;
using UnityEngine;
using UnityEngine.UI;

namespace StrategyGame.UI.Window.InGameplayWindow.Settings
{
    public class SettingsPanel : UIDisplayBase
    {
        [SerializeField] private Button hideButton;
        [SerializeField] private Button mainMenuButton;

        private void OnEnable()
        {
            hideButton.onClick.AddListener(Hide);
            mainMenuButton.onClick.AddListener(MainMenuButtonClick);
        }

        private void OnDisable()
        {
            hideButton.onClick.RemoveListener(Hide);
            mainMenuButton.onClick.RemoveListener(MainMenuButtonClick);
        }

        private void MainMenuButtonClick()
        {
            Hide();
            GameEvents.GameplayEvents.OnSettingsMainMenuButtonClicked?.Invoke();
        }
    }
}
