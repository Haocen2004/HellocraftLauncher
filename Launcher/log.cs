using System;
using System.IO;

namespace Launcher
{
    class log
    {
        private static readonly TextWriter LogWriter;

        static log()
        {
            LogWriter = File.CreateText("hcl.log");
        }

        public static void Log(String log)
        {
            lock (LogWriter)
            {
                LogWriter.WriteLine(log);
            }
        }

        public static void End()
        {
            lock (LogWriter)
            {
                LogWriter.Flush();
                LogWriter.Dispose();
            }
        }
    }
}
