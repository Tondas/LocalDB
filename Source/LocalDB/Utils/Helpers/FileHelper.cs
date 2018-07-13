using LocalDB.Utils.Extensions;
using System;
using System.IO;

namespace LocalDB.Utils.Helpers
{
    public static class FileHelper
    {
        public static string GetTempFileName(string fileName)
        {
            var suffix = "-temp";
            var count = 0;
            var temp = Path.Combine(
                Path.GetDirectoryName(fileName),
                Path.GetFileNameWithoutExtension(fileName) + suffix +
                Path.GetExtension(fileName));

            while (File.Exists(temp))
            {
                temp = Path.Combine(Path.GetDirectoryName(fileName),
                    Path.GetFileNameWithoutExtension(fileName) + suffix +
                    "-" + (++count) +
                    Path.GetExtension(fileName));
            }

            return temp;
        }

        public static bool TryExec(Action action, TimeSpan timeout)
        {
            var timer = DateTime.UtcNow.Add(timeout);

            do
            {
                try
                {
                    action();
                    return true;
                }
                catch (IOException ex)
                {
                    ex.WaitIfLocked(25);
                }
            }
            while (DateTime.UtcNow < timer);

            return false;
        }

        public static bool TryDelete(string filename)
        {
            try
            {
                File.Delete(filename);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}
