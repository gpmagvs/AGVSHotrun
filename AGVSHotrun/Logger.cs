using System;
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
            public LogEventArgs(string msg, LOG_LEVEL level, Exception? exception = null)
            {
                this.msg = msg;
                this.level = level;
                this.exception = exception;
            }
        }

        internal static event EventHandler<LogEventArgs> onLogAdded;
        public static void Info(string msg)
        {
            onLogAdded?.Invoke("Logger", new LogEventArgs(msg, LOG_LEVEL.INFO));
        }
        public static void Warn(string msg)
        {
            onLogAdded?.Invoke("Logger", new LogEventArgs(msg, LOG_LEVEL.WARN));
        }
        public static void Error(string msg)
        {
            onLogAdded?.Invoke("Logger", new LogEventArgs(msg, LOG_LEVEL.ERROR));
        }
    }
}
