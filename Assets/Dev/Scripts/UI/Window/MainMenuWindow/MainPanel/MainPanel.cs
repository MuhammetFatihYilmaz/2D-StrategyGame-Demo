using StrategyGame.Events;
using UnityEngine;
using UnityEngine.UI;

namespace StrategyGame.UI.Window.MainMenuWindow
{
    public class MainPanel : UIDisplayBase
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button exitGameButton;

        private void OnEnable()
        {
            startGameButton.onClick.AddListener(StartGameClick);
            exitGameButton.onClick.AddListener(ExitGameClick);
        }

        private void OnDisable()
        {
            startGameButton.onClick.RemoveListener(StartGameClick);
            exitGameButton.onClick.RemoveListener(ExitGameClick);
        }

        private void StartGameClick()
        {
            GameEvents.MainMenuEvents.OnStartGameButtonClicked?.Invoke();
        }

        private void ExitGameClick()
        {
            GameEvents.MainMenuEvents.OnExitGameButtonClicked?.Invoke();
        }
    }
}
