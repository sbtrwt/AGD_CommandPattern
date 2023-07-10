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

        public void OnUndoButtonClicked() => GameService.Instance.CommandInvoker.Undo();
    }
}