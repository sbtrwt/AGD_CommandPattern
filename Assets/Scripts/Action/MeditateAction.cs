using Command.Commands;
using Command.Input;
using Command.Main;
using Command.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Actions
{
    public class MeditateAction : IAction
    {
        public TargetType TargetType => TargetType.Self;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful)
        {
            actorUnit.PlayActionAnimation(CommandType.Meditate);
            if(successful)
            {
                var healthToIncrease = (int)(targetUnit.CurrentMaxHealth * 0.2f);
                targetUnit.CurrentMaxHealth += healthToIncrease;
                targetUnit.RestoreHealth(healthToIncrease);
            }
            else
                GameService.Instance.UIService.ActionMissed();
        }
    }
}
