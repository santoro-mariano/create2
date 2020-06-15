namespace Create2.Sensors.Infrared
{
  using Create2.Sensors.Core;

  public class ReceiverSensor
  {
    private readonly SensorReader sensorReader;

    public ReceiverSensor(SensorReader sensorReader)
    {
      this.sensorReader = sensorReader;
    }
  }
}