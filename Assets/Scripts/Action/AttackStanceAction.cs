using Command.Player;
using Command.Input;
using Command.Main;

namespace Command.Actions
{
    public class AttackStanceAction : IAction
    {
        TargetType IAction.TargetType { get => TargetType.Self; }

        public void PerformAction(UnitController actorUnit, UnitController targetUnit)
        {
            actorUnit.PlayActionAnimation(ActionType.AttackStance);
            if(IsSuccessful())
                targetUnit.CurrentPower += (int)(targetUnit.CurrentPower * 0.2f);
            else
                GameService.Instance.UIService.ActionMissed();
        }
        public bool IsSuccessful() => true;
    }
}