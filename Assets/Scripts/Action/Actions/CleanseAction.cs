using Command.Input;
using Command.Player;
using Command.Main;
using UnityEngine;
using Command.Commands;

namespace Command.Actions
{
    public class CleanseAction : IAction
    {
        private const float hitChance = 0.2f;
        private UnitController actorUnit;
        private UnitController targetUnit;
        public TargetType TargetType  => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            this.actorUnit = actorUnit;
            this.targetUnit = targetUnit;

            actorUnit.PlayBattleAnimation(ActionType.Cleanse, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            if (IsSuccessful())
                targetUnit.ResetStats();
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public bool IsSuccessful() => Random.Range(0f, 1f) < hitChance;

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}
