using Command.Commands;
using Command.Input;
using System.Collections.Generic;

namespace Command.Actions
{
    public class ActionService
    {
        private Dictionary<CommandType, IAction> actions;

        public ActionService() => CreateActions();

        private void CreateActions()
        {
            actions = new Dictionary<CommandType, IAction>();
            actions.Add(CommandType.Attack, new AttackAction());
            actions.Add(CommandType.Heal, new HealAction());
            actions.Add(CommandType.AttackStance, new AttackStanceAction());
        }

        public IAction GetActionByType(CommandType type)
        {
            if (actions.ContainsKey(type))
                return actions[type];
            else
                throw new System.Exception($"No Action found for the type {type} in the dictionary");
        }

        public TargetType GetTargetTypeForAction(CommandType actionType) => actions[actionType].TargetType;
    }
}