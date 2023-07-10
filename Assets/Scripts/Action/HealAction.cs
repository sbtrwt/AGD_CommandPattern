using Command.Commands;
using Command.Player;

namespace Command.Actions
{
    public class HealAction : IAction
    {
        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            actorUnit.PlayActionAnimation(CommandType.Heal);
            if (successful)
                targetUnit.RestoreHealth(actorUnit.Power);
        }
    }
}
