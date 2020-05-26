namespace Create2.Sensors.Environment
{
    using System;

    [Flags]
    public enum BumpsAndWheelDrops: byte
    {
        None = 0,
        BumpRight = 1,
        BumpLeft = 2,
        WheelDropRight = 4,
        WheelDropLeft = 8
    }
}
