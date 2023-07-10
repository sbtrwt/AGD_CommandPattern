using Command.Player;

namespace Command.Actions
{
    public interface IAction
    {
        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful);
    } 
}