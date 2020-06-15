namespace Create2.Sensors.Core
{
  public struct SensorPacket
  {
    public SensorPacket(Sensor sensor, int size)
    {
      this.Sensor = sensor;
      this.Size = size;
    }

    public Sensor Sensor { get; }

    public int Size { get; }
  }
}