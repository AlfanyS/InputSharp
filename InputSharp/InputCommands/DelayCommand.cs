namespace InputSharp.InputCommands;

public sealed class DelayCommand : InputCommand
{
    public readonly int delay;

    public DelayCommand(int delayInMillisecond)
    {
        delay = delayInMillisecond;
    }

    public override void Execute()
    {
        Task.Delay(delay).Wait();
    }

    public override string ToString()
    {
        return $"{delay}ms Delay";
    }
}