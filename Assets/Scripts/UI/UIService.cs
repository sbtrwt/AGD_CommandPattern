using System.Collections.Generic;
using UnityEngine;
using Command.Commands;
using Command.Main;

namespace Command.UI
{
    public class UIService : MonoBehaviour
    {
        private BattleSelectionController battleSelectionController;
        [SerializeField] private BattleSelectionView battleSelectionView;
        [SerializeField] private BattleButtonView battleButtonPrefab;

        private void Start()
        {
            battleSelectionController = new BattleSelectionController(battleSelectionView, battleButtonPrefab);
        }

        public void ShowBattleSelection(int battleCount) => battleSelectionController.Show(battleCount);

        public void ConfigureCommandSelectionUI(List<CommandType> executableCommands)
        {
            // Configure Action Selection Buttons inisde a vertical layout group.
        }

        public void OnActionSelected(CommandType selectedAction)
        {

        }
    }
}