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
        private PlayerController owner;
        private UnitScriptableObject unitScriptableObject;

        private int unitId;
        private UnitState currentUnitState;

        public int UnitID => unitId;
        public PlayerController Owner => owner;
        public UnitState CurrentUnitState => currentUnitState;

        public UnitController(PlayerController owner, UnitScriptableObject unitScriptableObject)
        {
            this.owner = owner;
            this.unitScriptableObject = unitScriptableObject;
            unitId = unitScriptableObject.UnitID;
            currentUnitState = UnitState.NOT_USED;
        }

        public void StartUnitTurn()
        {
            /*  TODO:
             *  Update UI for Active Unit. (A Pointer Maybe. Should be part of the UnitView)
             *  Update UI for Action Selection. (UIService)
             *  Update Input State for Action Selection.
             */
            GameService.Instance.UIService.ConfigureCommandSelectionUI(unitScriptableObject.executableCommands);
            GameService.Instance.InputService.SetInputState(InputState.SELECTING_ACTION);
        }

        public void ProcessUnitCommand(IUnitCommand commandToProcess)
        {
            commandToProcess.SetActorUnit(this);
            GameService.Instance.CommandInvoker.ProcessCommand(commandToProcess);
        }

    }

    public enum UnitState
    {
        USED,
        NOT_USED
    }
}