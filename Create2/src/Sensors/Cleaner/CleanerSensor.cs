namespace Create2.Sensors.Cleaner
{
  using System.Threading.Tasks;
  using Create2.Sensors.Core;

  public class CleanerSensor
  {
    private readonly SensorReader sensorReader;

    public CleanerSensor(SensorReader sensorReader)
    {
      this.sensorReader = sensorReader;
    }

    public async Task<byte> GetDirtDetect()
    {
      var dirt = await this.sensorReader.ReadSensor(Packets.DirtDetect).ConfigureAwait(false);
      return dirt.RawData[0];
    }
  }
}