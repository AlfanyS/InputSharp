﻿using InputSharp.InputCommands;
using InputSharp.WinApi;

namespace InputSharp.Parsers;

public class VirtualKeyParser : KeyParser
{
    protected override List<KeyboardCommand>? ParseSymbol(char symbol, List<CharOnKeyboard> map)
    {
        var result = new List<KeyboardCommand>();
        var grammar = (from item in map select (CharOnKeyboardVirtual) item).ToList();

        var key = grammar.Find(k => k.symbol == char.ToLower(symbol));
        if (key == null)
            return null;

        if (char.IsUpper(symbol) || key.requiresShift)
        {
            result.Add(new KeyboardCommand(VirtualKey.LSHIFT, KeyboardEvent.KeyDown));
            result.Add(new KeyboardCommand(key.key, KeyboardEvent.KeyClick));
            result.Add(new KeyboardCommand(VirtualKey.LSHIFT, KeyboardEvent.KeyUp));
        }
        else
        {
            result.Add(new KeyboardCommand(key.key, KeyboardEvent.KeyClick));
        }

        return result;
    }
}