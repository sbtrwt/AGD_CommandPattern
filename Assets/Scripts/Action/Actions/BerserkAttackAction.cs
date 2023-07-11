using Command.Input;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class BerserkAttackAction : IAction
    {
        private const float hitChance = 0.66f;
        public TargetType TargetType => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit)
        {
            actorUnit.PlayActionAnimation(ActionType.BerserkAttack);
            if (IsSuccessful())
                targetUnit.TakeDamage(actorUnit.CurrentPower * 2);
            else
            {
                actorUnit.TakeDamage(actorUnit.CurrentPower * 2);
                Debug.Log("actor unit must be hit now.");
            }
        }

        public bool IsSuccessful() => Random.Range(0f, 1f) < hitChance;
    }
}