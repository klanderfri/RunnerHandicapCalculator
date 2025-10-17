using System.Text;

namespace Logic.Helpers
{
    public static class TextHelper
    {
        public static string PadZeroLeft(this int time, int length)
        {
            var text = new StringBuilder();
            var timeText = Convert.ToString(time);
            var loops = length - timeText.Length;
            for (int i = 0; i < loops; i++)
            {
                text.Append('0');
            }
            text.Append(timeText);
            return text.ToString();
        }
    }
}
