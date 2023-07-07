using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;
using Command.Input;
using Command.Commands;

namespace Command.Player
{
    public class UnitController
    {
        public PlayerController Owner { get; private set; }
        private UnitScriptableObject unitScriptableObject;
        private UnitView unitView;

        public int UnitID { get; private set; }
        private UnitAliveState aliveState;
        public UnitUsedState UsedState { get; private set; }

        public UnitController(PlayerController owner, UnitScriptableObject unitScriptableObject, Vector3 unitPosition)
        {
            Owner = owner;
            this.unitScriptableObject = unitScriptableObject;
            UnitID = unitScriptableObject.UnitID;

            InitializeView(unitPosition);
            InitializeVariables();
        }

        private void InitializeView(Vector3 positionToSet)
        {
            unitView = Object.Instantiate(unitScriptableObject.UnitPrefab);
            unitView.Controller = this;
            unitView.transform.position = positionToSet;
            unitView.SetUnitIndicator(false);
        }

        private void InitializeVariables()
        {
            SetAliveState(UnitAliveState.ALIVE);
            SetUsedState(UnitUsedState.NOT_USED);
        }

        public void StartUnitTurn()
        {
            unitView.SetUnitIndicator(true);
            GameService.Instance.UIService.ShowActionSelectionView(unitScriptableObject.executableCommands);
            GameService.Instance.InputService.SetInputState(InputState.SELECTING_ACTION);
        }

        public void ProcessUnitCommand(IUnitCommand commandToProcess)
        {
            commandToProcess.SetActorUnit(this);
            GameService.Instance.CommandInvoker.ProcessCommand(commandToProcess);
        }

        private void SetAliveState(UnitAliveState stateToSet) => aliveState = stateToSet;

        public void SetUsedState(UnitUsedState stateToSet) => UsedState = stateToSet;

        public bool IsAlive() => aliveState == UnitAliveState.ALIVE;

    }

    public enum UnitUsedState
    {
        USED,
        NOT_USED
    }

    public enum UnitAliveState
    {
        ALIVE,
        DEAD
    }
}