using Command.Main;

namespace Command.Commands
{
    public class ThirdEyeCommand : UnitCommand
    {
        private bool willHitTarget;
        private int previousHealth;

        public ThirdEyeCommand(CommandData commandData)
        {
            ActorUnitID = commandData.ActorUnitID;
            TargetUnitID = commandData.TargetUnitID;
            ActorPlayerID = commandData.ActorPlayerID;
            TargetPlayerID = commandData.TargetPlayerID;

            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            previousHealth = targetUnit.CurrentHealth;
            GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override void Undo()
        {
            if(!targetUnit.IsAlive())
                targetUnit.Revive();

            int healthToRestore = (int)(previousHealth * 0.25f);
            targetUnit.RestoreHealth(healthToRestore);
            targetUnit.CurrentPower -= healthToRestore;
            actorUnit.Owner.ResetCurrentActivePlayer();
        }

        public override bool WillHitTarget() => true;
    } 
}
