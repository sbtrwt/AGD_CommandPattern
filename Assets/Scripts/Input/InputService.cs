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
            switch(currentState)
            {
                case InputState.SELECTING_ACTION:

                    break;
                case InputState.SELECTING_TARGET:
                    mouseInputHandler.HandleTargetSelection();
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
        }


        // TODO After Target Selection is done.


        public void OnTargetSelected(UnitController targetUnit)
        {
            /*  TODO:
             *  Create a new command for the selected command type.
             *  Push this newly created Unit Action Command down the stream through the GameService.
             */

            /*CommandData commandData = GetCommandData(targetUnit);
            IUnitCommand commandToProcess;

            switch (selectedCommandType)
            {
                case CommandType.Attack:
                    commandToProcess = new AttackCommand(commandData);
                    break;
                case CommandType.Heal:
                    commandToProcess = new HealCommand(commandData);
                    break;
                default:
                    throw new System.Exception($"No Command found of type: {selectedCommandType}");
            }

            GameService.Instance.ProcessUnitCommand(commandToProcess);*/
        }

        private CommandData GetCommandData(UnitController targetUnit)
        {
            int playerID = GameService.Instance.PlayerService.ActivePlayerID;
            int actorUnitId = GameService.Instance.PlayerService.ActiveUnitID;
            return new CommandData(playerID, actorUnitId, targetUnit.Owner.PlayerID, targetUnit.UnitID);
        }

    }
}