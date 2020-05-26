namespace Create2.UI
{
    using System;

    [Flags]
    public enum Buttons: byte
    {
        Clean = 1,
        Spot = 2,
        Dock = 4,
        Minute = 8,
        Hour = 16,
        Day = 32,
        Schedule = 64,
        Clock = 128
    }
}
