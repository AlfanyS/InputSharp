using System.Runtime.InteropServices;

namespace InputSharp.WinApi.SendInput;

[StructLayout(LayoutKind.Sequential)]
internal struct MouseInput
{
    public int dx;
    public int dy;
    public uint mouseData;
    public uint dwFlags;
    public uint time;
    public IntPtr dwExtraInfo;
}