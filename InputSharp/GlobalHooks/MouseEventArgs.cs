using InputSharp.WinApi;

namespace InputSharp.GlobalHooks;

public record MouseEventArgs(MouseMessage message, int x, int y)
{
    public Point position => new Point(x, y);
}