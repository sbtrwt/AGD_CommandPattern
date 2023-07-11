using Command.Input;
using Command.Player;
using Command.Main;
using UnityEngine;

namespace Command.Actions
{
    public class CleanseAction : IAction
    {
        private const float hitChance = 0.2f;
        public TargetType TargetType  => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit)
        {
            actorUnit.PlayActionAnimation(ActionType.Cleanse);
            if(IsSuccessful())
                targetUnit.ResetStats();
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public bool IsSuccessful() => Random.Range(0, 1) < hitChance;
    }
}
