namespace Create2.Schedule
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Create2.Device;
  using Create2.Extensions;
  using Create2.OI;

  public class Scheduler
  {
    private readonly Robot robot;
    private readonly OIDispatcher dispatcher;

    public Scheduler(Robot robot, OIDispatcher dispatcher)
    {
      this.robot = robot;
      this.dispatcher = dispatcher;
    }

    /// <summary>
    /// This command sets Roomba’s clock.
    /// Available in modes: Passive, Safe, or Full.
    /// If Roomba’s schedule or clock button is pressed, this command will be ignored.
    /// Changes mode to: No change
    /// </summary>
    public Task SetClock(DayTime dayTime)
    {
      if (!this.robot.IsStarted)
      {
        return Task.CompletedTask;
      }

      return this.dispatcher.SendCommand(OpCode.SetDayTime, (byte) dayTime.Day, dayTime.Hour, dayTime.Minute);
    }

    /// <summary>
    /// This command sends Roomba a new schedule. To disable scheduled cleaning, send all 0s.
    /// Available in modes: Passive, Safe, or Full.
    /// If Roomba’s schedule or clock button is pressed, this command will be ignored.
    /// Changes mode to: No change
    /// </summary>
    public Task SetSchedule(params DayTime[] schedules)
    {
      var daysByte = schedules.Select(x => x.Day).ToArray().GetByte();
      var times = this.GetTimes(schedules);
      return this.dispatcher.SendCommand(OpCode.Schedule, times.Shift(daysByte));
    }

    public Task ClearSchedule()
    {
      if (!this.robot.IsStarted)
      {
        return Task.CompletedTask;
      }

      const byte data = 0;
      return this.dispatcher.SendCommand(OpCode.Schedule, data.ToArray(15));
    }

    public byte[] GetTimes(IEnumerable<DayTime> dayTimes)
    {
      var result = ((byte) 0).ToArray(14);
      foreach (var dayTime in dayTimes)
      {
        var currentIndex = (int) dayTime.Day * 2;
        result[currentIndex] = dayTime.Hour;
        result[currentIndex + 1] = dayTime.Minute;
      }

      return result;
    }
  }
}