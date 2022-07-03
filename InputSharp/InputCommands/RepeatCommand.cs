namespace InputSharp.InputCommands;

public sealed class RepeatCommand : MultiCommand
{
    private int _count;
    public RepeatCommand(int count, params InputCommand[] commands): base(commands)
    {
        _count = count;
    }
    protected override void ExecuteAll(InputCommand[] commands)
    {
        for(int i = 0; i < _count; i++)
            foreach(var command in commands) command.Execute();
    }
}