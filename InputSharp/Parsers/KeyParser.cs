using InputSharp.InputCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputSharp.Parsers
{
    public abstract class KeyParser
    {
        public List<KeyboardCommand> Parse(string text, List<CharOnKeyboard> map)
        {
            var result = new List<KeyboardCommand>();
            foreach (var symbol in text)
            {
                var commands = ParseSymbol(symbol, map);
                if (commands != null)
                    result = (List<KeyboardCommand>)result.Concat(commands);
            }
            return result;
        }
        protected abstract List<KeyboardCommand> ParseSymbol(char symbol, List<CharOnKeyboard> map);
    }
}
