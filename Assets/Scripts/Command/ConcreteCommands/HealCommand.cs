using Command.Main;

namespace Command.Commands
{
    public class HealCommand : UnitCommand
    {
        private bool willHitTarget;

        public HealCommand(CommandData commandData)
        {
            ActorUnitID = commandData.ActorUnitID;
            TargetUnitID = commandData.TargetUnitID;
            ActorPlayerID = commandData.ActorPlayerID;
            TargetPlayerID = commandData.TargetPlayerID;

            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Heal).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            if (willHitTarget)
            {
                targetUnit.TakeDamage(actorUnit.CurrentPower);
                actorUnit.Owner.ResetCurrentActivePlayer();
            }
        }

        public override bool WillHitTarget() => true;
    }
}