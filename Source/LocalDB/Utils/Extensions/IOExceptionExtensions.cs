using System.IO;
using System.Runtime.InteropServices;

namespace LocalDB.Utils.Extensions
{
    public static class IOExceptionExtensions
    {
        private const int ERROR_SHARING_VIOLATION = 32;
        private const int ERROR_LOCK_VIOLATION = 33;


        public static bool IsLocked(this IOException ex)
        {
            var errorCode = Marshal.GetHRForException(ex) & ((1 << 16) - 1);

            return
                errorCode == ERROR_SHARING_VIOLATION ||
                errorCode == ERROR_LOCK_VIOLATION;
        }

        public static void WaitIfLocked(this IOException ex, int ms)
        {
            if (ex.IsLocked())
            {
                if (ms > 0)
                {
                    System.Threading.Thread.Sleep(ms);
                }
            }
            else
            {
                throw ex;
            }
        }

        // Private Methods

        private static void WaitFor(int ms)
        {
#if HAVE_TASK_DELAY
            System.Threading.Tasks.Task.Delay(ms).Wait();
#else
            System.Threading.Thread.Sleep(ms);
#endif
        }
    }
}
