using System.Runtime.InteropServices;

namespace InputSharp;
internal static class NativeMethods
{
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetMessageExtraInfo();

    [DllImport("user32.dll")]
    internal static extern bool GetCursorPos(out Point pos);

    [DllImport("User32.dll")]
    internal static extern bool SetCursorPos(int x, int y);
}
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
public enum MouseMovement
{
    None,
    Move,
    SetPos
}
[StructLayout(LayoutKind.Sequential)]
public struct Point
{
    public int x;
    public int y;
    public Point() { x = 0; y = 0; }
    public Point (int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString() => $"x={x}, y={y}";
    public static implicit operator Point((int x, int y) tuple) =>
            new (tuple.x, tuple.y);
    public void Deconstruct(out int x, out int y)
    {
        x = this.x;
        y = this.y;
    }
}
internal struct Input
{
    public int type;
    public InputUnion u;
}
[Flags]
internal enum InputType
{
    Mouse = 0,
    Keyboard = 1,
    Hardware = 2
}
[Flags]
internal enum KeyEvent
{
    KeyDown = 0x0000,
    ExtendedKey = 0x0001,
    KeyUp = 0x0002,
    Unicode = 0x0004,
    Scancode = 0x0008
}
[Flags]
internal enum MouseEventF
{
    Absolute = 0x8000,
    HWheel = 0x01000,
    Move = 0x0001,
    MoveNoCoalesce = 0x2000,
    LeftDown = 0x0002,
    LeftUp = 0x0004,
    RightDown = 0x0008,
    RightUp = 0x0010,
    MiddleDown = 0x0020,
    MiddleUp = 0x0040,
    VirtualDesk = 0x4000,
    Wheel = 0x0800,
    XDown = 0x0080,
    XUp = 0x0100
}
[StructLayout(LayoutKind.Sequential)]
internal struct KeyboardInput
{
    public ushort wVk;
    public ushort wScan;
    public uint dwFlags;
    public uint time;
    public IntPtr dwExtraInfo;
}
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
[StructLayout(LayoutKind.Sequential)]
internal struct HardwareInput
{
    public uint uMsg;
    public ushort wParamL;
    public ushort wParamH;
}
[StructLayout(LayoutKind.Explicit)]
internal struct InputUnion
{
    [FieldOffset(0)] public MouseInput mi;
    [FieldOffset(0)] public KeyboardInput ki;
    [FieldOffset(0)] public HardwareInput hi;
}
/// <summary>
/// Scan codes.
/// </summary>
public enum ScanKey
{
    /// <summary>
    /// Absence of key.
    /// </summary>
    None = 0x0,
    Esc = 0x01,
    One = 0x02,
    Two = 0x03,
    Three = 0x04,
    Four = 0x05,
    Five = 0x06,
    Six = 0x07,
    Seven = 0x08,
    Eight = 0x09,
    Nine = 0x0A,
    Zero = 0x0B,
    /// <summary>
    /// - on main keyboard.
    /// </summary>
    Minus = 0x0C,
    Equals = 0x0D,
    Backspace = 0x0E,
    Tab = 0x0F,
    Q = 0x10,
    W = 0x11,
    E = 0x12,
    R = 0x13,
    T = 0x14,
    Y = 0x15,
    U = 0x16,
    I = 0x17,
    O = 0x18,
    P = 0x19,
    LBracket = 0x1A,
    RBracket = 0x1B,
    /// <summary>
    /// Enter on main keyboard.
    /// </summary>
    Return = 0x1C,
    LСtrl = 0x1D,
    A = 0x1E,
    S = 0x1F,
    D = 0x20,
    F = 0x21,
    G = 0x22,
    H = 0x23,
    J = 0x24,
    K = 0x25,
    L = 0x26,
    Semicolon = 0x27,
    Apostrophe = 0x28,
    /// <summary>
    /// Accent grave. ` on main keyboard.
    /// </summary>
    Grave = 0x29,
    LShift = 0x2A,
    Backslash = 0x2B,
    Z = 0x2C,
    X = 0x2D,
    C = 0x2E,
    V = 0x2F,
    B = 0x30,
    N = 0x31,
    M = 0x32,
    Comma = 0x33,
    /// <summary>
    /// . on main keyboard.
    /// </summary>
    Dot = 0x34,
    /// <summary>
    /// / on main keyboard.
    /// </summary>
    Slash = 0x35,
    RShift = 0x36,
    /// <summary>
    /// * on numeric keypad.
    /// </summary>
    Multiply = 0x37,
    LAlt = 0x38,
    Space = 0x39,
    CapsLock = 0x3A,
    F1 = 0x3B,
    F2 = 0x3C,
    F3 = 0x3D,
    F4 = 0x3E,
    F5 = 0x3F,
    F6 = 0x40,
    F7 = 0x41,
    F8 = 0x42,
    F9 = 0x43,
    F10 = 0x44,
    NumLock = 0x45,
    ScrollLock = 0x46,
    Num7 = 0x47,
    Num8 = 0x48,
    Num9 = 0x49,
    /// <summary>
    ///  - on numeric keypad.
    /// </summary>
    Subtract = 0x4A,
    Num4 = 0x4B,
    Num5 = 0x4C,
    Num6 = 0x4D,
    /// <summary>
    /// + on numeric keypad.
    /// </summary>
    Add = 0x4E,
    Num1 = 0x4F,
    Num2 = 0x50,
    Num3 = 0x51,
    Num0 = 0x52,
    /// <summary>
    /// . on numeric keypad.
    /// </summary>
    Decimal = 0x53,
    /// <summary>
    /// &lt;&gt; or | on RT 102-key keyboard (Non-U.S.).
    /// </summary>
    OEM_102 = 0x56,
    F11 = 0x57,
    F12 = 0x58,
    F13 = 0x64,    /*                     (NEC PC98) */
    F14 = 0x65,    /*                     (NEC PC98) */
    F15 = 0x66,    /*                     (NEC PC98) */
    /// <summary>
    /// Japanese keyboard.
    /// </summary>
    Kana = 0x70,
    /// <summary>
    /// ? on Brazilian keyboard.
    /// </summary>
    ABNT_C1 = 0x73,
    /// <summary>
    /// Japanese keyboard.
    /// </summary>
    Convert = 0x79,
    /// <summary>
    /// Japanese keyboard.
    /// </summary>
    NoConvert = 0x7B,
    /// <summary>
    /// Japanese keyboard.
    /// </summary>
    Yen = 0x7D,
    /// <summary>
    /// Numpad . on Brazilian keyboard.
    /// </summary>
    ABNT_C2 = 0x7E,
    /// <summary>
    /// = on numeric keypad (NEC PC98)
    /// </summary>
    NumEquals = 0x8D,
    /// <summary>
    /// Previous Track (DIK_CIRCUMFLEX on Japanese keyboard)
    /// </summary>
    PrevTrack = 0x90,
    At = 0x91,    /*                     (NEC PC98) */
    Colon = 0x92,    /*                     (NEC PC98) */
    Underline = 0x93,    /*                     (NEC PC98) */
    /// <summary>
    /// Japanese keyboard.
    /// </summary>
    Kanji = 0x94,
    Stop = 0x95,    /*                     (NEC PC98) */
    /// <summary>
    /// Japan AX.
    /// </summary>
    Ax = 0x96,
    Unlabeled = 0x97,    /*(J3100) */
    /// <summary>
    /// Next Track.
    /// </summary>
    NextTrack = 0x99,
    /// <summary>
    /// Enter on numeric keypad.
    /// </summary>
    NumEnter = 0x9C,
    RCtrl = 0x9D,
    Mute = 0xA0,
    Calculator = 0xA1,
    PlayPause = 0xA2,
    MediaStop = 0xA4,
    /// <summary>
    /// Volume -.
    /// </summary>
    VolumeDown = 0xAE,
    /// <summary>
    /// Volume +.
    /// </summary>
    VolumeUp = 0xB0,    
    WebHome = 0xB2,
    /// <summary>
    /// , on numeric keypad (NEC PC98).
    /// </summary>
    NumComma = 0xB3,
    /// <summary>
    /// / on numeric keypad.
    /// </summary>
    Divide = 0xB5,
    SYSRQ = 0xB7,
    RAlt = 0xB8,
    Pause = 0xC5,
    /// <summary>
    /// Home on arrow keypad.
    /// </summary>
    Home = 0xC7,
    /// <summary>
    /// UpArrow on arrow keypad.
    /// </summary>
    Up = 0xC8,
    /// <summary>
    /// PageUp on arrow keypad.
    /// </summary>
    PgUp = 0xC9,
    /// <summary>
    /// LeftArrow on arrow keypad.
    /// </summary>
    Left = 0xCB,
    /// <summary>
    /// RightArrow on arrow keypad.
    /// </summary>
    Right = 0xCD,
    /// <summary>
    /// End on arrow keypad.
    /// </summary>
    End = 0xCF,
    /// <summary>
    /// DownArrow on arrow keypad.
    /// </summary>
    Down = 0xD0,
    /// <summary>
    /// PageDown on arrow keypad.
    /// </summary>
    PgDn = 0xD1,
    /// <summary>
    /// Insert on arrow keypad.
    /// </summary>
    Insert = 0xD2,
    /// <summary>
    /// Delete on arrow keypad.
    /// </summary>
    Delete = 0xD3,
    /// <summary>
    /// Left Windows key.
    /// </summary>
    LWin = 0xDB,
    /// <summary>
    /// Right Windows key.
    /// </summary>
    RWin = 0xDC,
    /// <summary>
    /// AppMenu key
    /// </summary>
    Apps = 0xDD,
    /// <summary>
    /// System Power.
    /// </summary>
    Power = 0xDE,
    /// <summary>
    /// System Sleep.
    /// </summary>
    Sleep = 0xDF,
    /// <summary>
    /// System Wake.
    /// </summary>
    Wake = 0xE3,
    WebSearch = 0xE5,
    WebFavourites = 0xE6,
    WebRefresh = 0xE7,
    WebStop = 0xE8,
    WebForward= 0xE9,
    WebBack = 0xEA,
    MyComputer = 0xEB,
    Mail = 0xEC,
    MediaSelect = 0xED
}
/// <summary>
/// May not work in 3D programs.
/// </summary>
public enum VirtualKey
{
    None = 0x0,
    LBUTTON = 0x01,
    RBUTTON = 0x02,
    CANCEL = 0x03,
    MBUTTON = 0x04,
    XBUTTON1 = 0x05,
    XBUTTON2 = 0x06,
    BACK = 0x08,
    TAB = 0x09,
    CLEAR = 0x0C,
    RETURN = 0x0D,
    SHIFT = 0x10,
    CONTROL = 0x11,
    ALT = 0x12,
    PAUSE = 0x13,
    CAPITAL = 0x14,
    KANA = 0x15,
    HANGUEL = 0x15,
    HANGUL = 0x15,
    JUNJA = 0x17,
    FINAL = 0x18,
    HANJA = 0x19,
    KANJI = 0x19,
    ESCAPE = 0x1B,
    CONVERT = 0x1C,
    NONCONVERT = 0x1D,
    ACCEPT = 0x1E,
    MODECHANGE = 0x1F,
    SPACE = 0x20,
    PRIOR = 0x21,
    NEXT = 0x22,
    END = 0x23,
    HOME = 0x24,
    LEFT = 0x25,
    UP = 0x26,
    RIGHT = 0x27,
    DOWN = 0x28,
    SELECT = 0x29,
    PRINT = 0x2A,
    EXECUTE = 0x2B,
    SNAPSHOT = 0x2C,
    INSERT = 0x2D,
    DELETE = 0x2E,
    HELP = 0x2F,
    _0 = 0x30,
    _1 = 0x31,
    _2 = 0x32,
    _3 = 0x33,
    _4 = 0x34,
    _5 = 0x35,
    _6 = 0x36,
    _7 = 0x37,
    _8 = 0x38,
    _9 = 0x39,
    A = 0x41,
    B = 0x42,
    C = 0x43,
    D = 0x44,
    E = 0x45,
    F = 0x46,
    G = 0x47,
    H = 0x48,
    I = 0x49,
    J = 0x4A,
    K = 0x4B,
    L = 0x4C,
    M = 0x4D,
    N = 0x4E,
    O = 0x4F,
    P = 0x50,
    Q = 0x51,
    R = 0x52,
    S = 0x53,
    T = 0x54,
    U = 0x55,
    V = 0x56,
    W = 0x57,
    X = 0x58,
    Y = 0x59,
    Z = 0x5A,
    LWIN = 0x5B,
    RWIN = 0x5C,
    APPS = 0x5D,
    SLEEP = 0x5F,
    NUMPAD0 = 0x60,
    NUMPAD1 = 0x61,
    NUMPAD2 = 0x62,
    NUMPAD3 = 0x63,
    NUMPAD4 = 0x64,
    NUMPAD5 = 0x65,
    NUMPAD6 = 0x66,
    NUMPAD7 = 0x67,
    NUMPAD8 = 0x68,
    NUMPAD9 = 0x69,
    MULTIPLY = 0x6A,
    ADD = 0x6B,
    SEPARATOR = 0x6C,
    SUBTRACT = 0x6D,
    DECIMAL = 0x6E,
    DIVIDE = 0x6F,
    F1 = 0x70,
    F2 = 0x71,
    F3 = 0x72,
    F4 = 0x73,
    F5 = 0x74,
    F6 = 0x75,
    F7 = 0x76,
    F8 = 0x77,
    F9 = 0x78,
    F10 = 0x79,
    F11 = 0x7A,
    F12 = 0x7B,
    F13 = 0x7C,
    F14 = 0x7D,
    F15 = 0x7E,
    F16 = 0x7F,
    F17 = 0x80,
    F18 = 0x81,
    F19 = 0x82,
    F20 = 0x83,
    F21 = 0x84,
    F22 = 0x85,
    F23 = 0x86,
    F24 = 0x87,
    NUMLOCK = 0x90,
    SCROLL = 0x91,
    LSHIFT = 0xA0,
    RSHIFT = 0xA1,
    LCONTROL = 0xA2,
    RCONTROL = 0xA3,
    LMENU = 0xA4,
    RMENU = 0xA5,
}
