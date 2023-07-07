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
            CreateUnits(playerScriptableObject.UnitData, playerScriptableObject.UnitPositions);
        }

        private void CreateUnits(List<UnitScriptableObject> unitScriptableObjects, List<Vector3> unitPositions)
        {
            units = new List<UnitController>();

            for(int i=0; i<unitScriptableObjects.Count; i++)
            {
                units.Add(new UnitController(this, unitScriptableObjects[i], unitPositions[i]));
            }
        }

        public void StartPlayerTurn()
        {
            activeUnitIndex = 0;
            ResetAllUnitStates();

            if (IsCurrentUnitAlive())
                units[activeUnitIndex].StartUnitTurn();
            else
                OnUnitTurnEnded();
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

        private void ResetAllUnitStates() => units.ForEach(unit => unit.SetUsedState(UnitUsedState.NOT_USED));

        private bool IsCurrentUnitAlive() => units[activeUnitIndex].IsAlive();

        private bool AllUnitsUsed() => units.TrueForAll(unit => unit.UsedState == UnitUsedState.USED);

        private void EndPlayerTurn() => playerService.OnPlayerTurnCompleted();



        // After Initialization is Done: 

        public UnitController GetUnitByID(int unitId) => units.Find(unit => unit.UnitID == unitId);

        public void ProcessUnitCommand(IUnitCommand commandToProcess)
        {
            commandToProcess.SetPlayer(this);
            GetUnitByID(commandToProcess.OwnerUnitID).ProcessUnitCommand(commandToProcess);
        }
    }
}