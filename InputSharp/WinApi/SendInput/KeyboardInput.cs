using System.Runtime.InteropServices;

namespace InputSharp.WinApi.SendInput;

[StructLayout(LayoutKind.Sequential)]
internal struct KeyboardInput
{
    public ushort wVk;
    public ushort wScan;
    public uint dwFlags;
    public uint time;
    public IntPtr dwExtraInfo;
}