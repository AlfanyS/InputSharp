using InputSharp.InputCommands;
using InputSharp.WinApi;

namespace InputSharp.GlobalHooks;

public record KeyEventArgs(ScanKey scanKey, VirtualKey virtualKey)
{
    public bool handled;
}