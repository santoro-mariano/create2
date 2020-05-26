namespace Create2.Exceptions
{
    using System;
    using Create2.OI;
    using Create2.Sensors.OI;

    public class InvalidModeException: Exception
    {
        public InvalidModeException(OIMode currentMode, OIMode neededMode, OpCode operation) :
            base(
                $"The operation {operation} can't be performed in the current mode. (Current Mode: {currentMode}, Needed Mode: {neededMode})")
        {
            this.CurrentMode = currentMode;
            this.NeededMode = neededMode;
            this.Operation = operation;
        }

        public OIMode CurrentMode { get; }

        public OIMode NeededMode { get; }

        public OpCode Operation { get; }
    }
}
