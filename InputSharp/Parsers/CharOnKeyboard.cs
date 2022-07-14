using InputSharp.WinApi;

namespace InputSharp.Parsers;

public abstract record CharOnKeyboard(char symbol, bool requiresShift);

public record CharOnKeyboardDirect(char symbol, bool requiresShift, ScanKey key) : CharOnKeyboard(symbol, requiresShift)
{
    public static implicit operator CharOnKeyboardDirect((char symbol, ScanKey key, bool requiresShift) tuple)
    {
        return new(tuple.symbol, tuple.requiresShift, tuple.key);
    }
}

public record CharOnKeyboardVirtual(char symbol, bool requiresShift, VirtualKey key) : CharOnKeyboard(symbol,
    requiresShift)
{
    public static implicit operator CharOnKeyboardVirtual((char symbol, VirtualKey key, bool requiresShift) tuple)
    {
        return new(tuple.symbol, tuple.requiresShift, tuple.key);
    }
}