namespace Command.UI
{
    public class GameplayUIController : IUIController
    {
        private GameplayUIView gameplayView;

        public GameplayUIController(GameplayUIView gameplayView) => this.gameplayView = gameplayView;

        public void Show() => gameplayView.EnableView();

        public void SetTurnNumber(int turnNumber) => gameplayView.SetTurnText($"Turn: {turnNumber}");
    }
}