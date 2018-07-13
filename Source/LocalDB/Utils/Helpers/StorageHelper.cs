using System;
using System.Text.RegularExpressions;

namespace LocalDB.Utils.Helpers
{
    public class StorageHelper
    {
        public static long ParseSize(string size)
        {
            var match = Regex.Match(size.ToLower().Trim(), @"^(\d+)\s*([tgmk])?(b|byte|bytes)?$", RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                return 0;
            }

            var num = Convert.ToInt64(match.Groups[1].Value);

            switch (match.Groups[2].Value.ToLower())
            {
                // TB
                case "t": return num * 1024L * 1024L * 1024L * 1024L;
                // GB
                case "g": return num * 1024L * 1024L * 1024L;
                // MB
                case "m": return num * 1024L * 1024L;
                // KB
                case "k": return num * 1024L;
                // B
                case "": return num;
            }

            return 0;
        }

        public static string FormatSize(long byteCount)
        {
            var suf = new string[] { "B", "KB", "MB", "GB", "TB" };
            if (byteCount == 0)
            {
                return "0" + suf[0];
            }

            var bytes = Math.Abs(byteCount);
            var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            var num = Math.Round(bytes / Math.Pow(1024, place), 1);

            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }
}
