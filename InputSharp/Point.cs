using System.Runtime.InteropServices;

namespace InputSharp;

[StructLayout(LayoutKind.Sequential)]
public struct Point
{
    public int x;
    public int y;

    public Point()
    {
        x = 0;
        y = 0;
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return $"x={x}, y={y}";
    }

    public static implicit operator Point((int x, int y) tuple)
    {
        return new(tuple.x, tuple.y);
    }

    public void Deconstruct(out int x, out int y)
    {
        x = this.x;
        y = this.y;
    }
}