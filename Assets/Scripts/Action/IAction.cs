namespace Command.Action
{
    public interface IAction
    {
        public void PerformAction(int actorUnitId, int targetUnitId);
    } 
}