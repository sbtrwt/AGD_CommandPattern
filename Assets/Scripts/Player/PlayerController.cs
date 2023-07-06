using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Commands;

namespace Command.Player
{
    public class PlayerController
    {
        private PlayerService playerService;

        private int playerId;
        private List<UnitController> units;
        private int activeUnitIndex;

        public int PlayerID => playerId;
        public int ActiveUnitID => units[activeUnitIndex].UnitID;

        public PlayerController(PlayerService playerService, PlayerScriptableObject playerScriptableObject)
        {
            this.playerService = playerService;
            playerId = playerScriptableObject.PlayerID;
            InitializeUnits(playerScriptableObject.UnitData);
        }

        private void InitializeUnits(List<UnitScriptableObject> unitScriptableObjects)
        {
            units.Clear();

            foreach (UnitScriptableObject unitSO in unitScriptableObjects)
            {
                units.Add(new UnitController(this, unitSO));
            }
        }

        public void StartPlayerTurn()
        {
            activeUnitIndex = 0;
            units[activeUnitIndex].StartUnitTurn();
        }

        public void OnUnitTurnEnded()
        {
            if(AllUnitsUsed())
            {
                EndPlayerTurn();
            }
            else
            {
                activeUnitIndex++;
                units[activeUnitIndex].StartUnitTurn();
            }
        }

        private bool AllUnitsUsed() => units.TrueForAll(unit => unit.CurrentUnitState == UnitState.USED);

        private void EndPlayerTurn()
        {
            playerService.OnPlayerTurnCompleted();
        }

        public UnitController GetUnitByID(int unitId) => units.Find(unit => unit.UnitID == unitId);

        public void ProcessUnitCommand(IUnitCommand commandToProcess)
        {
            commandToProcess.SetPlayer(this);
            GetUnitByID(commandToProcess.OwnerUnitID).ProcessUnitCommand(commandToProcess);
        }
    }
}