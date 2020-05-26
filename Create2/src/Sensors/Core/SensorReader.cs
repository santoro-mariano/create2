namespace Create2.Sensors.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Create2.Extensions;
    using Create2.OI;
    using Microsoft.Extensions.Logging;

    public class SensorReader
    {
        private readonly OIDispatcher dispatcher;
        private readonly ILogger<SensorReader> logger;

        public const byte StreamStartByte = 19;

        public SensorReader(OIDispatcher dispatcher, ILogger<SensorReader> logger)
        {
            this.dispatcher = dispatcher;
            this.logger = logger;
        }

        public IObservable<SensorData[]> Stream { get; }

        public async Task<SensorData> ReadSensor(SensorPacket packet)
        {
            this.logger.LogInformation($"Reading sensor {packet.Sensor}");
            await this.dispatcher.SendCommand(OpCode.Sensors, (byte)packet.Sensor).ConfigureAwait(false);
            var data = await this.dispatcher.ReadInput(packet.Size).ConfigureAwait(false);
            return new SensorData(packet.Sensor, data);
        }

        public async Task<Dictionary<Sensor, SensorData>> QueryList(params SensorPacket[] packets)
        {
            var commandData = packets.Select(x => (byte) x.Sensor).ToArray().Shift((byte)packets.Length);
            await this.dispatcher.SendCommand(OpCode.QueryList, commandData).ConfigureAwait(false);
            var totalData = await this.dispatcher.ReadInput(packets.Sum(x => x.Size)).ConfigureAwait(false);
            var result = new Dictionary<Sensor, SensorData>(packets.Length);
            var currentIndex = 0;
            foreach (var packet in packets)
            {
                var data = new byte[packet.Size];
                Buffer.BlockCopy(totalData, currentIndex, data, 0, packet.Size);
                currentIndex += packet.Size;
                result.Add(packet.Sensor, new SensorData(packet.Sensor, data));
            }

            return result;
        }

        public void StartStream(params SensorPacket[] packet)
        {
            //TODO: Implement observable stream
        }

        public Task PauseStream()
        {
            return this.dispatcher.SendCommand(OpCode.PauseResumeStream, 0);
        }

        public Task ResumeStream()
        {
            return this.dispatcher.SendCommand(OpCode.PauseResumeStream, 1);
        }

        //private IObservable<byte[]> CreateOutputStream(SerialPort serialPort)
        //{
        //    return Observable.Interval(TimeSpan.FromMilliseconds(1))
        //        .TakeWhile(x => serialPort.IsOpen)
        //        .Where(x => serialPort.BytesToRead > 0)
        //        .Select(x =>
        //        {
        //            var result = new List<byte>();
        //            int bytesRead;
        //            var buffer = new byte[serialPort.ReadBufferSize];
        //            do
        //            {
        //                bytesRead = serialPort.Read(buffer, 0, buffer.Length);
        //                result.AddRange(buffer.Length == bytesRead ? buffer : buffer.SubArray(0, bytesRead));
        //            } while (bytesRead >= buffer.Length);

        //            return result.ToArray();
        //        });
        //}
    }
}