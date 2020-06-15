namespace Create2.Sensors.Music
{
  using System.Threading.Tasks;
  using Create2.Sensors.Core;

  public class SongSensor
  {
    private readonly SensorReader sensorReader;

    public SongSensor(SensorReader sensorReader)
    {
      this.sensorReader = sensorReader;
    }

    public async Task<byte> GetSelectedSong()
    {
      var selectedSong = await this.sensorReader.ReadSensor(Packets.SongNumber)
        .ConfigureAwait(false);
      return selectedSong.RawData[0];
    }

    public async Task<bool> CheckIfSongPlaying()
    {
      var songPlaying = await this.sensorReader.ReadSensor(Packets.SongPlaying)
        .ConfigureAwait(false);
      return songPlaying.ToBoolean();
    }
  }
}