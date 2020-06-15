namespace Create2.Schedule
{
  using System;

  public static class WeekDaysExtensions
  {
    public static byte GetByte(this WeekDays[] weekDays)
    {
      if (weekDays == null)
      {
        throw new ArgumentNullException(nameof(weekDays));
      }

      if (weekDays.Length == 0)
      {
        return 0;
      }

      var result = weekDays[0];

      for (var i = 1; i < weekDays.Length; i++)
      {
        result |= weekDays[i];
      }

      return (byte) result;
    }
  }
}