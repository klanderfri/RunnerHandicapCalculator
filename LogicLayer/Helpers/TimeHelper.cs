namespace Logic.Helpers
{
    public static class TimeHelper
    {
        public static string TextFromTime(TimeSpan time)
        {
            var minutesText = time.Minutes.PadZeroLeft(1);

            var seconds = time.Seconds;
            if (time.Milliseconds >= 500)
            {
                //TimeSpan cuts of the decimals on the seconds, so add 1 second if
                //the rounding should be up.
                seconds++;
            }
            var secondsText = seconds.PadZeroLeft(2);

            return $"{minutesText}:{secondsText}";
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
