using System.Runtime.InteropServices;
using InputSharp.WinApi;
using InputSharp.WinApi.Hooks;

namespace InputSharp.GlobalHooks;

public class KeyboardHook : IDisposable
{
    private const int KeyboardLowLevel = 13;
    
    private IntPtr _hookId;
    private readonly KeyboardHookProc _callback;
    
    public bool isDisposed { get; private set; }
    private bool _started;
    private Task _messageLoop;
    
    public delegate void KeyEventHandler(KeyEventArgs e);
    public event KeyEventHandler KeyUp = (e) => { };
    public event KeyEventHandler KeyDown = (e) => { };
    
    public KeyboardHook()
    {
        _callback = (int code, KeyboardMessage wParam, ref KeyboardHookStruct lParam) =>
        {
            if (code >= 0)
            {
                var args = new KeyEventArgs((ScanKey) lParam.ScanCode, (VirtualKey) lParam.VKCode);
                switch (wParam)
                {
                    case KeyboardMessage.KeyDown:
                    case KeyboardMessage.SysKeyDown:
                        KeyDown(args);
                        break;
                    case KeyboardMessage.KeyUp:
                    case KeyboardMessage.SysKeyUp:
                        KeyUp(args);
                        break;
                }

                if (args.handled)
                    return 1;
            }
            return NativeMethods.CallNextHookEx(_hookId, code, wParam, ref lParam);
        };
    }

    private void Run()
    {
        var handle = NativeMethods.LoadLibrary("user32");
        _hookId = NativeMethods.SetWindowsHookEx(KeyboardLowLevel, _callback, handle, 0);
        Msg msg;
        while (NativeMethods.GetMessage(out msg, IntPtr.Zero, 0, 0))
        {
            NativeMethods.TranslateMessage(ref msg);
            NativeMethods.DispatchMessage(ref msg);
        }
    }

    public void Begin()
    {
        if (_started)
            return;
        _started = true;
        Run();
    }

    public async Task BeginAsync()
    {
        if (_started)
            return;
        _started = true;
        _messageLoop = Task.Run(Run);
        await _messageLoop;
    }

    public void Dispose()
    {
        if (isDisposed)
            return;
        isDisposed = true;
        NativeMethods.UnhookWindowsHookEx(_hookId);
        GC.SuppressFinalize(this);
    }

    ~KeyboardHook()
    {
        Dispose();
    }
}