namespace Create2.Test
{
    using System;
    using System.IO.Ports;
    using System.Linq;
    using System.Threading.Tasks;
    using Create2.Device;
    using Create2.OI;
    using Create2.Sensors.Core;
    using Create2.Sensors.OI;
    using Microsoft.Extensions.Logging;

    class Program
    {
        static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(opts => opts.AddConsole().SetMinimumLevel(LogLevel.Information));
            var portName = SerialPort.GetPortNames().FirstOrDefault();
            using var port = new SerialPort(portName, 115200);
            port.Open();
            using var dispatcher = new OIDispatcher(port, loggerFactory.CreateLogger<OIDispatcher>());
            var sensorReader = new SensorReader(dispatcher, loggerFactory.CreateLogger<SensorReader>());
            var ioSensor = new OISensor(sensorReader);
            var robot = new Robot(dispatcher, ioSensor, loggerFactory.CreateLogger<Robot>());

            await robot.Reset();
            Console.WriteLine($"IO Mode: {robot.CurrentMode}");
            await robot.Start();
            Console.WriteLine($"IO Mode: {robot.CurrentMode}");
            await robot.Activate();
            Console.WriteLine($"IO Mode: {robot.CurrentMode}");
            await robot.Stop();
        }
    }
}
