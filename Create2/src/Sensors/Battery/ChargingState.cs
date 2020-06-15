namespace Create2.Sensors.Battery
{
  public enum ChargingState : byte
  {
    NotCharging,
    ReconditioningCharging,
    FullCharging,
    TrickleCharging,
    Waiting,
    ChargingFaultCondition
  }
}