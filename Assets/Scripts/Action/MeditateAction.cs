using Command.Input;
using Command.Main;
using Command.Player;

namespace Command.Actions
{
    public class MeditateAction : IAction
    {
        public TargetType TargetType => TargetType.Self;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit)
        {
            actorUnit.PlayActionAnimation(ActionType.Meditate);
            if(IsSuccessful())
            {
                var healthToIncrease = (int)(targetUnit.CurrentMaxHealth * 0.2f);
                targetUnit.CurrentMaxHealth += healthToIncrease;
                targetUnit.RestoreHealth(healthToIncrease);
            }
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public bool IsSuccessful() => true;
    }
}