using Command.Input;
using Command.Player;

namespace Command.Actions
{
    public class HealAction : IAction
    {
        public TargetType TargetType => TargetType.Friendly;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit)
        {
            actorUnit.PlayActionAnimation(ActionType.Heal);
            if(IsSuccessful())
                targetUnit.RestoreHealth(actorUnit.CurrentPower);
        }

        public bool IsSuccessful() => true;
    }
}