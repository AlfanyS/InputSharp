using System.Runtime.InteropServices;

namespace InputSharp;

public static class InputManager
{
    public static Point GetCursorPos()
    {
        NativeMethods.GetCursorPos(out Point position);
        return position;
    }

    public static bool TryGetCursorPos(out Point position) => NativeMethods.GetCursorPos(out position);
    public static void SetCursorPos(Point position) => NativeMethods.SetCursorPos(position.x, position.y);
    public static bool TrySetCursorPos(Point position) => NativeMethods.SetCursorPos(position.x, position.y);

    public static void ClickKey(VirtualKey key)
    {
        Input[] inputs = {
            new Input
            {
                type = (int) InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = (ushort) key,
                        wScan = 0,
                        dwFlags = (uint) KeyEvent.KeyDown,
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int) InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = (ushort) key,
                        wScan = 0,
                        dwFlags = (uint) KeyEvent.KeyUp,
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            }
        };
        NativeMethods.SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public static void ClickKey(ScanKey key)
    {
        Input[] inputs = {
            new Input
            {
                type = (int) InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = (ushort) key,
                        dwFlags = (uint) (KeyEvent.KeyDown | KeyEvent.Scancode),
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int) InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = (ushort) key,
                        dwFlags = (uint) (KeyEvent.KeyUp | KeyEvent.Scancode),
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            }
        };
        NativeMethods.SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public static void KeyDown(ScanKey key)
    {
        Input[] inputs = {
            new Input
            {
                type = (int) InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = (ushort) key,
                        dwFlags = (uint) (KeyEvent.KeyDown | KeyEvent.Scancode),
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            }
        };
        NativeMethods.SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public static void KeyUp(ScanKey key)
    {
        Input[] inputs = {
            new Input
            {
                type = (int) InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = (ushort) key,
                        dwFlags = (uint) (KeyEvent.KeyUp | KeyEvent.Scancode),
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            }
        };
        NativeMethods.SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public static void KeyDown(VirtualKey key)
    {
        Input[] inputs = {
            new Input
            {
                type = (int) InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = (ushort) key,
                        wScan = 0,
                        dwFlags = (uint) KeyEvent.KeyDown,
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            }
        };
        NativeMethods.SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public static void KeyUp(VirtualKey key)
    {
        Input[] inputs = {
            new Input
            {
                type = (int) InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = (ushort) key,
                        wScan = 0,
                        dwFlags = (uint) KeyEvent.KeyUp,
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            }
        };
        NativeMethods.SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public static void MouseMove(int deltaX, int deltaY)
    {
        Input[] inputs = {
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dx = deltaX,
                        dy = deltaY,
                        dwFlags = (uint) MouseEventF.Move,
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            }
        };
        NativeMethods.SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public static void MouseMove(Point deltaVector)
    {
        Input[] inputs = {
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dx = deltaVector.x,
                        dy = deltaVector.y,
                        dwFlags = (uint) MouseEventF.Move,
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            }
        };
        NativeMethods.SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public static void Mouse(MouseEvent button)
    {
        switch (button)
        {
            case MouseEvent.LeftClick:
                Mouse(MouseEvent.LeftDown);
                Mouse(MouseEvent.LeftUp);
                return;
            case MouseEvent.RightClick:
                Mouse(MouseEvent.RightDown);
                Mouse(MouseEvent.RightUp);
                return;
            case MouseEvent.MiddleClick:
                Mouse(MouseEvent.MiddleDown);
                Mouse(MouseEvent.MiddleUp);
                return;
            case MouseEvent.XClick:
                Mouse(MouseEvent.XDown);
                Mouse(MouseEvent.XUp);
                return;
        }

        Input[] inputs = {
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dwFlags = (uint) button,
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            }
        };
        NativeMethods.SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    /// <summary>
    /// Rotates mouse wheel.
    /// </summary>
    /// <param name="wheelMovement">One wheel click is 120</param>
    /// <param name="ev"></param>
    public static void MouseWheel(int wheelMovement)
    {
        Input[] inputs = {
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        mouseData = (uint) wheelMovement,
                        dwFlags = (uint) MouseEventF.Wheel,
                        dwExtraInfo = NativeMethods.GetMessageExtraInfo()
                    }
                }
            }
        };
        NativeMethods.SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }
}