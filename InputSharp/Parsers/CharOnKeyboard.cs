using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputSharp.Parsers
{
    public abstract record CharOnKeyboard(char symbol, bool requiresShift);

    public record CharOnKeyboardDirect(char symbol, bool requiresShift, ScanKey key) : CharOnKeyboard(symbol, requiresShift)
    {
        public static implicit operator CharOnKeyboardDirect((char symbol, ScanKey key, bool requiresShift) tuple) =>
            new CharOnKeyboardDirect(tuple.symbol, tuple.requiresShift, tuple.key);
    }

    public record CharOnKeyboardVirtual(char symbol, bool requiresShift, VirtualKey key) : CharOnKeyboard(symbol, requiresShift)
    {
        public static implicit operator CharOnKeyboardVirtual((char symbol, VirtualKey key, bool requiresShift) tuple) =>
            new CharOnKeyboardVirtual(tuple.symbol, tuple.requiresShift, tuple.key);
    }
}
