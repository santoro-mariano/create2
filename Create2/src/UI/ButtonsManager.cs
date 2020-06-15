namespace Create2.UI
{
  using System.Threading.Tasks;
  using Create2.Device;
  using Create2.OI;

  public class ButtonsManager
  {
    private readonly Robot robot;
    private readonly OIDispatcher dispatcher;

    public ButtonsManager(Robot robot, OIDispatcher dispatcher)
    {
      this.robot = robot;
      this.dispatcher = dispatcher;
    }

    public Task PushClean()
    {
      return this.PushButtons(Buttons.Clean);
    }

    public Task PushSpot()
    {
      return this.PushButtons(Buttons.Spot);
    }

    public Task PushDock()
    {
      return this.PushButtons(Buttons.Dock);
    }

    public Task PushMinute()
    {
      return this.PushButtons(Buttons.Minute);
    }

    public Task PushHour()
    {
      return this.PushButtons(Buttons.Hour);
    }

    public Task PushDay()
    {
      return this.PushButtons(Buttons.Day);
    }

    public Task PushSchedule()
    {
      return this.PushButtons(Buttons.Schedule);
    }

    public Task PushClock()
    {
      return this.PushButtons(Buttons.Clock);
    }

    /// <summary>
    /// This command lets you push Roomba’s buttons. The buttons will automatically release after 1/6th of a second.
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: No Change
    /// </summary>
    public Task PushButtons(Buttons buttons)
    {
      if (!this.robot.IsStarted)
      {
        return Task.CompletedTask;
      }

      return this.dispatcher.SendCommand(OpCode.Buttons, (byte) buttons);
    }
  }
}