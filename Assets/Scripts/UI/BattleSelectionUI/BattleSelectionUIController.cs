using System.Collections.Generic;
using UnityEngine;
using Command.Main;

namespace Command.UI
{
    public class BattleSelectionUIController : IUIController
    {
        private BattleSelectionUIView battleSelectionView;
        private BattleButtonView battleButtonPrefab;
        private List<BattleButtonView> battleButtons;

        public BattleSelectionUIController(BattleSelectionUIView battleSelectionView, BattleButtonView battleButtonPrefab)
        {
            this.battleSelectionView = battleSelectionView;
            this.battleButtonPrefab = battleButtonPrefab;
            InitializeController();
        }

        private void InitializeController()
        {
            battleButtons = new List<BattleButtonView>();
            Hide();
        }

        public void Show(int battleCount)
        {
            battleSelectionView.EnableView();
            CreateBattleButtons(battleCount);
        }

        public void Hide()
        {
            ResetBattleButtons();
            battleSelectionView.DisableView();
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

        // To Learn more about Events and Observer Pattern, check out the course list here: https://outscal.com/courses
        public void OnBattleSelected(int battleId)
        {
            GameService.Instance.EventService.OnBattleSelected.InvokeEvent(battleId);
            Hide();
        }
    }
}