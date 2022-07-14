using InputSharp.GlobalHooks;

namespace InputSharp.WinApi.Hooks;

internal delegate int KeyboardHookProc(int code, KeyboardMessage wParam, ref KeyboardHookStruct lParam);
internal delegate int MouseHookProc(int code, MouseMessage wParam, ref MouseHookStruct lParam);