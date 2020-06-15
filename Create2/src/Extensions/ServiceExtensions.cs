namespace Create2.Extensions
{
  using System;
  using Create2.Cleaning;
  using Create2.Device;
  using Create2.Driving;
  using Create2.Motors;
  using Create2.Music;
  using Create2.OI;
  using Create2.Schedule;
  using Create2.Sensors.Battery;
  using Create2.Sensors.Buttons;
  using Create2.Sensors.Cleaner;
  using Create2.Sensors.Core;
  using Create2.Sensors.Driver;
  using Create2.Sensors.Environment;
  using Create2.Sensors.Motor;
  using Create2.Sensors.Music;
  using Create2.Sensors.OI;
  using Create2.Settings;
  using Create2.UI;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;

  public static class ServiceExtensions
  {
    public static IServiceCollection AddCreate2(this IServiceCollection services, Action<OISettings> configureOptions)
    {
      return services
        .AddOI(configureOptions)
        .AddCleaner()
        .AddDevice()
        .AddDriver()
        .AddMotors()
        .AddMusic()
        .AddSchedule()
        .AddUI();
    }

    public static IServiceCollection AddOI(this IServiceCollection services, IConfiguration configurationSection)
    {
      return services
        .Configure<OISettings>(configurationSection)
        .AddOI();
    }

    public static IServiceCollection AddOI(this IServiceCollection services, Action<OISettings> configureOptions)
    {
      return services
        .Configure(configureOptions)
        .AddOI();
    }

    public static IServiceCollection AddCleaner(this IServiceCollection services)
    {
      return services
        .AddSingleton<Cleaner>()
        .AddSingleton<CleanerSensor>();
    }

    public static IServiceCollection AddDevice(this IServiceCollection services)
    {
      return services
          .AddSingleton<Robot>()
          .AddSingleton<BatterySensor>()
        ;
    }

    public static IServiceCollection AddDriver(this IServiceCollection services)
    {
      return services
        .AddSingleton<Driver>()
        .AddSingleton<DriverSensor>()
        .AddSingleton<EnvironmentSensor>();
    }

    public static IServiceCollection AddMotors(this IServiceCollection services)
    {
      return services
        .AddSingleton<MotorsManager>()
        .AddSingleton<MotorSensor>();
    }

    public static IServiceCollection AddMusic(this IServiceCollection services)
    {
      return services
        .AddSingleton<Composer>()
        .AddSingleton<SongSensor>();
    }

    public static IServiceCollection AddSchedule(this IServiceCollection services)
    {
      return services
        .AddSingleton<Scheduler>();
    }

    public static IServiceCollection AddUI(this IServiceCollection services)
    {
      return services
        .AddSingleton<ButtonsManager>()
        .AddSingleton<LedsManager>()
        .AddSingleton<ButtonsSensor>();
    }

    private static IServiceCollection AddOI(this IServiceCollection services)
    {
      return services
        .AddSingleton<OIDispatcher>()
        .AddSingleton<SensorReader>()
        .AddSingleton<OISensor>();
    }
  }
}