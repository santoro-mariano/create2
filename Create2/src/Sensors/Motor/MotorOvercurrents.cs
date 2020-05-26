namespace Create2.Sensors.Motor
{
    using System;

    [Flags]
    public enum MotorOverCurrents: byte
    {
        SideBrush = 1,
        MainBrush = 4,
        RightWheel = 8,
        LeftWheel = 16
    }
}
