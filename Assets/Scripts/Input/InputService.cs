using UnityEngine;
using Command.Main;
using Command.Commands;
using Command.UI;
using Command.Player;

namespace Command.Input
{
    public class InputService
    {
        private InputState currentState;
        private MouseInputHandler mouseInputHandlers;

        private CommandType selectedCommand;

        public InputService()
        {
            mouseInputHandlers = new MouseInputHandler(this);
            currentState = InputState.SELECTING_ACTION;
        }

        public void UpdateInputService()
        {
            switch(currentState)
            {
                case InputState.SELECTING_ACTION:
                    mouseInputHandlers.HandleActionSelction();
                    break;
                case InputState.SELECTING_TARGET:
                    mouseInputHandlers.TrySelectingTargetUnit();
                    break;
                case InputState.EXECUTING_INPUT:

                    break;
                case InputState.INACTIVE:

                    break;
            }

        }

        public void SetInputState(InputState inputStateToSet) => currentState = inputStateToSet;

        public void OnActionSelected(CommandType selectedCommand)
        {
            this.selectedCommand = selectedCommand;
            GameService.Instance.UIService.OnActionSelected(selectedCommand);
            currentState = InputState.SELECTING_TARGET;
        }

        public void OnTargetSelected(UnitController targetUnit)
        {
            CommandData commandData = GetCommandData(targetUnit);
            IUnitCommand commandToProcess;

            switch (selectedCommand)
            {
                case CommandType.Attack:
                    commandToProcess = new AttackCommand(commandData);
                    break;
                case CommandType.Heal:
                    commandToProcess = new HealCommand(commandData);
                    break;
                default:
                    throw new System.Exception($"No Command found of type: {selectedCommand}");
            }

            GameService.Instance.ProcessUnitCommand(commandToProcess);
        }

        private CommandData GetCommandData(UnitController targetUnit)
        {
            int playerID = GameService.Instance.PlayerService.GetActivePlayerId();
            int actorUnitId = GameService.Instance.PlayerService.GetActiveUnitId();
            return new CommandData(playerID, actorUnitId, targetUnit.Owner.PlayerID, targetUnit.UnitID);
        }

    }
}