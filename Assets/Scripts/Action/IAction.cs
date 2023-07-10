using Command.Player;

namespace Command.Action
{
    public interface IAction
    {
        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool successful);
    } 
}