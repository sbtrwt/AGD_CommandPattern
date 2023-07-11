using Command.Commands;
using Command.Input;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class BerserkAttackAction : IAction
    {
        public TargetType TargetType => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            actorUnit.PlayActionAnimation(CommandType.BerserkAttack);
            if (successful)
                targetUnit.TakeDamage(actorUnit.CurrentPower * 2);
            else
            {
                actorUnit.TakeDamage(actorUnit.CurrentPower * 2);
                Debug.Log("actor unit must be hit now.");
            }
        }
    }
}