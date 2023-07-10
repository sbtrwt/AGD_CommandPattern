using Command.Player;
using UnityEngine;

namespace Command.Action
{
    public class HealAction : IAction
    {
        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            Debug.Log($"Heal Action is performed.");
        }
    }
}
