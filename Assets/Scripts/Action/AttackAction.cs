using Command.Commands;
using Command.Player;
using UnityEngine;

namespace Command.Action
{
    public class AttackAction : IAction
    {
        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            actorUnit.PlayActionAnimation(CommandType.Attack);
            if (successful)
                targetUnit.TakeDamage(actorUnit.Power);
        }
    }
}