using System.Drawing;

namespace PubModel
{
    public class CommonHelper
    {
        public void SendEvent(string name, string msg, int level)
        {
            AlarmHelper.Instance.SendEvent(new AlarmHelper.AlarmEventArgs(name, msg, level));
        }

        public static string GetLogLevel(int level)
        {
            return level switch
            {
                0 => "[Information]",
                1 => "[Debug]",
                2 => "[Warning]",
                3 => "[Error]",
                4 => "[Fatal]",
                _ => "[Information]"
            };
        }

        public static Color GetLogLevelColor(int level)
        {
            return level switch
            {
                0 => Color.Green,
                1 => Color.Gray,
                2 => Color.Orange,
                3 => Color.Red,
                4 => Color.DarkRed,
                _ => Color.Black
            };
        }
    }
}