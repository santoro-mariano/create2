namespace Create2.Sensors.Driver
{
  using System.Threading.Tasks;
  using Create2.Sensors.Core;

  public class DriverSensor
  {
    private readonly SensorReader sensorReader;

    public DriverSensor(SensorReader sensorReader)
    {
      this.sensorReader = sensorReader;
    }

    public async Task<short> GetDistance()
    {
      var distance = await this.sensorReader.ReadSensor(Packets.Distance)
        .ConfigureAwait(false);
      return distance.ToShort();
    }

    public async Task<short> GetAngle()
    {
      var angle = await this.sensorReader.ReadSensor(Packets.Angle)
        .ConfigureAwait(false);
      return angle.ToShort();
    }

    public async Task<short> LastRequestedVelocity()
    {
      var velocity = await this.sensorReader.ReadSensor(Packets.RequestedVelocity)
        .ConfigureAwait(false);
      return velocity.ToShort();
    }

    public async Task<short> LastRequestedRadius()
    {
      var radius = await this.sensorReader.ReadSensor(Packets.RequestedRadius)
        .ConfigureAwait(false);
      return radius.ToShort();
    }

    public async Task<short> LastRequestedLeftWheelVelocity()
    {
      var leftVelocity = await this.sensorReader.ReadSensor(Packets.RequestedLeftVelocity)
        .ConfigureAwait(false);
      return leftVelocity.ToShort();
    }

    public async Task<short> LastRequestedRightWheelVelocity()
    {
      var rightVelocity = await this.sensorReader.ReadSensor(Packets.RequestedRightVelocity)
        .ConfigureAwait(false);
      return rightVelocity.ToShort();
    }

    public async Task<Stasis> GetStasis()
    {
      var stasis = await this.sensorReader.ReadSensor(Packets.Stasis)
        .ConfigureAwait(false);
      return (Stasis) stasis.RawData[0];
    }
  }
}