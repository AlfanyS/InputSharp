namespace InputSharp.InputCommands;

public enum MouseEvent
{
    None = 0,
    LeftDown = 0x0002,
    LeftUp = 0x0004,
    LeftClick,
    RightDown = 0x0008,
    RightUp = 0x0010,
    RightClick,
    MiddleDown = 0x0020,
    MiddleUp = 0x0040,
    MiddleClick,
    XDown = 0x0080,
    XUp = 0x0100,
    XClick
}