namespace Create2.OI
{
  using System;
  using System.Collections.Generic;
  using System.IO.Ports;
  using System.Threading.Tasks;
  using Create2.Extensions;
  using Create2.Settings;
  using Microsoft.Extensions.Logging;
  using Microsoft.Extensions.Options;

  public class OIDispatcher : IDisposable
  {
    private readonly SerialPort port;
    private readonly ILogger logger;

    public const byte NewLine = 10;

    public OIDispatcher(IOptions<OISettings> settings, ILogger<OIDispatcher> logger)
    {
      this.port = new SerialPort(settings.Value.PortName, settings.Value.BaudRate);
      this.port.Open();
      this.logger = logger;
      this.logger.LogInformation($"OIDispatcher (Port: {this.port.PortName}, BaudRate: {this.port.BaudRate})");
      this.logger.LogDebug($"WriteBufferSize: {this.port.WriteBufferSize}, ReadBufferSize: {this.port.ReadBufferSize}");
    }

    public Task SendCommand(OpCode code, params byte[] data)
    {
      this.logger.LogInformation($"Sending command (OpCode: {code}, Data: [{string.Join(",", data)}])");
      return this.SendCommand((byte) code, data);
    }

    public Task SendCommand(byte code, params byte[] data)
    {
      data ??= new byte[0];
      return this.SendCommand(data.Shift(code));
    }

    private Task SendCommand(byte[] data)
    {
      return Task.Run(() =>
      {
        try
        {
          this.logger.LogDebug($"Sending command (Data: {string.Join(" ", data)}, Length: {data.Length})");
          this.port.Write(data, 0, data.Length);
        }
        catch (Exception e)
        {
          this.logger.LogError(e,
            $"There was an error while trying to send command with data: {string.Join(" ", data)}");
          throw;
        }
      });
    }

    public void ClearInputBuffer()
    {
      this.port.DiscardInBuffer();
    }

    public Task<byte[]> ReadInputLine()
    {
      return this.ReadInputUntilValue(NewLine);
    }

    public Task<byte[]> ReadInputUntilValue(byte value, bool includeValue = false)
    {
      return Task.Run(() =>
      {
        var result = new List<byte>();
        var currentByte = (byte) this.port.ReadByte();
        while (currentByte != value)
        {
          result.Add(currentByte);
          currentByte = (byte) this.port.ReadByte();
        }

        if (includeValue)
        {
          result.Add(value);
        }

        return result.ToArray();
      });
    }

    public Task<byte[]> ReadInput(int bytesToRead)
    {
      return Task.Run(() =>
      {
        var result = new byte[bytesToRead];
        while (bytesToRead > 0)
        {
          var buffer = new byte[bytesToRead];
          var bytesRead = this.port.Read(buffer, 0, bytesToRead);
          Buffer.BlockCopy(buffer, 0, result, result.Length - bytesToRead, bytesRead);
          bytesToRead -= bytesRead;
        }

        return result;
      });
    }

    public void Dispose()
    {
      this.port.Close();
      this.port.Dispose();
    }
  }
}