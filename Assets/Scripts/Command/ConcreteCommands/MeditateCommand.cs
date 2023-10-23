using Command.Main;

namespace Command.Commands
{
    public class MeditateCommand : UnitCommand
    {
        private bool willHitTarget;
        private int previousMaxHealth;

        public MeditateCommand(CommandData commandData)
        {
            ActorUnitID = commandData.ActorUnitID;
            TargetUnitID = commandData.TargetUnitID;
            ActorPlayerID = commandData.ActorPlayerID;
            TargetPlayerID = commandData.TargetPlayerID;

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

        public override bool WillHitTarget() => true;
    }
}
