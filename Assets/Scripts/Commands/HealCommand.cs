using UnityEngine;
using Command.Player;

namespace Command.Commands
{
    public class HealCommand : IUnitCommand
    {
        private CommandData commandData;
        private PlayerController ownerPlayer;
        private UnitController ownerUnit;
        private UnitController targetUnit;

        public int OwnerPlayerID => commandData.OwnerPlayerID;
        public int OwnerUnitID => commandData.OwnerUnitID;
        public int TargetPlayerID => commandData.TargetPlayerID;
        public int TargetUnitID => commandData.TargetUnitID;

        public HealCommand(CommandData commandData)
        {
            this.commandData = commandData;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public void Undo()
        {
            throw new System.NotImplementedException();
        }

        public void SetPlayer(PlayerController playerToSet)
        {
            ownerPlayer = playerToSet;
        }

        public void SetActorUnit(UnitController ownerUnit)
        {
            this.ownerUnit = ownerUnit;
        }

        public void SetTargetUnit(UnitController targetUnit)
        {
            this.targetUnit = targetUnit;
        }
    }
}