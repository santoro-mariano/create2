namespace Create2.Sensors.Battery
{
  using System.Threading.Tasks;
  using Create2.Sensors.Core;

  public class BatterySensor
  {
    private readonly SensorReader sensorReader;

    public BatterySensor(SensorReader sensorReader)
    {
      this.sensorReader = sensorReader;
    }

    public async Task<ChargingState> GetChargingState()
    {
      var state = await this.sensorReader.ReadSensor(Packets.ChargingState)
        .ConfigureAwait(false);
      return (ChargingState) state.RawData[0];
    }

    public async Task<ushort> GetVoltage()
    {
      var voltage = await this.sensorReader.ReadSensor(Packets.Voltage)
        .ConfigureAwait(false);
      return voltage.ToUShort();
    }

    public async Task<short> GetCurrent()
    {
      var current = await this.sensorReader.ReadSensor(Packets.Current)
        .ConfigureAwait(false);
      return current.ToShort();
    }

    public async Task<sbyte> GetTemperature(TemperatureType type = TemperatureType.Celsius)
    {
      var temperature = await this.sensorReader.ReadSensor(Packets.Temperature)
        .ConfigureAwait(false);
      var tc = (sbyte) temperature.RawData[0];
      return type == TemperatureType.Celsius ? tc : (sbyte) (tc * 1.8 + 32);
    }

    public async Task<ushort> GetCharge()
    {
      var charge = await this.sensorReader.ReadSensor(Packets.BatteryCharge)
        .ConfigureAwait(false);
      return charge.ToUShort();
    }

    public async Task<ushort> GetCapacity()
    {
      var capacity = await this.sensorReader.ReadSensor(Packets.BatteryCapacity)
        .ConfigureAwait(false);
      return capacity.ToUShort();
    }

    public async Task<byte> GetChargeInPercentage()
    {
      var values = await this.sensorReader.QueryList(Packets.BatteryCharge, Packets.BatteryCapacity)
        .ConfigureAwait(false);
      var batteryCharge = values[Sensor.BatteryCharge].ToUShort();
      var batteryCapacity = values[Sensor.BatteryCapacity].ToUShort();
      return (byte) (batteryCharge * 100 / batteryCapacity);
    }

    public async Task<ChargingSources> GetChargingSourcesAvailable()
    {
      var sources = await this.sensorReader.ReadSensor(Packets.ChargingSourcesAvailable)
        .ConfigureAwait(false);
      return (ChargingSources) sources.RawData[0];
    }
  }
}