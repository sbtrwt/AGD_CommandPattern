using Command.Main;
using UnityEngine;

namespace Command.Commands
{
    public class BerserkAttackCommand : UnitCommand
    {
        private bool willHitTarget;
        private const float hitChance = 0.66f;

        public BerserkAttackCommand(CommandData commandData)
        {
            ActorUnitID = commandData.ActorUnitID;
            TargetUnitID = commandData.TargetUnitID;
            ActorPlayerID = commandData.ActorPlayerID;
            TargetPlayerID = commandData.TargetPlayerID;

            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override bool WillHitTarget() => Random.Range(0f, 1f) < hitChance;
    }
}
