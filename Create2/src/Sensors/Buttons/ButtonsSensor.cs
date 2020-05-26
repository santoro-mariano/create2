namespace Create2.Sensors.Buttons
{
    using System.Threading.Tasks;
    using Create2.Sensors.Core;

    public class ButtonsSensor
    {
        private readonly SensorReader sensorReader;

        public ButtonsSensor(SensorReader sensorReader)
        {
            this.sensorReader = sensorReader;
        }

        public async Task<PressedButtons> GetPressedButtons()
        {
            var buttons = await this.sensorReader.ReadSensor(Packets.Buttons).ConfigureAwait(false);
            return (PressedButtons) buttons.RawData[0];
        }
    }
}
