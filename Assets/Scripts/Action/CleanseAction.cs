using Command.Input;
using Command.Player;
using Command.Commands;
using Command.Main;

namespace Command.Actions
{
    public class CleanseAction : IAction
    {
        public TargetType TargetType  => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            actorUnit.PlayActionAnimation(CommandType.Cleanse);
            if (successful)
                targetUnit.ResetStats();
            else
                GameService.Instance.UIService.ActionMissed();
        }
    }
}
