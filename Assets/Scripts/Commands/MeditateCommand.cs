using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Commands
{
    public class MeditateCommand : UnitCommand
    {
        private const float hitChance = 0.33f;
        private bool willHitTarget;
        private int previousMaxHealth;

        public MeditateCommand(int actorUnitId, int targetUnitId, int actorPlayerId, int targetPlayerId)
        {
            ActorUnitID = actorUnitId;
            TargetUnitID = targetUnitId;
            ActorPlayerID = actorPlayerId;
            TargetPlayerID = targetPlayerId;

            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            previousMaxHealth = targetUnit.CurrentMaxHealth;
            GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override void Undo()
        {
            if (willHitTarget)
            {
                var healthToReduce = targetUnit.CurrentMaxHealth - previousMaxHealth;
                targetUnit.CurrentMaxHealth = previousMaxHealth;
                targetUnit.TakeDamage(healthToReduce);
            }
        }

        public override bool WillHitTarget() => Random.Range(0f, 1f) > hitChance;
    }
}
