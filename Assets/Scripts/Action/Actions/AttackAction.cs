using Command.Commands;
using Command.Input;
using Command.Main;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class AttackAction : IAction
    {
        private UnitController actorUnit;
        private UnitController targetUnit;
        private bool isSuccessful;
        public TargetType TargetType => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool isSuccessful)
        {
            this.actorUnit = actorUnit;
            this.targetUnit = targetUnit;
            this.isSuccessful = isSuccessful;

            actorUnit.PlayBattleAnimation(CommandType.Attack, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted() 
        {
            if (isSuccessful)
                targetUnit.TakeDamage(actorUnit.CurrentPower);
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}