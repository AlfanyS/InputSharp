using System.Runtime.InteropServices;
using InputSharp.WinApi.SendInput;

namespace InputSharp.WinApi;

internal static class NativeMethods
{
    [DllImport("kernel32")]
    public static extern IntPtr LoadLibrary(string lpFileName);
    
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetMessageExtraInfo();

    [DllImport("user32.dll")]
    internal static extern bool GetCursorPos(out Point pos);

    [DllImport("User32.dll")]
    internal static extern bool SetCursorPos(int x, int y);
}