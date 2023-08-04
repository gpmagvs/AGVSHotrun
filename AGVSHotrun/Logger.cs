using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSHotrun
{
    internal class Logger
    {
        public enum LOG_LEVEL
        {
            INFO,
            WARN,
            ERROR,
            FATAL,
        }
        public class LogEventArgs : EventArgs
        {
            public readonly string msg;
            public readonly Exception? exception;
            public readonly LOG_LEVEL level;
            public DateTime time;
            public LogEventArgs(string msg, LOG_LEVEL level, Exception? exception = null)
            {
                this.msg = msg;
                this.level = level;
                this.exception = exception;
            }
        }
        const string LOG_FOLDER = @"D:\HotRunLog";
        static Task LogQueueWorler = null;
        internal static event EventHandler<LogEventArgs> onLogAdded;
        static ConcurrentQueue<LogEventArgs> LogQueue = new ConcurrentQueue<LogEventArgs>();
        public static void Info(string msg)
        {
            LogEventArgs logarg = new LogEventArgs(msg, LOG_LEVEL.INFO);
            Store(logarg);
            onLogAdded?.Invoke("Logger", logarg);
        }
        public static void Warn(string msg)
        {
            LogEventArgs logarg = new LogEventArgs(msg, LOG_LEVEL.WARN);
            Store(logarg);
            onLogAdded?.Invoke("Logger", logarg);
        }
        public static void Error(string msg)
        {
            LogEventArgs logarg = new LogEventArgs(msg, LOG_LEVEL.ERROR);
            Store(logarg);
            onLogAdded?.Invoke("Logger", logarg);
        }
        private static void Store(LogEventArgs logarg)
        {
            logarg.time = DateTime.Now;
            LogQueue.Enqueue(logarg);
            if (LogQueueWorler == null)
            {
                LogQueueWorler = Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(1);
                        if (LogQueue.Count > 0)
                        {
                            if (LogQueue.TryDequeue(out var logDto))
                            {
                                bool success = WriteLogToFile(logDto);
                                if (!success)
                                {
                                    LogQueue.Prepend(logDto); //retry
                                }
                            }
                        }
                    }
                });
            }
        }
        private static bool WriteLogToFile(LogEventArgs logarg)
        {
            try
            {
                //hotrunlog/2023-08-04/warning.log
                string subFolder = Path.Combine(LOG_FOLDER, $@"{DateTime.Now.ToString("yyyy-MM-dd")}");
                Directory.CreateDirectory(subFolder);
                string filename = $"{logarg.level.ToString()}.log";
                string filename_path = Path.Combine(subFolder, filename);
                using (StreamWriter sw = new StreamWriter(filename_path, true))
                {
                    sw.WriteLine($"{logarg.time.ToString("yyyy/MM/dd HH:mm:ss.ff")} |{logarg.level}| {logarg.msg}");
                }
                return true;
            }
            catch (Exception ex)
            {
                onLogAdded?.Invoke("Logger", new LogEventArgs(ex.Message, LOG_LEVEL.FATAL, ex));
                return false;
            }
        }
    }
}
