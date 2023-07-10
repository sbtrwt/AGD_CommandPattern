using UnityEngine;
using Command.Main;
using Command.Commands;
using Command.UI;
using Command.Player;

namespace Command.Input
{
    public class InputService
    {
        private MouseInputHandler mouseInputHandler;

        private InputState currentState;
        private CommandType selectedCommandType;
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
            switch (currentState)
            {
                case InputState.SELECTING_ACTION:

                    break;
                case InputState.SELECTING_TARGET:
                    mouseInputHandler.HandleTargetSelection(targetType);
                    break;
                case InputState.EXECUTING_INPUT:

                    break;
                case InputState.INACTIVE:

                    break;
            }

        }

        public void OnActionSelected(CommandType selectedCommandType)
        {
            this.selectedCommandType = selectedCommandType;
            Debug.Log($"The Action Selected is {selectedCommandType}");
            SetInputState(InputState.SELECTING_TARGET);
            SetTargetType(selectedCommandType);
        }

        private void SetTargetType(CommandType selectedCommandType)
        {
            if (selectedCommandType == CommandType.Heal)
                targetType = TargetType.Friendly;
            else
                targetType = TargetType.Enemy;
        }

        public void OnTargetSelected(UnitController targetUnit)
        {
            SetInputState(InputState.EXECUTING_INPUT);
            UnitCommand commandToProcess = CreateUnitCommand(targetUnit);
            GameService.Instance.ProcessUnitCommand(commandToProcess);
        }

        private UnitCommand CreateUnitCommand(UnitController targetUnit)
        {
            switch (selectedCommandType)
            {
                case CommandType.Attack:
                    return new AttackCommand(GameService.Instance.PlayerService.ActiveUnitID,
                                             targetUnit.UnitID,
                                             GameService.Instance.PlayerService.ActivePlayerID,
                                             targetUnit.Owner.PlayerID);
                case CommandType.Heal:
                    return new HealCommand(GameService.Instance.PlayerService.ActiveUnitID,
                                           targetUnit.UnitID,
                                           GameService.Instance.PlayerService.ActivePlayerID,
                                           targetUnit.Owner.PlayerID);
                default:
                    throw new System.Exception($"No Command found of type: {selectedCommandType}");
            }
        }
    }

    public enum TargetType
    {
        Friendly,
        Enemy
    }
}