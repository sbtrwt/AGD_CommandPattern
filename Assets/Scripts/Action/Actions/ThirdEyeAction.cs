using Command.Input;
using Command.Main;
using Command.Player;

namespace Command.Actions
{
    public class ThirdEyeAction : IAction
    {
        public TargetType TargetType => TargetType.Self;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit)
        {
            actorUnit.PlayActionAnimation(ActionType.BerserkAttack);
            if (IsSuccessful())
            {
                int healthToConvert = (int)(targetUnit.CurrentHealth * 0.25f);
                targetUnit.TakeDamage(healthToConvert);
                targetUnit.CurrentPower += healthToConvert;
            }
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public bool IsSuccessful() => true;
    }
}