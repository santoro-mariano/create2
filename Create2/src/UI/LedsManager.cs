namespace Create2.UI
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Create2.Device;
    using Create2.OI;

    public class LedsManager
    {
        private readonly Robot robot;
        private readonly OIDispatcher dispatcher;

        private readonly LedsState ledsState = new LedsState();

        public LedsManager(Robot robot, OIDispatcher dispatcher)
        {
            this.robot = robot;
            this.dispatcher = dispatcher;
        }

        public Task ToggleDebris()
        {
            return this.SetDebris(!this.ledsState.Debris);
        }

        public Task SetDebris(bool status)
        {
            this.ledsState.Debris = status;
            return this.RefreshLeds();
        }

        public Task ToggleSpot()
        {
            return this.SetSpot(!this.ledsState.Spot);
        }

        public Task SetSpot(bool status)
        {
            this.ledsState.Spot = status;
            return this.RefreshLeds();
        }

        public Task ToggleDock()
        {
            return this.SetDock(!this.ledsState.Dock);
        }

        public Task SetDock(bool status)
        {
            this.ledsState.Dock = status;
            return this.RefreshLeds();
        }

        public Task ToggleCheckRobot()
        {
            return this.SetCheckRobot(!this.ledsState.CheckRobot);
        }

        public Task SetCheckRobot(bool status)
        {
            this.ledsState.CheckRobot = status;
            return this.RefreshLeds();
        }

        public Task TogglePower()
        {
            var intensity = (byte)Math.Abs(this.ledsState.Power.Intensity - 255);
            return this.SetPower(this.ledsState.Power.Color, intensity);
        }

        public Task SetPower(byte color, byte intensity)
        {
            this.ledsState.Power.Color = color;
            this.ledsState.Power.Intensity = intensity;
            return this.RefreshLeds();
        }

        public Task SetDigitLed(params LedSegments[] leds)
        {
            if (!this.robot.IsActive)
            {
                return Task.CompletedTask;
            }

            var data = leds.Select(x => (byte) x).Take(4).ToArray();
            return this.dispatcher.SendCommand(OpCode.DigitalLedsRaw, data);
        }

        public Task SetDigitLed(string text)
        {
            if (!this.robot.IsActive)
            {
                return Task.CompletedTask;
            }

            var data = Encoding.ASCII.GetBytes(text).Take(4).ToArray();
            return this.dispatcher.SendCommand(OpCode.DigitalLedsAscii, data);
        }

        private Task RefreshLeds()
        {
            return Task.CompletedTask;
        }
    }
}
