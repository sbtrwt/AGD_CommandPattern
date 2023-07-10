using Command.Commands;
using System.Collections.Generic;

namespace Command.Actions
{
    public class ActionService
    {
        private Dictionary<CommandType, IAction> actions;

        public ActionService()
        {
            CreateActions();
        }

        private void CreateActions()
        {
            actions = new Dictionary<CommandType, IAction>();
            actions.Add(CommandType.Attack, new AttackAction());
            actions.Add(CommandType.Heal, new HealAction());
        }

        public IAction GetActionByType(CommandType type)
        {
            if (actions.ContainsKey(type))
                return actions[type];
            else
                throw new System.Exception($"No Action found for the type {type} in the dictionary");
        }
    }
}