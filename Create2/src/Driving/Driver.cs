namespace Create2.Driving
{
  using System;
  using System.Threading.Tasks;
  using Create2.OI;
  using Create2.Sensors.OI;
  using Microsoft.Extensions.Logging;

  public class Driver
  {
    private readonly OIDispatcher dispatcher;
    private readonly OISensor oiSensor;
    private readonly ILogger<Driver> logger;

    public const short Straight = 32767;
    public const short TurnInPlaceClockwise = -1;
    public const short TurnInPlaceCounterClockwise = 1;
    public const short MaxSpeed = 500; // mm/s
    public const short MaxRadius = 2000; // mm
    public const short MaxPwm = 255;

    public Driver(OIDispatcher dispatcher, OISensor oiSensor, ILogger<Driver> logger)
    {
      this.oiSensor = oiSensor;
      this.dispatcher = dispatcher;
      this.logger = logger;
    }

    public async Task DriveStraight(short speed)
    {
      await this.Drive(speed, Straight).ConfigureAwait(false);
    }

    public async Task Drive(short speed, short radius)
    {
      if (!await this.oiSensor.CheckIsActive())
      {
        return;
      }

      speed = this.GetProperSpeed(speed);
      radius = this.GetProperRadius(radius);

      var speedBytes = BitConverter.GetBytes(speed);
      var radiusBytes = BitConverter.GetBytes(radius);

      await this.dispatcher.SendCommand(OpCode.Drive,
          speedBytes[1],
          speedBytes[0],
          radiusBytes[1],
          radiusBytes[0])
        .ConfigureAwait(false);
    }

    public async Task DriveDirect(short leftWheelSpeed, short rightWheelSpeed)
    {
      if (!await this.oiSensor.CheckIsActive())
      {
        return;
      }

      leftWheelSpeed = this.GetProperSpeed(leftWheelSpeed);
      rightWheelSpeed = this.GetProperSpeed(rightWheelSpeed);

      var leftWheelSpeedBytes = BitConverter.GetBytes(leftWheelSpeed);
      var rightWheelSpeedBytes = BitConverter.GetBytes(rightWheelSpeed);

      await this.dispatcher.SendCommand(OpCode.DriveDirect,
          rightWheelSpeedBytes[1],
          rightWheelSpeedBytes[0],
          leftWheelSpeedBytes[1],
          leftWheelSpeedBytes[0])
        .ConfigureAwait(false);
    }

    public async Task DrivePwm(short leftWheelPwm, short rightWheelPwm)
    {
      if (!await this.oiSensor.CheckIsActive())
      {
        return;
      }

      leftWheelPwm = this.GetProperPwm(leftWheelPwm);
      rightWheelPwm = this.GetProperPwm(rightWheelPwm);

      var leftWheelPwmBytes = BitConverter.GetBytes(leftWheelPwm);
      var rightWheelPwmBytes = BitConverter.GetBytes(rightWheelPwm);

      await this.dispatcher.SendCommand(OpCode.DrivePwm,
          rightWheelPwmBytes[1],
          rightWheelPwmBytes[0],
          leftWheelPwmBytes[1],
          leftWheelPwmBytes[0])
        .ConfigureAwait(false);
    }

    private short GetProperSpeed(short speed)
    {
      if (Math.Abs(speed) > MaxSpeed)
      {
        var originalValue = speed;
        speed = Math.Max((short) (MaxSpeed * -1), Math.Min(MaxSpeed, speed));
        this.logger.LogWarning(
          $"Speed is out of range. It will be set at closest valid value. (Original Speed: {originalValue}, New Speed: {speed}");
      }

      return speed;
    }

    private short GetProperRadius(short radius)
    {
      if (Math.Abs(radius) > MaxRadius)
      {
        var originalValue = radius;
        radius = Math.Max((short) (MaxRadius * -1), Math.Min(MaxRadius, radius));
        this.logger.LogWarning(
          $"Radius is out of range. It will be set at closest valid value. (Original radius: {originalValue}, New radius: {radius}");
      }

      return radius;
    }

    private short GetProperPwm(short pwm)
    {
      if (Math.Abs(pwm) > MaxPwm)
      {
        var originalValue = pwm;
        pwm = Math.Max((short) (MaxPwm * -1), Math.Min(MaxPwm, pwm));
        this.logger.LogWarning(
          $"PWM is out of range. It will be set at closest valid value. (Original pwm: {originalValue}, New pwm: {pwm}");
      }

      return pwm;
    }
  }
}