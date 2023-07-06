using System.Collections.Generic;
using UnityEngine;
using Command.Main;

namespace Command.UI
{
    public class BattleSelectionController : IUIController
    {
        private BattleSelectionView battleSelectionView;
        private BattleButtonView battleButtonPrefab;
        private List<BattleButtonView> battleButtons;

        public BattleSelectionController(BattleSelectionView battleSelectionView, BattleButtonView battleButtonPrefab)
        {
            this.battleSelectionView = battleSelectionView;
            this.battleButtonPrefab = battleButtonPrefab;
            InitializeController(battleButtonPrefab);
        }

        private void InitializeController(BattleButtonView battleButtonPrefab)
        {
            battleButtons = new List<BattleButtonView>();
            ResetBattleButtons();
            Hide();
        }

        public void Show(int battleCount)
        {
            battleSelectionView.EnableView();
            CreateBattleButtons(battleCount);
        }

        public void Hide()
        {
            battleSelectionView.DisableView();
            ResetBattleButtons();
        }

        private void ResetBattleButtons()
        {
            battleButtons.ForEach(button => Object.Destroy(button.gameObject));
            battleButtons.Clear();
        }

        public void CreateBattleButtons(int battleCount)
        {
            for (int i = 1; i <= battleCount; i++)
            {
                var newButton = battleSelectionView.AddButton(battleButtonPrefab);
                newButton.SetOwner(this);
                newButton.SetBattleID(i);
            }
        }

        public void OnBattleSelected(int battleId)
        {
            GameService.Instance.EventService.OnBattleSelected.InvokeEvent(battleId);
            Hide();
        }
    }
}