namespace Create2.OI
{
  public enum OpCode : byte
  {
    Start = 128,
    Reset = 7,
    Stop = 173,
    Baud = 129,
    Safe = 131,
    Full = 132,
    Clean = 135,
    Max = 136,
    Spot = 134,
    SeekDock = 143,
    Power = 133,
    Schedule = 167,
    SetDayTime = 168,
    Drive = 137,
    DriveDirect = 145,
    DrivePwm = 146,
    Motors = 138,
    PwmMotors = 144,
    Leds = 139,
    SchedulingLeds = 162,
    DigitalLedsRaw = 163,
    Buttons = 165,
    DigitalLedsAscii = 164,
    Song = 140,
    Play = 141,
    Sensors = 142,
    QueryList = 149,
    Stream = 148,
    PauseResumeStream = 150
  }
}