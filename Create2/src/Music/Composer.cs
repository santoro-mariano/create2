namespace Create2.Music
{
    using System.Linq;
    using System.Threading.Tasks;
    using Create2.Device;
    using Create2.OI;
    using Microsoft.Extensions.Logging;

    public class Composer
    {
        private readonly Robot robot;
        private readonly OIDispatcher dispatcher;
        private readonly ILogger<Composer> logger;

        public const byte MaxSongSize = 16;

        public Composer(Robot robot, OIDispatcher dispatcher, ILogger<Composer> logger)
        {
            this.robot = robot;
            this.dispatcher = dispatcher;
            this.logger = logger;
        }

        public Task SetSong(SongIndex index, params Note[] notes)
        {
            if (!this.robot.IsStarted)
            {
                return Task.CompletedTask;
            }

            this.logger.LogInformation($"Setting Song {index}");

            if (notes.Length > MaxSongSize)
            {
                this.logger.LogWarning($"Notes array size is bigger than MaxSongSize ({MaxSongSize}). It will be trimmed.");
                notes = notes.Take(16).ToArray();
            }

            var data = new byte[notes.Length * 2 + 2];
            data[0] = (byte) index;
            data[1] = (byte) notes.Length;
            for (var i = 0; i < notes.Length; i++)
            {
                var note = notes[i].AsByteArray();
                data[i + 2] = note[0];
                data[i + 3] = note[1];
            }

            return this.dispatcher.SendCommand(OpCode.Song, data);
        }

        public Task PlaySong(SongIndex index)
        {
            if (!this.robot.IsActive)
            {
                return Task.CompletedTask;
            }

            return this.dispatcher.SendCommand(OpCode.Play, (byte) index);
        }
    }
}
