namespace Create2.Sensors.Environment
{
    using System;

    [Flags]
    public enum LightBumperDetections: byte
    {
        None = 0,
        Left = 1,
        FrontLeft = 2,
        CenterLeft = 4,
        CenterRight = 8,
        FrontRight = 16,
        Right = 32
    }
}
