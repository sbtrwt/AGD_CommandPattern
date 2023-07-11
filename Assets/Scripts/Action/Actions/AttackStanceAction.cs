using Command.Player;
using Command.Input;
using Command.Main;
using Command.Commands;

namespace Command.Actions
{
    public class AttackStanceAction : IAction
    {
        TargetType IAction.TargetType { get => TargetType.Self; }

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            actorUnit.PlayActionAnimation(CommandType.AttackStance);
            if(successful)
                targetUnit.CurrentPower += (int)(targetUnit.CurrentPower * 0.2f);
            else
                GameService.Instance.UIService.ActionMissed();
        }
    }
}