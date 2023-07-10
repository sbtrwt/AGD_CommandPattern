using Command.Main;
using System.Collections.Generic;

namespace Command.Commands
{
    public class CommandInvoker
    {
        private Stack<ICommand> commandRegistry = new Stack<ICommand>();

        public CommandInvoker() => SubscribeToEvents();

        private void SubscribeToEvents() => GameService.Instance.EventService.OnReplayButtonClicked.AddListener(SetReplayStack);

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
            GameService.Instance.ReplayService.SetCommandStack(commandRegistry);
            commandRegistry.Clear();
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