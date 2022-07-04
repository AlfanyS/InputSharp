using InputSharp.InputCommands;

namespace InputSharp.Parsers;

public class DirectKeyParser : KeyParser
{
    protected override List<KeyboardCommand>? ParseSymbol(char symbol, List<CharOnKeyboard> map)
    {
        var result = new List<KeyboardCommand>();
        var grammar = (from item in map select (CharOnKeyboardDirect) item).ToList();

        var key = grammar.Find(k => k.symbol == char.ToLower(symbol));
        if (key == null)
            return null;

        if (char.IsUpper(symbol) || key.requiresShift)
        {
            result.Add(new KeyboardCommand(ScanKey.LShift, KeyboardEvent.KeyDown));
            result.Add(new KeyboardCommand(key.key, KeyboardEvent.KeyClick));
            result.Add(new KeyboardCommand(ScanKey.LShift, KeyboardEvent.KeyUp));
        }
        else
        {
            result.Add(new KeyboardCommand(key.key, KeyboardEvent.KeyClick));
        }

        return result;
    }
}