namespace Create2.Device
{
  using System.Threading.Tasks;
  using Create2.OI;
  using Create2.Sensors.OI;
  using Microsoft.Extensions.Logging;

  public class Robot
  {
    private readonly OIDispatcher dispatcher;
    private readonly ILogger<Robot> logger;
    private readonly OISensor oiSensor;

    public Robot(OIDispatcher dispatcher, OISensor oiSensor, ILogger<Robot> logger)
    {
      this.dispatcher = dispatcher;
      this.oiSensor = oiSensor;
      this.logger = logger;
    }

    public OIMode? CurrentMode { get; private set; }

    public bool IsStarted => this.CurrentMode == OIMode.Passive ||
                             this.IsActive;

    public bool IsActive => this.CurrentMode == OIMode.Safe ||
                            this.CurrentMode == OIMode.Full;

    /// <summary>
    /// This command starts the OI. You must always send the Start command before sending any other commands to the OI.
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Passive. Roomba beeps once to acknowledge it is starting from “off” mode.
    /// </summary>
    public async Task Start()
    {
      await this.dispatcher.SendCommand(OpCode.Start).ConfigureAwait(false);
      this.dispatcher.ClearInputBuffer();
      this.CurrentMode = await this.oiSensor.GetOIMode().ConfigureAwait(false);
    }

    /// <summary>
    /// This command resets the robot, as if you had removed and reinserted the battery.
    /// Available in modes: Always available.
    /// Changes mode to: Off. You will have to send Start command again to re-enter Open Interface mode.
    /// </summary>
    public async Task Reset()
    {
      await this.dispatcher.SendCommand(OpCode.Reset).ConfigureAwait(false);
      await Task.Delay(3000).ConfigureAwait(false);
      this.dispatcher.ClearInputBuffer();
      this.CurrentMode = OIMode.Off;
    }

    /// <summary>
    /// This command stops the OI. All streams will stop and the robot will no longer respond to commands. Use this command when you are finished working with the robot.
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Off. Roomba plays a song to acknowledge it is exiting the OI.
    /// </summary>
    public async Task Stop()
    {
      if (!this.CheckStarted(OpCode.Stop))
      {
        return;
      }

      await this.dispatcher.SendCommand(OpCode.Stop).ConfigureAwait(false);
      this.dispatcher.ClearInputBuffer();
      this.CurrentMode = OIMode.Off;
    }

    /// <summary>
    /// This command sets the baud rate in bits per second (bps) at which OI commands and data are sent according to the baud code sent in the data byte. The default baud rate at power up is 115200 bps, but the starting baud rate can be changed to 19200 by following the method outlined on page 4. Once the baud rate is changed, it persists until Roomba is power cycled by pressing the power button or removing the battery, or when the battery voltage falls below the minimum required for processor operation.
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: No Change
    /// </summary>
    public async Task SetBaudRate(BaudRate baudRate)
    {
      if (!this.CheckStarted(OpCode.Baud))
      {
        return;
      }

      await this.dispatcher.SendCommand(OpCode.Baud, (byte) baudRate).ConfigureAwait(false);
      await Task.Delay(100).ConfigureAwait(false);
    }

    /// <summary>
    /// No Full
    /// This command puts the OI into Safe mode, enabling user control of Roomba. It turns off all LEDs. The OI can be in Passive, Safe, or Full mode to accept this command. If a safety condition occurs (see above) Roomba reverts automatically to Passive mode.
    /// Full
    /// This command gives you complete control over Roomba by putting the OI into Full mode, and turning off the cliff, wheel-drop and internal charger safety features. That is, in Full mode, Roomba executes any command that you send it, even if the internal charger is plugged in, or command triggers a cliff or wheel drop condition.
    /// 
    /// Available in modes: Passive, Safe, or Full
    /// </summary>
    public async Task Activate(bool full = false)
    {
      var commandToSend = full ? OpCode.Full : OpCode.Safe;

      if (!this.CheckStarted(commandToSend))
      {
        return;
      }

      await this.dispatcher.SendCommand(commandToSend).ConfigureAwait(false);
      this.dispatcher.ClearInputBuffer();
      this.CurrentMode = await this.oiSensor.GetOIMode().ConfigureAwait(false);
    }

    /// <summary>
    /// This command powers down Roomba. The OI can be in Passive, Safe, or Full mode to accept this command.
    /// Available in modes: Passive, Safe, or Full
    /// Changes mode to: Passive
    /// </summary>
    public async Task Deactivate()
    {
      if (!this.CheckActive(OpCode.Power))
      {
        return;
      }

      await this.dispatcher.SendCommand(OpCode.Power).ConfigureAwait(false);
      this.dispatcher.ClearInputBuffer();
      this.CurrentMode = await this.oiSensor.GetOIMode().ConfigureAwait(false);
    }

    private bool CheckStarted(OpCode code)
    {
      if (!this.IsStarted)
      {
        this.logger.LogError(
          $"Robot must be started to execute command (OpCode: {code}, Current Mode: {this.CurrentMode})");
      }

      return this.IsStarted;
    }

    private bool CheckActive(OpCode code)
    {
      if (!this.IsActive)
      {
        this.logger.LogError(
          $"Robot must be active to execute command (OpCode: {code}, Current Mode: {this.CurrentMode})");
      }

      return this.IsActive;
    }
  }
}