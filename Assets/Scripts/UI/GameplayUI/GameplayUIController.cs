using Command.Input;
using Command.Main;

namespace Command.UI
{
    public class GameplayUIController : IUIController
    {
        private GameplayUIView gameplayView;

        public GameplayUIController(GameplayUIView gameplayView)
        {
            this.gameplayView = gameplayView;
            this.gameplayView.SetController(this);
        }

        public void Show() => gameplayView.EnableView();

        public void SetTurnNumber(int turnNumber) => gameplayView.SetTurnText($"Turn: {turnNumber}");

        public void ToggleActionChoosingBackgroundOverLay(bool isPlayer1) => gameplayView.ToggleActionChoosingBackgroundOverLay(isPlayer1);

        public void ToggleTargetChoosingBackgroundOverLay(bool isPlayer, TargetType targetType) => gameplayView.ToggleTargetChoosingBackgroundOverLay(isPlayer, targetType);

        public void ResetBattleBackgroundOverlay() => gameplayView.ResetBackgroundOverlay();

        public void ShowMissedAction() => gameplayView.ShowMissedText();
    }
}