namespace Create2.Schedule
{
  /// <summary>
  /// Times are sent in 24 hour format. Hour (0-23) Minute (0-59)
  /// </summary>
  public struct DayTime
  {
    public WeekDays Day { get; set; }

    public byte Hour { get; set; }

    public byte Minute { get; set; }
  }
}