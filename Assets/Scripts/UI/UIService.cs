using System.Collections.Generic;
using UnityEngine;
using Command.Commands;
using Command.Main;

namespace Command.UI
{
    public class UIService : MonoBehaviour
    {
        // Battle Selection UI:
        private BattleSelectionUIController battleSelectionController;
        [SerializeField] private BattleSelectionUIView battleSelectionView;
        [SerializeField] private BattleButtonView battleButtonPrefab;

        // Gameplay UI:
        private GameplayUIController gameplayController;
        [SerializeField] private GameplayUIView gameplayView;

        private ActionSelectionUIController actionSelectionController;
        [SerializeField] private ActionSelectionUIView actionSelectionView;
        [SerializeField] private ActionButtonView actionButtonPrefab;

        private void Start()
        {
            battleSelectionController = new BattleSelectionUIController(battleSelectionView, battleButtonPrefab);
            gameplayController = new GameplayUIController(gameplayView);
            actionSelectionController = new ActionSelectionUIController(actionSelectionView, actionButtonPrefab);
        }

        public void ShowBattleSelectionView(int battleCount) => battleSelectionController.Show(battleCount);

        public void ShowGameplayView(Sprite backgroundImage)
        {
            gameplayController.Show();
            gameplayController.SetBackgroundImage(backgroundImage);
        }

        public void ShowActionSelectionView(List<CommandType> executableActions)
        {
            switch(GameService.Instance.ReplayService.ReplayState)
            {
                case Replay.ReplayState.ACTIVE:
                    // Tell the Replay Service to execute the next unit action command in the queue.
                    break;
                case Replay.ReplayState.DEACTIVE:
                    actionSelectionController.Show(executableActions);
                    break;
            }
        }

    }
}