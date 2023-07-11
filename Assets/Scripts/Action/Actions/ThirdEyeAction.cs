using Command.Commands;
using Command.Input;
using Command.Main;
using Command.Player;

namespace Command.Actions
{
    public class ThirdEyeAction : IAction
    {
        public TargetType TargetType => TargetType.Self;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            actorUnit.PlayActionAnimation(CommandType.BerserkAttack);
            if (successful)
            {
                int healthToConvert = (int)(targetUnit.CurrentHealth * 0.25f);
                targetUnit.TakeDamage(healthToConvert);
                targetUnit.CurrentPower += healthToConvert;
            }
            else
                GameService.Instance.UIService.ActionMissed();
        }
    }
}