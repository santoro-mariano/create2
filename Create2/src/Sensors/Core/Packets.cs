namespace Create2.Sensors.Core
{
    public static class Packets
    {
        public static readonly SensorPacket BumpsAndWheelDrops = new SensorPacket(Sensor.BumpsAndWheelDrops, 1);

        public static readonly SensorPacket CliffLeft = new SensorPacket(Sensor.CliffLeft, 1);

        public static readonly SensorPacket CliffFrontLeft = new SensorPacket(Sensor.CliffFrontLeft, 1);

        public static readonly SensorPacket CliffFrontRight = new SensorPacket(Sensor.CliffFrontRight, 1);
        
        public static readonly SensorPacket CliffRight = new SensorPacket(Sensor.CliffRight, 1);

        public static readonly SensorPacket VirtualWall = new SensorPacket(Sensor.VirtualWall, 1);

        public static readonly SensorPacket WheelOverCurrents = new SensorPacket(Sensor.WheelOverCurrents, 1);

        public static readonly SensorPacket DirtDetect = new SensorPacket(Sensor.DirtDetect, 1);

        public static readonly SensorPacket InfraredCharacterOmni = new SensorPacket(Sensor.InfraredCharacterOmni, 1);

        public static readonly SensorPacket InfraredCharacterLeft = new SensorPacket(Sensor.InfraredCharacterLeft, 1);

        public static readonly SensorPacket InfraredCharacterRight = new SensorPacket(Sensor.InfraredCharacterRight, 1);

        public static readonly SensorPacket Buttons = new SensorPacket(Sensor.Buttons, 1);

        public static readonly SensorPacket Distance = new SensorPacket(Sensor.Distance, 2);

        public static readonly SensorPacket Angle = new SensorPacket(Sensor.Angle, 2);

        public static readonly SensorPacket ChargingState = new SensorPacket(Sensor.ChargingState, 1);

        public static readonly SensorPacket Voltage = new SensorPacket(Sensor.Voltage, 2);

        public static readonly SensorPacket Current = new SensorPacket(Sensor.Current, 2);

        public static readonly SensorPacket Temperature = new SensorPacket(Sensor.Temperature, 1);

        public static readonly SensorPacket BatteryCharge = new SensorPacket(Sensor.BatteryCharge, 2);

        public static readonly SensorPacket BatteryCapacity = new SensorPacket(Sensor.BatteryCapacity, 2);

        public static readonly SensorPacket CliffLeftSignal = new SensorPacket(Sensor.CliffLeftSignal, 2);

        public static readonly SensorPacket CliffFrontLeftSignal = new SensorPacket(Sensor.CliffFrontLeftSignal, 2);

        public static readonly SensorPacket CliffFrontRightSignal = new SensorPacket(Sensor.CliffFrontRightSignal, 2);

        public static readonly SensorPacket CliffRightSignal = new SensorPacket(Sensor.CliffRightSignal, 2);

        public static readonly SensorPacket ChargingSourcesAvailable = new SensorPacket(Sensor.ChargingSourcesAvailable, 1);

        public static readonly SensorPacket OIMode = new SensorPacket(Sensor.OIMode, 1);

        public static readonly SensorPacket SongNumber = new SensorPacket(Sensor.SongNumber, 1);

        public static readonly SensorPacket SongPlaying = new SensorPacket(Sensor.SongPlaying, 1);

        public static readonly SensorPacket NumberOfStreamPackets = new SensorPacket(Sensor.NumberOfStreamPackets, 1);

        public static readonly SensorPacket RequestedVelocity = new SensorPacket(Sensor.RequestedVelocity, 2);

        public static readonly SensorPacket RequestedRadius = new SensorPacket(Sensor.RequestedRadius, 2);

        public static readonly SensorPacket RequestedRightVelocity = new SensorPacket(Sensor.RequestedRightVelocity, 2);

        public static readonly SensorPacket RequestedLeftVelocity = new SensorPacket(Sensor.RequestedLeftVelocity, 2);

        public static readonly SensorPacket LeftEncoderCounts = new SensorPacket(Sensor.LeftEncoderCounts, 2);

        public static readonly SensorPacket RightEncoderCounts = new SensorPacket(Sensor.RightEncoderCounts, 2);

        public static readonly SensorPacket LightBumper = new SensorPacket(Sensor.LightBumper, 1);

        public static readonly SensorPacket LightBumpLeftSignal = new SensorPacket(Sensor.LightBumpLeftSignal, 2);

        public static readonly SensorPacket LightBumpFrontLeftSignal = new SensorPacket(Sensor.LightBumpFrontLeftSignal, 2);

        public static readonly SensorPacket LightBumpCenterLeftSignal = new SensorPacket(Sensor.LightBumpCenterLeftSignal, 2);

        public static readonly SensorPacket LightBumpCenterRightSignal = new SensorPacket(Sensor.LightBumpCenterRightSignal, 2);

        public static readonly SensorPacket LightBumpFrontRightSignal = new SensorPacket(Sensor.LightBumpFrontRightSignal, 2);

        public static readonly SensorPacket LightBumpRightSignal = new SensorPacket(Sensor.LightBumpRightSignal, 2);

        public static readonly SensorPacket LeftMotorCurrent = new SensorPacket(Sensor.LeftMotorCurrent, 2);

        public static readonly SensorPacket RightMotorCurrent = new SensorPacket(Sensor.RightMotorCurrent, 2);

        public static readonly SensorPacket MainBrushMotorCurrent = new SensorPacket(Sensor.MainBrushMotorCurrent, 2);

        public static readonly SensorPacket SideBrushMotorCurrent = new SensorPacket(Sensor.SideBrushMotorCurrent, 2);

        public static readonly SensorPacket Stasis = new SensorPacket(Sensor.Stasis, 1);
    }
}
