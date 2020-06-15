namespace Create2.Sensors.Motor
{
  using System.Threading.Tasks;
  using Create2.Sensors.Core;

  public class MotorSensor
  {
    private readonly SensorReader sensorReader;

    public MotorSensor(SensorReader sensorReader)
    {
      this.sensorReader = sensorReader;
    }

    public async Task<short> GetLeftMotorCurrent()
    {
      var current = await this.sensorReader.ReadSensor(Packets.LeftMotorCurrent)
        .ConfigureAwait(false);
      return current.ToShort();
    }

    public async Task<short> GetRightMotorCurrent()
    {
      var current = await this.sensorReader.ReadSensor(Packets.RightMotorCurrent).ConfigureAwait(false);
      return current.ToShort();
    }

    public async Task<short> GetMainBrushMotorCurrent()
    {
      var current = await this.sensorReader.ReadSensor(Packets.MainBrushMotorCurrent).ConfigureAwait(false);
      return current.ToShort();
    }

    public async Task<short> GetSideBrushMotorCurrent()
    {
      var current = await this.sensorReader.ReadSensor(Packets.SideBrushMotorCurrent).ConfigureAwait(false);
      return current.ToShort();
    }

    public async Task<MotorOverCurrents> GetMotorOverCurrents()
    {
      var overCurrents = await this.sensorReader.ReadSensor(Packets.WheelOverCurrents).ConfigureAwait(false);
      return (MotorOverCurrents) overCurrents.RawData[0];
    }
  }
}