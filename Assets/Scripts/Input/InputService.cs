using Command.Main;
using Command.Player;
using Command.Actions;

namespace Command.Input
{
    public class InputService
    {
        private MouseInputHandler mouseInputHandler;

        private InputState currentState;
        private ActionType selectedActionType;
        private TargetType targetType;

        public InputService()
        {
            mouseInputHandler = new MouseInputHandler(this);
            SetInputState(InputState.INACTIVE);
            SubscribeToEvents();
        }

        public void SetInputState(InputState inputStateToSet) => currentState = inputStateToSet;

        private void SubscribeToEvents() => GameService.Instance.EventService.OnActionSelected.AddListener(OnActionSelected);

        public void UpdateInputService()
        {
            if(currentState == InputState.SELECTING_TARGET)
                mouseInputHandler.HandleTargetSelection(targetType);
        }

        public void OnActionSelected(ActionType selectedActionType)
        {
            this.selectedActionType = selectedActionType;
            SetInputState(InputState.SELECTING_TARGET);
            SetTargetType(selectedActionType);
        }

        private void SetTargetType(ActionType selectedActionType)
        {
            targetType = GameService.Instance.ActionService.GetTargetTypeForAction(selectedActionType);

            var isPlayer1 = GameService.Instance.PlayerService.isPlayer1Active();
            GameService.Instance.UIService.ToggleTargetChoosingBackgroundOverLay(isPlayer1, targetType);
        }

        public void OnTargetSelected(UnitController targetUnit)
        {
            SetInputState(InputState.EXECUTING_INPUT);

            GameService.Instance.PlayerService.PerformAction(selectedActionType, targetUnit);
        }
    }
}