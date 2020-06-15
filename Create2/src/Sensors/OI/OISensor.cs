namespace Create2.Sensors.OI
{
  using System.Threading.Tasks;
  using Create2.Sensors.Core;

  public class OISensor
  {
    private readonly SensorReader sensorReader;

    public OISensor(SensorReader sensorReader)
    {
      this.sensorReader = sensorReader;
    }

    public async Task<OIMode> GetOIMode()
    {
      var oiMode = await this.sensorReader.ReadSensor(Packets.OIMode).ConfigureAwait(false);
      return (OIMode) oiMode.RawData[0];
    }

    public Task<bool> CheckIsActive()
    {
      return this.GetOIMode().ContinueWith(x => x.Result == OIMode.Safe ||
                                                x.Result == OIMode.Full);
    }

    public Task<bool> CheckIsStarted()
    {
      return this.GetOIMode().ContinueWith(x => x.Result == OIMode.Safe ||
                                                x.Result == OIMode.Full ||
                                                x.Result == OIMode.Passive);
    }
  }
}