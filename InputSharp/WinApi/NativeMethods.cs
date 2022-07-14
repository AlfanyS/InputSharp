using System.Runtime.InteropServices;
using InputSharp.GlobalHooks;
using InputSharp.WinApi.Hooks;
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
    
    [DllImport("user32")]
    public static extern int CallNextHookEx(IntPtr hHk, int nCode,
        KeyboardMessage wParam, ref KeyboardHookStruct lParam);

    [DllImport("user32")]
    public static extern int CallNextHookEx(IntPtr hHk, int nCode,
        MouseMessage wParam, ref MouseHookStruct lParam);

    [DllImport("user32")]
    public static extern IntPtr SetWindowsHookEx(int idHook,
        KeyboardHookProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32")]
    public static extern IntPtr SetWindowsHookEx(int idHook,
        MouseHookProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32")]
    public static extern bool UnhookWindowsHookEx(IntPtr hHk);
    
    [DllImport("user32.dll")]
    public static extern bool GetMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

    [DllImport("user32.dll")]
    public static extern bool TranslateMessage([In] ref Msg lpMsg);

    [DllImport("user32.dll")]
    public static extern IntPtr DispatchMessage([In] ref Msg lpmsg);
        
    [DllImport("user32.dll")]
    public static extern bool PeekMessage(out Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin,
        uint wMsgFilterMax, uint wRemoveMsg);
}
#region WindowsHook dependencies

internal struct KeyboardHookStruct
{
    public uint VKCode;
    public uint ScanCode;
    public uint Flags;
    public uint Time;
    public IntPtr dwExtraInfo;
}

internal struct MouseHookStruct
{
    public int X;
    public int Y;
    public uint MouseData;
    public uint Flags;
    public uint Time;
    public IntPtr dwExtraInfo;
}

#endregion