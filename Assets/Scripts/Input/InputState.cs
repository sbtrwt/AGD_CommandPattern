namespace Command.Input
{
    [System.Serializable]
    public enum InputState
    {
        SELECTING_ACTION,
        SELECTING_TARGET,
        EXECUTING_INPUT,
        INACTIVE
    }
}