using System.Runtime.InteropServices;

namespace InputSharp.WinApi.SendInput;

[StructLayout(LayoutKind.Sequential)]
internal struct HardwareInput
{
    public uint uMsg;
    public ushort wParamL;
    public ushort wParamH;
}