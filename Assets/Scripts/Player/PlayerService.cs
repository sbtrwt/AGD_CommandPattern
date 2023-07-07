using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Commands;

namespace Command.Player
{
    public class PlayerService
    {
        private PlayerController player1;
        private PlayerController player2;

        private int currentTurnNumber;
        private PlayerController activePlayer;

        public int ActivePlayerID => activePlayer.PlayerID;
        public int ActiveUnitID => activePlayer.ActiveUnitID;

        public void Init(PlayerScriptableObject player1Data, PlayerScriptableObject player2Data)
        {
            CreatePlayers(player1Data, player2Data);
            StartTurnSequence();
        }

        private void CreatePlayers(PlayerScriptableObject player1Data, PlayerScriptableObject player2Data)
        {
            player1 = new PlayerController(this, player1Data);
            player2 = new PlayerController(this, player2Data);
        }

        private void StartTurnSequence()
        {
            currentTurnNumber = 0;
            StartNextTurn();
        }

        private void StartNextTurn()
        {
            SetActivePlayer();
            
            if (activePlayer == player1)
                currentTurnNumber++;
            
            activePlayer.StartPlayerTurn();
        }

        private void SetActivePlayer()
        {
            if (activePlayer == null)
                activePlayer = player1;
            else 
                activePlayer = activePlayer == player1 ? player2 : player1;
        }

        public void OnPlayerTurnCompleted() => StartNextTurn();



        // After Initialization is Done: 

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