using System.Collections.Generic;
using UnityEngine;
using Command.Commands;

namespace Command.UI
{
    public class UIService : MonoBehaviour
    {
        private BattleSelectionController battleSelectionController;






        public void ConfigureCommandSelectionUI(List<CommandType> executableCommands)
        {
            // Configure Action Selection Buttons inisde a vertical layout group.
        }

        public void OnActionSelected(CommandType selectedAction)
        {

        }
    }
}