using Command.Main;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Commands
{
    public class CommandInvoker
    {
        private Stack<ICommand> commandRegistry = new Stack<ICommand>();

        public void ProcessCommand(ICommand commandToProcess)
        {
            UpdateInputState();
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }

        public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();

        public void RegisterCommand(ICommand commandToRegister) => commandRegistry.Push(commandToRegister);

        public void Undo() => commandRegistry.Pop().Undo();


        public void SetReplayStack()
        {
            // This is called when the level has ended.
            // It informs the replay service what is the sequence of command that will be needed to replay the game.
        }

        private void UpdateInputState()
        {
            if(GameService.Instance.ReplayService.ReplayState == Replay.ReplayState.ACTIVE)
            {
                // TODO : Inform Replay Service that a command is being processed right now.
            }
            else
            {
                GameService.Instance.InputService.SetInputState(Input.InputState.EXECUTING_INPUT);
            }

        }
    }
}