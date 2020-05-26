namespace Create2.Music
{
    public class Note
    {
        public MidiNote MidiNote { get; set; }

        public int DurationInMs { get; set; }

        public byte[] AsByteArray()
        {
            return new[] {(byte) this.MidiNote, this.GetDurationByte()};
        }

        private byte GetDurationByte()
        {
            return (byte)(this.DurationInMs / 1000 * 64);
        }
    }
}
