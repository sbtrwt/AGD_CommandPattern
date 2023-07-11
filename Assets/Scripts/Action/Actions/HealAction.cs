using Command.Commands;
using Command.Input;
using Command.Player;

namespace Command.Actions
{
    public class HealAction : IAction
    {
        public TargetType TargetType => TargetType.Friendly;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            actorUnit.PlayActionAnimation(CommandType.Heal);
            if(successful)
                targetUnit.RestoreHealth(actorUnit.CurrentPower);
        }
    }
}