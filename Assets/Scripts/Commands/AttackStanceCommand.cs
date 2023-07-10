using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Commands
{
    public class AttackStanceCommand : UnitCommand
    {
        private bool willHitTarget;

        public AttackStanceCommand(int actorUnitId, int targetUnitId, int actorPlayerId, int targetPlayerId)
        {
            ActorUnitID = actorUnitId;
            TargetUnitID = targetUnitId;
            ActorPlayerID = actorPlayerId;
            TargetPlayerID = targetPlayerId;

            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            if (willHitTarget)
            {
                targetUnit.CurrentPower -= (int)(targetUnit.CurrentPower * 0.2f);
                actorUnit.Owner.ResetCurrentActivePlayer();
            }
        }

        public override bool WillHitTarget() => true;
    }
}