using InputSharp.InputCommands;
using InputSharp.Parsers;

namespace InputSharp.Extensions;
public static class InputSequenceExtensions
{
    public static InputSequence ClickKey(this InputSequence sequence, VirtualKey key)
    {
        sequence.Add(new KeyboardCommand(key, KeyboardEvent.KeyClick));
        return sequence;
    }
    public static InputSequence ClickKey(this InputSequence sequence, ScanKey key)
    {
        sequence.Add(new KeyboardCommand(key, KeyboardEvent.KeyClick));
        return sequence;
    }

    public static InputSequence KeyDown(this InputSequence sequence, VirtualKey key)
    {
        sequence.Add(new KeyboardCommand(key, KeyboardEvent.KeyDown));
        return sequence;
    }
    public static InputSequence KeyDown(this InputSequence sequence, ScanKey key)
    {
        sequence.Add(new KeyboardCommand(key, KeyboardEvent.KeyDown));
        return sequence;
    }
    public static InputSequence KeyUp(this InputSequence sequence, VirtualKey key)
    {
        sequence.Add(new KeyboardCommand(key, KeyboardEvent.KeyUp));
        return sequence;
    }
    public static InputSequence KeyUp(this InputSequence sequence, ScanKey key)
    {
        sequence.Add(new KeyboardCommand(key, KeyboardEvent.KeyUp));
        return sequence;
    }

    public static InputSequence Wait(this InputSequence sequence, uint millisecondsDelay)
    {
        sequence.Add(new DelayCommand((int)millisecondsDelay));
        return sequence;
    }
    public static InputSequence KeyCombo(this InputSequence sequence, params VirtualKey[] keys)
    {
        foreach (var key in keys)
            sequence.Add(new KeyboardCommand(key, KeyboardEvent.KeyDown));
        foreach (var key in keys)
            sequence.Add(new KeyboardCommand(key, KeyboardEvent.KeyUp));
        return sequence;
    }
    public static InputSequence KeyCombo(this InputSequence sequence, params ScanKey[] keys)
    {
        foreach (var key in keys)
            sequence.Add(new KeyboardCommand(key, KeyboardEvent.KeyDown));
        foreach (var key in keys)
            sequence.Add(new KeyboardCommand(key, KeyboardEvent.KeyUp));
        return sequence;
    }
    public static InputSequence MouseLClick(this InputSequence sequence)
    {
        sequence.Add(new MouseCommand(MouseEvent.LeftClick));
        return sequence;
    }
    public static InputSequence MouseRClick(this InputSequence sequence)
    {
        sequence.Add(new MouseCommand(MouseEvent.RightClick));
        return sequence;
    }
    public static InputSequence MouseLDown(this InputSequence sequence)
    {
        sequence.Add(new MouseCommand(MouseEvent.LeftDown));
        return sequence;
    }
    public static InputSequence MouseLUp(this InputSequence sequence)
    {
        sequence.Add(new MouseCommand(MouseEvent.LeftUp));
        return sequence;
    }
    public static InputSequence MouseRDown(this InputSequence sequence)
    {
        sequence.Add(new MouseCommand(MouseEvent.RightDown));
        return sequence;
    }
    public static InputSequence MouseRUp(this InputSequence sequence)
    {
        sequence.Add(new MouseCommand(MouseEvent.RightUp));
        return sequence;
    }
    /// <summary>
    /// Rotate mouse wheel. One wheel click is 120. Positive rotates forward(up). Negative rotates backward(down).
    /// </summary>
    /// <param name="weheelMovement">One wheel click is 120</param>
    public static InputSequence Wheel(this InputSequence sequence, int weheelMovement)
    {
        sequence.Add(new MouseCommand(weheelMovement));
        return sequence;
    }
    public static InputSequence MouseMove(this InputSequence sequence, int x, int y)
    {
        sequence.Add(new MouseCommand(x, y, MouseMovement.Move));
        return sequence;
    }
    public static InputSequence MouseMove(this InputSequence sequence, Point deltaVector)
    {
        sequence.Add(new MouseCommand(deltaVector.x, deltaVector.y, MouseMovement.Move));
        return sequence;
    }
    public static InputSequence SetCursorPos(this InputSequence sequence, int x, int y)
    {
        sequence.Add(new MouseCommand(x, y, MouseMovement.SetPos));
        return sequence;
    }
    public static InputSequence SetCursorPos(this InputSequence sequence, Point deltaVector)
    {
        sequence.Add(new MouseCommand(deltaVector.x, deltaVector.y, MouseMovement.SetPos));
        return sequence;
    }
    public static InputSequence Parse(this InputSequence sequence, string text, List<CharOnKeyboard> language)
    {
        foreach (var command in new DirectKeyParser().Parse(text, language))
            sequence.Add(command);
        return sequence;
    }
    public static InputSequence VkeyParse(this InputSequence sequence, string text, List<CharOnKeyboard> language)
    {
        foreach (var command in new VirtualKeyParser().Parse(text, language))
            sequence.Add(command);
        return sequence;
    }

    /// <summary>
    /// Repeat commands several times.
    /// </summary>
    /// <param name="sequence">Source sequence.</param>
    /// <param name="count">Execution count.</param>
    /// <param name="commands">Func with empty <see cref="InputSequence"/> that will be executed <paramref name="count"/> times.</param>
    public static InputSequence Repeat(this InputSequence sequence, int count, Func<InputSequence, InputSequence> commands)
    {
        sequence.Add(new RepeatCommand(count, commands(new InputSequence()).ToArray()));
        return sequence;
    }
    /// <summary>
    /// Execute commands if predicate is true.
    /// </summary>
    /// <param name="sequence">Source sequence.</param>
    /// <param name="predicate">Condition</param>
    /// <param name="commands">Func with empty <see cref="InputSequence"/> that will be executed if predicate is true.</param>
    /// <returns></returns>
    public static InputSequence If(this InputSequence sequence, Func<bool> predicate, Func<InputSequence, InputSequence> commands)
    {
        sequence.Add(new IfCommand(predicate, commands(new InputSequence()).ToArray()));
        return sequence;
    }
}
