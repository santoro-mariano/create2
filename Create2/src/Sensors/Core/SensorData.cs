namespace Create2.Sensors.Core
{
  using System;

  public class SensorData
  {
    public SensorData(Sensor sensor, byte[] rawData)
    {
      this.Sensor = sensor;
      this.RawData = rawData;
    }

    public Sensor Sensor { get; }

    public byte[] RawData { get; }

    public sbyte[] AsSignedBytes()
    {
      return Array.ConvertAll(this.RawData, x => unchecked((sbyte) x));
    }

    public long ToLong()
    {
      return BitConverter.ToInt64(this.RawData, 0);
    }

    public int ToInt()
    {
      return BitConverter.ToInt32(this.RawData, 0);
    }

    public short ToShort()
    {
      return BitConverter.ToInt16(this.RawData, 0);
    }

    public ulong ToULong()
    {
      return BitConverter.ToUInt64(this.RawData, 0);
    }

    public uint ToUInt()
    {
      return BitConverter.ToUInt32(this.RawData, 0);
    }

    public ushort ToUShort()
    {
      return BitConverter.ToUInt16(this.RawData, 0);
    }

    public float ToFloat()
    {
      return BitConverter.ToUInt16(this.RawData, 0);
    }

    public double ToDouble()
    {
      return BitConverter.ToDouble(this.RawData, 0);
    }

    public bool ToBoolean()
    {
      return BitConverter.ToBoolean(this.RawData, 0);
    }

    public char ToChar()
    {
      return BitConverter.ToChar(this.RawData, 0);
    }

    public override string ToString()
    {
      return BitConverter.ToString(this.RawData, 0);
    }
  }
}