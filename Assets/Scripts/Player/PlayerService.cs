using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Commands;

namespace Command.Player
{
    public class PlayerService
    {
        private List<BattleScriptableObject> battleData;
        private PlayerController player1;
        private PlayerController player2;

        private int currentTurnNumber;
        private PlayerController activePlayer;

        public PlayerService(List<BattleScriptableObject> battleScriptableObjects)
        {
            battleData = battleScriptableObjects;
        }

        public void InitializeBattle(int BattleID)
        {
            BattleScriptableObject battleConfig = battleData.Find(config => config.BattleID == BattleID);
            player1 = new PlayerController(this, battleConfig.Player1Data);
            player2 = new PlayerController(this, battleConfig.Player2Data);

            currentTurnNumber = 0;
            StartNextTurn();
        }

        private void StartNextTurn()
        {
            currentTurnNumber++;
            activePlayer = player1;
            activePlayer.StartPlayerTurn();
        }

        public void OnPlayerTurnCompleted()
        {
            if(activePlayer == player1)
            {
                activePlayer = player2;
                activePlayer.StartPlayerTurn();
            }
            else
            {
                StartNextTurn();
            }
        }

        public int GetActivePlayerId() => activePlayer.PlayerID;

        public int GetActiveUnitId() => activePlayer.ActiveUnitID;


        public void ProcessUnitCommand(IUnitCommand commandToProcess)
        {
            SetTargetUnit(commandToProcess);

            if(commandToProcess.OwnerPlayerID == player1.PlayerID)
                player1.ProcessUnitCommand(commandToProcess);
            else if(commandToProcess.OwnerPlayerID == player2.PlayerID)
                player2.ProcessUnitCommand(commandToProcess);
        }

        private void SetTargetUnit(IUnitCommand commandToProcess)
        {
            if(player1.PlayerID == commandToProcess.TargetPlayerID)
                commandToProcess.SetTargetUnit(player1.GetUnitByID(commandToProcess.TargetUnitID));
            else if(player2.PlayerID == commandToProcess.TargetPlayerID)
                commandToProcess.SetTargetUnit(player2.GetUnitByID(commandToProcess.TargetUnitID));
        }

    }
}