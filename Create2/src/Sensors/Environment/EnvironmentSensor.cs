namespace Create2.Sensors.Environment
{
  using System.Threading.Tasks;
  using Create2.Sensors.Core;

  public class EnvironmentSensor
  {
    private readonly SensorReader sensorReader;

    public EnvironmentSensor(SensorReader sensorReader)
    {
      this.sensorReader = sensorReader;
    }

    public async Task<BumpsAndWheelDrops> GetBumpsAndWheelDrops()
    {
      var bwd = await this.sensorReader.ReadSensor(Packets.BumpsAndWheelDrops).ConfigureAwait(false);
      return (BumpsAndWheelDrops) bwd.RawData[0];
    }

    public async Task<LightBumperDetections> GetLightBumperDetections()
    {
      var detections = await this.sensorReader.ReadSensor(Packets.LightBumper)
        .ConfigureAwait(false);
      return (LightBumperDetections) detections.RawData[0];
    }

    public async Task<ushort> GetLightBumpLeftSignal()
    {
      var signal = await this.sensorReader.ReadSensor(Packets.LightBumpLeftSignal)
        .ConfigureAwait(false);
      return signal.ToUShort();
    }

    public async Task<ushort> GetLightBumpFrontLeftSignal()
    {
      var signal = await this.sensorReader.ReadSensor(Packets.LightBumpFrontLeftSignal)
        .ConfigureAwait(false);
      return signal.ToUShort();
    }

    public async Task<ushort> GetLightBumpCenterLeftSignal()
    {
      var signal = await this.sensorReader.ReadSensor(Packets.LightBumpCenterLeftSignal)
        .ConfigureAwait(false);
      return signal.ToUShort();
    }

    public async Task<ushort> GetLightBumpCenterRightSignal()
    {
      var signal = await this.sensorReader.ReadSensor(Packets.LightBumpCenterRightSignal)
        .ConfigureAwait(false);
      return signal.ToUShort();
    }

    public async Task<ushort> GetLightBumpFrontRightSignal()
    {
      var signal = await this.sensorReader.ReadSensor(Packets.LightBumpFrontRightSignal)
        .ConfigureAwait(false);
      return signal.ToUShort();
    }

    public async Task<ushort> GetLightBumpRightSignal()
    {
      var signal = await this.sensorReader.ReadSensor(Packets.LightBumpRightSignal)
        .ConfigureAwait(false);
      return signal.ToUShort();
    }

    public async Task<bool> GetCliffLeft()
    {
      var cliff = await this.sensorReader.ReadSensor(Packets.CliffLeft).ConfigureAwait(false);
      return cliff.ToBoolean();
    }

    public async Task<bool> GetCliffFrontLeft()
    {
      var cliff = await this.sensorReader.ReadSensor(Packets.CliffFrontLeft).ConfigureAwait(false);
      return cliff.ToBoolean();
    }

    public async Task<bool> GetCliffFrontRight()
    {
      var cliff = await this.sensorReader.ReadSensor(Packets.CliffFrontRight).ConfigureAwait(false);
      return cliff.ToBoolean();
    }

    public async Task<bool> GetCliffRight()
    {
      var cliff = await this.sensorReader.ReadSensor(Packets.CliffRight).ConfigureAwait(false);
      return cliff.ToBoolean();
    }

    public async Task<ushort> GetCliffLeftSignal()
    {
      var signal = await this.sensorReader.ReadSensor(Packets.CliffLeftSignal).ConfigureAwait(false);
      return signal.ToUShort();
    }

    public async Task<ushort> GetCliffFrontLeftSignal()
    {
      var signal = await this.sensorReader.ReadSensor(Packets.CliffFrontLeftSignal).ConfigureAwait(false);
      return signal.ToUShort();
    }

    public async Task<ushort> GetCliffFrontRightSignal()
    {
      var signal = await this.sensorReader.ReadSensor(Packets.CliffFrontRightSignal).ConfigureAwait(false);
      return signal.ToUShort();
    }

    public async Task<ushort> GetCliffRightSignal()
    {
      var signal = await this.sensorReader.ReadSensor(Packets.CliffRightSignal).ConfigureAwait(false);
      return signal.ToUShort();
    }

    public async Task<bool> GetVirtualWall()
    {
      var virtualWall = await this.sensorReader.ReadSensor(Packets.VirtualWall).ConfigureAwait(false);
      return virtualWall.ToBoolean();
    }
  }
}