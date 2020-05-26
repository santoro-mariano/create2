namespace Create2.Sensors.Battery
{
    using System;

    [Flags]
    public enum ChargingSources: byte
    {
        InternalCharger = 1,
        HomeBase = 2
    }
}
