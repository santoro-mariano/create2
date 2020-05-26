namespace Create2.Cleaning
{
    using System;
    using System.Threading.Tasks;
    using Create2.OI;
    using Create2.Sensors.OI;

    public class Cleaner
    {
        private readonly OISensor oiSensor;
        private readonly OIDispatcher dispatcher;

        public Cleaner(OIDispatcher dispatcher, OISensor oiSensor)
        {
            this.dispatcher = dispatcher;
            this.oiSensor = oiSensor;
        }

        /// <summary>
        /// CleanMode: Normal
        /// This command starts the default cleaning mode. This is the same as pressing Roomba’s Clean button, and will pause a cleaning cycle if one is already in progress.
        /// CleanMode: Max
        /// This command starts the Max cleaning mode, which will clean until the battery is dead. This command will pause a cleaning cycle if one is already in progress.
        /// CleanMode: Spot
        /// This command starts the Spot cleaning mode. This is the same as pressing Roomba’s Spot button, and will pause a cleaning cycle if one is already in progress.
        /// 
        /// Available in modes: Passive, Safe, or Full
        /// Changes mode to: Passive
        /// </summary>
        public async Task Clean(CleanMode mode = CleanMode.Normal)
        {
            if (!await this.oiSensor.CheckIsStarted())
            {
                return;
            }

            switch (mode)
            {
                case CleanMode.Normal:
                    await this.dispatcher.SendCommand(OpCode.Clean).ConfigureAwait(false);
                    break;
                case CleanMode.Max:
                    await this.dispatcher.SendCommand(OpCode.Max).ConfigureAwait(false);
                    break;
                case CleanMode.Spot:
                    await this.dispatcher.SendCommand(OpCode.Spot).ConfigureAwait(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }

            //TODO: Set mode to passive
        }

        /// <summary>
        /// This command directs Roomba to drive onto the dock the next time it encounters the docking beams. This is the same as pressing Roomba’s Dock button, and will pause a cleaning cycle if one is already in progress.
        /// Available in modes: Passive, Safe, or Full
        /// Changes mode to: Passive
        /// </summary>
        public async Task SeekDock()
        {
            if (!await this.oiSensor.CheckIsStarted())
            {
                return;
            }

            await this.dispatcher.SendCommand(OpCode.SeekDock).ConfigureAwait(false);
            //TODO: Change mode to passive
        }
    }
}
