using Command.Commands;
using Command.Player;

namespace Command.Actions
{
    public class AttackAction : IAction
    {
        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            actorUnit.PlayActionAnimation(CommandType.Attack);
            if (successful)
                targetUnit.TakeDamage(actorUnit.Power);
        }
    }
}