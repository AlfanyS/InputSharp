using InputSharp.InputCommands;
using System.Collections;

namespace InputSharp;
public sealed class InputSequence : IList<InputCommand>
{
    public InputCommand this[int index] { get => _commands[index]; set => _commands[index] = value; }

    public int Count => _commands.Count;

    public bool IsReadOnly => ((ICollection<InputCommand>) _commands).IsReadOnly;

    private readonly List<InputCommand> _commands;
    public InputSequence()
    {
        _commands = new List<InputCommand>();
    }

    public InputSequence(InputSequence sequence)
    {
        _commands = sequence._commands;
    }

    public void Execute()
    {
        foreach (InputCommand item in _commands)
            item.Execute();
    }
    public async Task ExecuteAsync() => await Task.Run(() => Execute());

    public static InputSequenceBuilder Configure() => new InputSequenceBuilder();

    public void Add(InputCommand item) => _commands.Add(item);

    public void Clear() => _commands.Clear();

    public bool Contains(InputCommand item) => _commands.Contains(item);

    public void CopyTo(InputCommand[] array, int arrayIndex) => _commands.CopyTo(array, arrayIndex);

    public IEnumerator<InputCommand> GetEnumerator() => _commands.GetEnumerator();

    public int IndexOf(InputCommand item) => _commands.IndexOf(item);

    public void Insert(int index, InputCommand item) => _commands.Insert(index, item);

    public bool Remove(InputCommand item) => _commands.Remove(item);

    public void RemoveAt(int index) => _commands.RemoveAt(index);

    IEnumerator IEnumerable.GetEnumerator() => _commands.GetEnumerator();
}
