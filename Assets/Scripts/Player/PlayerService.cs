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

        public void ProcessUnitCommand(UnitCommand commandToProcess)
        {
            SetUnitReferences(commandToProcess);
            GetPlayerById(commandToProcess.ActorPlayerID).ProcessUnitCommand(commandToProcess);
        }

        private void SetUnitReferences(UnitCommand commandToProcess)
        {
            var actorUnit = GetPlayerById(commandToProcess.ActorPlayerID).GetUnitByID(commandToProcess.ActorUnitID);
            var targetUnit = GetPlayerById(commandToProcess.TargetPlayerID).GetUnitByID(commandToProcess.TargetUnitID);
            commandToProcess.SetActorUnit(actorUnit);
            commandToProcess.SetTargetUnit(targetUnit);
        }

        private PlayerController GetPlayerById(int playerId) 
        {
            if (player1.PlayerID == playerId)
                return player1;
            else if (player2.PlayerID == playerId)
                return player2;
            else
                throw new System.Exception($"No Player found for the given Player ID: {playerId}");
        }


    }
}