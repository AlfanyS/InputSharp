using InputSharp.Extensions;
using InputSharp.Parsers;

namespace InputSharp;

public class InputSequenceBuilder
{
    private readonly InputSequence _sequence = new();

    public InputSequenceBuilder ClickKey(VirtualKey key)
    {
        _sequence.ClickKey(key);
        return this;
    }

    public InputSequenceBuilder ClickKey(ScanKey key)
    {
        _sequence.ClickKey(key);
        return this;
    }

    public InputSequenceBuilder KeyDown(VirtualKey key)
    {
        _sequence.KeyDown(key);
        return this;
    }

    public InputSequenceBuilder KeyDown(ScanKey key)
    {
        _sequence.KeyDown(key);
        return this;
    }

    public InputSequenceBuilder KeyUp(VirtualKey key)
    {
        _sequence.KeyUp(key);
        return this;
    }

    public InputSequenceBuilder KeyUp(ScanKey key)
    {
        _sequence.KeyUp(key);
        return this;
    }

    public InputSequenceBuilder Wait(uint millisecondsDelay)
    {
        _sequence.Wait(millisecondsDelay);
        return this;
    }

    public InputSequenceBuilder KeyCombo(params VirtualKey[] keys)
    {
        _sequence.KeyCombo(keys);
        return this;
    }

    public InputSequenceBuilder KeyCombo(params ScanKey[] keys)
    {
        _sequence.KeyCombo(keys);
        return this;
    }

    public InputSequenceBuilder MouseLClick()
    {
        _sequence.MouseLClick();
        return this;
    }

    public InputSequenceBuilder MouseRClick()
    {
        _sequence.MouseRClick();
        return this;
    }

    public InputSequenceBuilder MouseLDown()
    {
        _sequence.MouseLDown();
        return this;
    }

    public InputSequenceBuilder MouseLUp()
    {
        _sequence.MouseLUp();
        return this;
    }

    public InputSequenceBuilder MouseRDown()
    {
        _sequence.MouseRDown();
        return this;
    }

    public InputSequenceBuilder MouseRUp()
    {
        _sequence.MouseRUp();
        return this;
    }

    /// <summary>
    ///     Rotate mouse wheel. One wheel click is 120. Positive rotates forward(up). Negative rotates backward(down).
    /// </summary>
    /// <param name="weheelMovement">One wheel click is 120</param>
    public InputSequenceBuilder Wheel(int weheelMovement)
    {
        _sequence.Wheel(weheelMovement);
        return this;
    }

    public InputSequenceBuilder MouseMove(int x, int y)
    {
        _sequence.MouseMove(x, y);
        return this;
    }

    public InputSequenceBuilder MouseMove(Point deltaVector)
    {
        _sequence.MouseMove(deltaVector.x, deltaVector.y);
        return this;
    }

    public InputSequenceBuilder SetCursorPos(int x, int y)
    {
        _sequence.SetCursorPos(x, y);
        return this;
    }

    public InputSequenceBuilder SetCursorPos(Point deltaVector)
    {
        _sequence.SetCursorPos(deltaVector.x, deltaVector.y);
        return this;
    }

    public InputSequenceBuilder Parse(string text, List<CharOnKeyboard> langueage)
    {
        _sequence.Parse(text, langueage);
        return this;
    }

    public InputSequence Build() => new(_sequence);
}