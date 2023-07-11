using Command.Input;
using Command.Main;
using Command.Player;

namespace Command.Actions
{
    public class AttackAction : IAction
    {
        public TargetType TargetType => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit)
        {
            actorUnit.PlayActionAnimation(ActionType.Attack);
            if (IsSuccessful())
                targetUnit.TakeDamage(actorUnit.CurrentPower);
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public bool IsSuccessful() => true;
    }
}