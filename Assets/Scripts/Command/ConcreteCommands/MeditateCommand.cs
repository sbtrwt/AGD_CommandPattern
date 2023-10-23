using Command.Main;

namespace Command.Commands
{
    public class MeditateCommand : UnitCommand
    {
        private bool willHitTarget;

        public MeditateCommand(CommandData commandData)
        {
            ActorUnitID = commandData.ActorUnitID;
            TargetUnitID = commandData.TargetUnitID;
            ActorPlayerID = commandData.ActorPlayerID;
            TargetPlayerID = commandData.TargetPlayerID;

            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override bool WillHitTarget() => true;
    }
}
