namespace InputSharp.InputCommands;

public sealed class MouseCommand : InputCommand
{
    public readonly MouseEvent button;
    public readonly MouseMovement movementEv;
    public readonly int wheelMovement;
    public readonly int x;
    public readonly int y;

    public MouseCommand(int x, int y, MouseMovement @event)
    {
        this.x = x;
        this.y = y;
        movementEv = @event;
    }

    public MouseCommand(Point position, MouseMovement @event)
    {
        x = position.x;
        y = position.y;
        movementEv = @event;
    }

    public MouseCommand(MouseEvent button)
    {
        this.button = button;
    }

    /// <summary>
    ///     Rotates mouse wheel.
    /// </summary>
    /// <param name="weheelMovement">One wheel click is 120</param>
    /// <param name="ev"></param>
    public MouseCommand(int wheelMovement)
    {
        this.wheelMovement = wheelMovement;
    }

    public override void Execute()
    {
        if (movementEv != MouseMovement.None)
            switch (movementEv)
            {
                case MouseMovement.Move:
                    InputManager.MouseMove(x, y);
                    break;
                case MouseMovement.SetPos:
                    InputManager.SetCursorPos(new Point(x, y));
                    break;
            }
        else if (wheelMovement != 0)
            InputManager.MouseWheel(wheelMovement);
        else
            switch (button)
            {
                case MouseEvent.LeftClick:
                    InputManager.Mouse(MouseEvent.LeftDown);
                    InputManager.Mouse(MouseEvent.LeftUp);
                    break;
                case MouseEvent.RightClick:
                    InputManager.Mouse(MouseEvent.RightDown);
                    InputManager.Mouse(MouseEvent.RightUp);
                    break;
                case MouseEvent.MiddleClick:
                    InputManager.Mouse(MouseEvent.MiddleDown);
                    InputManager.Mouse(MouseEvent.MiddleUp);
                    break;
                case MouseEvent.XClick:
                    InputManager.Mouse(MouseEvent.XDown);
                    InputManager.Mouse(MouseEvent.XUp);
                    break;
                default:
                    InputManager.Mouse(button);
                    break;
            }
    }

    public override string ToString()
    {
        if (button != MouseEvent.None)
            return $"{button}";
        if (movementEv != MouseMovement.None)
            return $"{movementEv} X:{x} Y:{y}";
        return $"WheelMovement: {wheelMovement}";
    }
}