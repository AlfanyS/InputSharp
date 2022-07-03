namespace InputSharp.InputCommands;
public sealed class KeyboardCommand : InputCommand
{
    public readonly ScanKey sKey;
    public readonly VirtualKey vKey;
    public readonly KeyboardEvent ev;

    public KeyboardCommand(ScanKey key, KeyboardEvent @event)
    {
        sKey = key;
        ev = @event;
    }
    public KeyboardCommand(VirtualKey key, KeyboardEvent @event)
    {
        vKey = key;
        ev = @event;
    }

    public override void Execute()
    {
        if (sKey != ScanKey.None)
            switch (ev)
            {
                case KeyboardEvent.KeyDown: InputManager.KeyDown(sKey); break;
                case KeyboardEvent.KeyUp: InputManager.KeyUp(sKey); break;
                case KeyboardEvent.KeyClick: InputManager.ClickKey(sKey); break;
            }
        else
            switch (ev)
            {
                case KeyboardEvent.KeyDown: InputManager.KeyDown(vKey); break;
                case KeyboardEvent.KeyUp: InputManager.KeyUp(vKey); break;
                case KeyboardEvent.KeyClick: InputManager.ClickKey(vKey); break;
            }
    }
    public override string ToString()
    {
        if (sKey != ScanKey.None)
            return $"{sKey} {ev}";
        else
            return $"{vKey} {ev}";
    }
}
public enum KeyboardEvent
{
    KeyDown,
    KeyUp,
    KeyClick
}
