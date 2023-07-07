using Command.Commands;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.UI
{
    public class ActionSelectionUIController : IUIController
    {
        private ActionSelectionUIView actionSelectionView;
        private ActionButtonView actionButtonPrefab;
        private List<ActionButtonView> actionButtons;

        public ActionSelectionUIController(ActionSelectionUIView actionSelectionView, ActionButtonView actionButtonPrefab)
        {
            this.actionSelectionView = actionSelectionView;
            this.actionButtonPrefab = actionButtonPrefab;
            InitializeController();
        }

        private void InitializeController()
        {
            actionButtons = new List<ActionButtonView>();
            Hide();
        }

        public void Show(List<CommandType> executableCommands)
        {
            actionSelectionView.EnableView();
            CreateActionButtons(executableCommands);
        }

        public void Hide()
        {
            ResetActionButtons();
            actionSelectionView.DisableView();
        }

        private void ResetActionButtons()
        {
            actionButtons.ForEach(button => Object.Destroy(button));
            actionButtons.Clear();
        }

        private void CreateActionButtons(List<CommandType> executableCommands)
        {
            foreach(CommandType commandType in executableCommands)
            {
                var button = actionSelectionView.AddButton(actionButtonPrefab);
                button.SetOwner(this);
                button.SetCommandType(commandType);
            }
        }

        // To Learn more about Events and Observer Pattern, check out the course list here: https://outscal.com/courses
        public void OnActionSelected(CommandType commandType)
        {
            GameService.Instance.EventService.OnActionSelected.InvokeEvent(commandType);
            Hide();
        }

    }
}