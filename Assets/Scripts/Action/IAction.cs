using Command.Input;
using Command.Player;

namespace Command.Actions
{
    public interface IAction
    {
        public TargetType TargetType { get; }

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool isSuccessful);
    } 
}