using InputSharp.InputCommands;
using InputSharp.WinApi;
using InputSharp.WinApi.Hooks;

namespace InputSharp.GlobalHooks;

public class MousedHook : IDisposable
{
    private const int MouseLowLevel = 14;
    
    private IntPtr _hookId;
    private readonly MouseHookProc _callback;
    
    public bool isDisposed { get; private set; }
    private bool _started;
    private Task _messageLoop;
    
    public delegate void MouseEventHandler(MouseEventArgs e);
    public event MouseEventHandler MouseButtonDown = (e) => { };
    public event MouseEventHandler MouseButtonUp = (e) => { };
    public event MouseEventHandler MouseMove = (e) => { };
    
    public MousedHook()
    {
        _callback = (int code, MouseMessage wParam, ref MouseHookStruct lParam) =>
        {
            if (code >= 0)
            {
                var args = new MouseEventArgs(wParam, lParam.X, lParam.Y);
                switch (wParam)
                {
                    case MouseMessage.MouseMove:
                        MouseMove(args);
                        break;

                    case MouseMessage.LeftButtonDown:
                        MouseButtonDown(args);
                        break;

                    case MouseMessage.RightButtonDown:
                        MouseButtonDown(args);
                        break;

                    case MouseMessage.MiddleButtonDown:
                        MouseButtonDown(args);
                        break;

                    case MouseMessage.LeftButtonUp:
                        MouseButtonUp(args);
                        break;

                    case MouseMessage.RightButtonUp:
                        MouseButtonUp(args);
                        break;

                    case MouseMessage.MiddleButtonUp:
                        MouseButtonUp(args);
                        break;
                }
            }
            return NativeMethods.CallNextHookEx(_hookId, code, wParam, ref lParam);
        };
    }
    
    private void Run()
    {
        var handle = NativeMethods.LoadLibrary("user32");
        _hookId = NativeMethods.SetWindowsHookEx(MouseLowLevel, _callback, handle, 0);
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

    ~MousedHook()
    {
        Dispose();
    }
}