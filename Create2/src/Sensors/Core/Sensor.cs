namespace Create2.Sensors.Core
{
  public enum Sensor : byte
  {
    All = 6,
    BumpsAndWheelDrops = 7,
    CliffLeft = 9,
    CliffFrontLeft = 10,
    CliffFrontRight = 11,
    CliffRight = 12,
    VirtualWall = 13,
    WheelOverCurrents = 14,
    DirtDetect = 15,
    InfraredCharacterOmni = 17,
    InfraredCharacterLeft = 52,
    InfraredCharacterRight = 53,
    Buttons = 18,
    Distance = 19,
    Angle = 20,
    ChargingState = 21,
    Voltage = 22,
    Current = 23,
    Temperature = 24,
    BatteryCharge = 25,
    BatteryCapacity = 26,
    CliffLeftSignal = 28,
    CliffFrontLeftSignal = 29,
    CliffFrontRightSignal = 30,
    CliffRightSignal = 31,
    ChargingSourcesAvailable = 34,
    OIMode = 35,
    SongNumber = 36,
    SongPlaying = 37,
    NumberOfStreamPackets = 38,
    RequestedVelocity = 39,
    RequestedRadius = 40,
    RequestedRightVelocity = 41,
    RequestedLeftVelocity = 42,
    LeftEncoderCounts = 43,
    RightEncoderCounts = 44,
    LightBumper = 45,
    LightBumpLeftSignal = 46,
    LightBumpFrontLeftSignal = 47,
    LightBumpCenterLeftSignal = 48,
    LightBumpCenterRightSignal = 49,
    LightBumpFrontRightSignal = 50,
    LightBumpRightSignal = 51,
    LeftMotorCurrent = 54,
    RightMotorCurrent = 55,
    MainBrushMotorCurrent = 56,
    SideBrushMotorCurrent = 57,
    Stasis = 58
  }
}