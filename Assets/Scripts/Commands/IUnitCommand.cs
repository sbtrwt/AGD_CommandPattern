using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Player;

namespace Command.Commands
{
    public interface IUnitCommand : ICommand
    {
        public int OwnerPlayerID { get; }
        public int OwnerUnitID { get; }
        public int TargetPlayerID { get; }
        public int TargetUnitID { get; }

        public void SetPlayer(PlayerController playerToSet);
        public void SetActorUnit(UnitController ownerUnit);
        public void SetTargetUnit(UnitController targetUnit);

    }

    public class CommandData
    {
        public int OwnerPlayerID;
        public int OwnerUnitID;
        public int TargetPlayerID;
        public int TargetUnitID;

        public CommandData(int ownerPlayerId, int ownerUnitId, int targetPlayerId, int targetUnitId)
        {
            OwnerPlayerID = ownerPlayerId;
            OwnerUnitID = ownerUnitId;
            TargetPlayerID = targetPlayerId;
            TargetUnitID = targetUnitId;
        }
    }
}