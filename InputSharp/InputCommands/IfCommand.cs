namespace InputSharp.InputCommands;

public sealed class IfCommand : MultiCommand
{
    private Func<bool> _predicate;
    public IfCommand(Func<bool> predicate, params InputCommand[] commands) : base(commands)
    {
        _predicate = predicate;
    }

    protected override void ExecuteAll(InputCommand[] commands)
    {
        if(_predicate())
            foreach(var command in commands) command.Execute();
    }
}