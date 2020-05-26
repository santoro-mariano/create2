namespace Create2.Motors
{
    using System;

    [Flags]
    internal enum MotorsFlags: byte
    {
        None = 0,
        SideBrush = 1,
        Vacuum = 2,
        MainBrush = 4,
        SideBrushClockwise = 8,
        MainBrushDirection = 16
    }
}
