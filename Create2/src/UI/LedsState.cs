namespace Create2.UI
{
    public class LedsState
    {
        public bool Debris { get; set; }

        public bool Spot { get; set; }

        public bool Dock { get; set; }

        public bool CheckRobot { get; set; }

        public ComplexLedState Power { get; set; }

        public byte[] AsByteArray()
        {
            byte leds = 0;
            if (this.Debris)
            {
                leds = 1;
            }

            if (this.Spot)
            {
                leds |= 2;
            }

            if (this.Dock)
            {
                leds |= 4;
            }

            if (this.CheckRobot)
            {
                leds |= 8;
            }

            return new[] {leds, this.Power.Color, this.Power.Intensity};
        }
    }
}
