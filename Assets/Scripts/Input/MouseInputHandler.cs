using UnityEngine;

namespace Command.Input
{
    public class MouseInputHandler
    {
        private InputService inputService;

        public MouseInputHandler(InputService inputService)
        {
            this.inputService = inputService;
        }

        public void HandleActionSelction()
        {
            if(UnityEngine.Input.GetMouseButtonDown(0))
            {
                TrySelectingAction();
            }
        }

        public void HandleTargetSelection()
        {
            if(UnityEngine.Input.GetMouseButtonDown(0))
            {
                TrySelectingTargetUnit();
            }
        }

        private void TrySelectingAction()
        {
            // Try Selecting an action here.
            // Inform the Input Service what Action has been Selected.

            // If an action is selected, create a command for it
            // Pass that command through the game service, which pushes it down the stream.
            // Parallely also let the ReplayService know what command has been executed.
            // Whenever that command needs to be executed, it is executed through the command invoker.
        }

        public void TrySelectingTargetUnit()
        {
            // Try Selecting a unit here.
            // Inform the Input Service what Target has been selected.

            // If a unit is selected, create a command for it
            // Pass that command through the game service, which pushes it down the stream.
            // Parallely also let the ReplayService know what command has been executed.
            // Whenever that command needs to be executed, it is executed through the command invoker.
        }
    }
}