namespace Create2.Schedule
{
  using System;

  [Flags]
  public enum WeekDays : byte
  {
    Sunday = 1,
    Monday = 2,
    Tuesday = 4,
    Wednesday = 8,
    Thursday = 16,
    Friday = 32,
    Saturday = 64
  }
}