namespace InputSharp.WinApi.Hooks;

[Serializable]
public struct Msg
{
    public IntPtr hwnd;

    public IntPtr lParam;

    public int message;

    public int pt_x;

    public int pt_y;

    public int time;

    public IntPtr wParam;
}