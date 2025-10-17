namespace Logic.Helpers
{
    public static class TimeHelper
    {
        public static string TextFromTime(int timeInSeconds)
        {
            var time = new TimeSpan(0, 0, timeInSeconds);
            return $"{time.Minutes.PadZeroLeft(1)}:{time.Seconds.PadZeroLeft(2)}";
        }
    }
}
