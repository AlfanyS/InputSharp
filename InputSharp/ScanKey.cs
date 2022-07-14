namespace InputSharp;

/// <summary>
///     Scan codes.
/// </summary>
public enum ScanKey
{
    /// <summary>
    ///     Absence of key.
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
    ///     - on main keyboard.
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
    ///     Enter on main keyboard.
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
    ///     Accent grave. ` on main keyboard.
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
    ///     . on main keyboard.
    /// </summary>
    Dot = 0x34,

    /// <summary>
    ///     / on main keyboard.
    /// </summary>
    Slash = 0x35,
    RShift = 0x36,

    /// <summary>
    ///     * on numeric keypad.
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
    ///     - on numeric keypad.
    /// </summary>
    Subtract = 0x4A,
    Num4 = 0x4B,
    Num5 = 0x4C,
    Num6 = 0x4D,

    /// <summary>
    ///     + on numeric keypad.
    /// </summary>
    Add = 0x4E,
    Num1 = 0x4F,
    Num2 = 0x50,
    Num3 = 0x51,
    Num0 = 0x52,

    /// <summary>
    ///     . on numeric keypad.
    /// </summary>
    Decimal = 0x53,

    /// <summary>
    ///     &lt;&gt; or | on RT 102-key keyboard (Non-U.S.).
    /// </summary>
    OEM_102 = 0x56,
    F11 = 0x57,
    F12 = 0x58,
    F13 = 0x64, /*                     (NEC PC98) */
    F14 = 0x65, /*                     (NEC PC98) */
    F15 = 0x66, /*                     (NEC PC98) */

    /// <summary>
    ///     Japanese keyboard.
    /// </summary>
    Kana = 0x70,

    /// <summary>
    ///     ? on Brazilian keyboard.
    /// </summary>
    ABNT_C1 = 0x73,

    /// <summary>
    ///     Japanese keyboard.
    /// </summary>
    Convert = 0x79,

    /// <summary>
    ///     Japanese keyboard.
    /// </summary>
    NoConvert = 0x7B,

    /// <summary>
    ///     Japanese keyboard.
    /// </summary>
    Yen = 0x7D,

    /// <summary>
    ///     Numpad . on Brazilian keyboard.
    /// </summary>
    ABNT_C2 = 0x7E,

    /// <summary>
    ///     = on numeric keypad (NEC PC98)
    /// </summary>
    NumEquals = 0x8D,

    /// <summary>
    ///     Previous Track (DIK_CIRCUMFLEX on Japanese keyboard)
    /// </summary>
    PrevTrack = 0x90,
    At = 0x91, /*                     (NEC PC98) */
    Colon = 0x92, /*                     (NEC PC98) */
    Underline = 0x93, /*                     (NEC PC98) */

    /// <summary>
    ///     Japanese keyboard.
    /// </summary>
    Kanji = 0x94,
    Stop = 0x95, /*                     (NEC PC98) */

    /// <summary>
    ///     Japan AX.
    /// </summary>
    Ax = 0x96,
    Unlabeled = 0x97, /*(J3100) */

    /// <summary>
    ///     Next Track.
    /// </summary>
    NextTrack = 0x99,

    /// <summary>
    ///     Enter on numeric keypad.
    /// </summary>
    NumEnter = 0x9C,
    RCtrl = 0x9D,
    Mute = 0xA0,
    Calculator = 0xA1,
    PlayPause = 0xA2,
    MediaStop = 0xA4,

    /// <summary>
    ///     Volume -.
    /// </summary>
    VolumeDown = 0xAE,

    /// <summary>
    ///     Volume +.
    /// </summary>
    VolumeUp = 0xB0,
    WebHome = 0xB2,

    /// <summary>
    ///     , on numeric keypad (NEC PC98).
    /// </summary>
    NumComma = 0xB3,

    /// <summary>
    ///     / on numeric keypad.
    /// </summary>
    Divide = 0xB5,
    SYSRQ = 0xB7,
    RAlt = 0xB8,
    Pause = 0xC5,

    /// <summary>
    ///     Home on arrow keypad.
    /// </summary>
    Home = 0xC7,

    /// <summary>
    ///     UpArrow on arrow keypad.
    /// </summary>
    Up = 0xC8,

    /// <summary>
    ///     PageUp on arrow keypad.
    /// </summary>
    PgUp = 0xC9,

    /// <summary>
    ///     LeftArrow on arrow keypad.
    /// </summary>
    Left = 0xCB,

    /// <summary>
    ///     RightArrow on arrow keypad.
    /// </summary>
    Right = 0xCD,

    /// <summary>
    ///     End on arrow keypad.
    /// </summary>
    End = 0xCF,

    /// <summary>
    ///     DownArrow on arrow keypad.
    /// </summary>
    Down = 0xD0,

    /// <summary>
    ///     PageDown on arrow keypad.
    /// </summary>
    PgDn = 0xD1,

    /// <summary>
    ///     Insert on arrow keypad.
    /// </summary>
    Insert = 0xD2,

    /// <summary>
    ///     Delete on arrow keypad.
    /// </summary>
    Delete = 0xD3,

    /// <summary>
    ///     Left Windows key.
    /// </summary>
    LWin = 0xDB,

    /// <summary>
    ///     Right Windows key.
    /// </summary>
    RWin = 0xDC,

    /// <summary>
    ///     AppMenu key
    /// </summary>
    Apps = 0xDD,

    /// <summary>
    ///     System Power.
    /// </summary>
    Power = 0xDE,

    /// <summary>
    ///     System Sleep.
    /// </summary>
    Sleep = 0xDF,

    /// <summary>
    ///     System Wake.
    /// </summary>
    Wake = 0xE3,
    WebSearch = 0xE5,
    WebFavourites = 0xE6,
    WebRefresh = 0xE7,
    WebStop = 0xE8,
    WebForward = 0xE9,
    WebBack = 0xEA,
    MyComputer = 0xEB,
    Mail = 0xEC,
    MediaSelect = 0xED
}