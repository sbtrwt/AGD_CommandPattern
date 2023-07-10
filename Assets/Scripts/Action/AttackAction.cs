using Command.Commands;
using Command.Input;
using Command.Player;

namespace Command.Actions
{
    public class AttackAction : IAction
    {
        TargetType IAction.TargetType { get => TargetType.Enemy; }

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            actorUnit.PlayActionAnimation(CommandType.Attack);
            if (successful)
                targetUnit.TakeDamage(actorUnit.CurrentPower);
        }
    }
}