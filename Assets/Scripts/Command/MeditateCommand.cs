﻿using Command.Actions;
using Command.Input;
using Command.Main;
using Command.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Command.Command
{
    public class MeditateCommand : UnitCommand
    {
        private bool willHitTarget;

        public MeditateCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}
