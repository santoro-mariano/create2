namespace Create2.Motors
{
  using System.Threading.Tasks;
  using Create2.Device;
  using Create2.OI;

  public class MotorsManager
  {
    private readonly Robot robot;
    private readonly OIDispatcher dispatcher;
    private MotorState sideBrushMotorState;
    private MotorState vacuumMotorState;
    private MotorState mainBrushMotorState;


    public MotorsManager(Robot robot, OIDispatcher dispatcher)
    {
      this.robot = robot;
      this.dispatcher = dispatcher;
    }

    public Task ToggleSideBrush()
    {
      return this.SetSideBrush(!this.sideBrushMotorState.Running, this.sideBrushMotorState.DefaultDirection);
    }

    public Task SetSideBrush(bool value, bool counterClockwise = true)
    {
      this.sideBrushMotorState.Running = value;
      this.sideBrushMotorState.DefaultDirection = counterClockwise;
      return this.RefreshMotors();
    }

    public Task ToggleVacuum()
    {
      return this.SetVacuum(!this.vacuumMotorState.Running);
    }

    public Task SetVacuum(bool value)
    {
      this.vacuumMotorState.Running = value;
      return this.RefreshMotors();
    }

    public Task ToggleMainBrush()
    {
      return this.SetMainBrush(!this.mainBrushMotorState.Running, this.mainBrushMotorState.DefaultDirection);
    }

    public Task SetMainBrush(bool value, bool inward = true)
    {
      this.mainBrushMotorState.Running = value;
      this.mainBrushMotorState.DefaultDirection = inward;
      return this.RefreshMotors();
    }

    private Task RefreshMotors()
    {
      if (!this.robot.IsActive)
      {
        return Task.CompletedTask;
      }

      var data = MotorsFlags.None;

      if (this.sideBrushMotorState.Running)
      {
        data |= MotorsFlags.SideBrush;
      }

      if (!this.sideBrushMotorState.DefaultDirection)
      {
        data |= MotorsFlags.SideBrushClockwise;
      }

      if (this.vacuumMotorState.Running)
      {
        data |= MotorsFlags.Vacuum;
      }

      if (this.mainBrushMotorState.Running)
      {
        data |= MotorsFlags.MainBrush;
      }

      if (!this.mainBrushMotorState.DefaultDirection)
      {
        data |= MotorsFlags.MainBrushDirection;
      }

      return this.dispatcher.SendCommand(OpCode.Motors, (byte) data);
    }
  }
}