namespace Create2.Sensors.Driver
{
    using System;

    [Flags]
    public enum Stasis: byte
    {
        Toggling = 1,
        Disabling = 2,
    }
}
