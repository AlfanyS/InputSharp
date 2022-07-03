namespace InputSharp.InputCommands;

public abstract class MultiCommand : InputCommand
{
    private InputCommand[] _commands;
    public MultiCommand(params InputCommand[] commands)
    {
        _commands = commands;
    }
    public override void Execute()
    {
        ExecuteAll(_commands);
    }

    protected abstract void ExecuteAll(InputCommand[] commands);
}