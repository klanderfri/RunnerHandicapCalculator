namespace Logic.Helpers
{
    public static class TimeHelper
    {
        public static string TextFromTime(int timeInSeconds)
        {
            var time = new TimeSpan(0, 0, timeInSeconds);
            return $"{time.Minutes.PadZeroLeft(1)}:{time.Seconds.PadZeroLeft(2)}";
        }

        public static TimeSpan TimeFromText(string timeInMinutesAndSeconds, char delimiter)
        {
            var delimiterIndex = timeInMinutesAndSeconds.IndexOf(delimiter);
            var minutes = Convert.ToInt32(timeInMinutesAndSeconds[..delimiterIndex]);
            var seconds = Convert.ToInt32(timeInMinutesAndSeconds[(delimiterIndex + 1)..]);
            return new TimeSpan(0, minutes, seconds);
        }
    }
}
