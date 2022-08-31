using System;

namespace Xpand.Events {
    /// <summary>
    /// Allows to catch exceptions, warning and info message, that happens inside events;
    /// </summary>
    public static class XEventLogger {

        public delegate void ExceptionDelegate(Exception e);
        public delegate void MessageDelegate(object message);

        public static event ExceptionDelegate Exception;
        public static event MessageDelegate Warning;
        public static event MessageDelegate Info;
        
        public static event ExceptionDelegate ImplicitException;
        public static event MessageDelegate ImplicitWarning;
        public static event MessageDelegate ImplicitInfo;

        public static void LogException(Exception exception) {
            ImplicitException?.Invoke(exception);
            if (XpandEventsConfig.LogLevel == LogLevel.Exception) Exception?.Invoke(exception);
        }

        public static void LogWarning(object message) {
            ImplicitWarning?.Invoke(message);
            if (XpandEventsConfig.LogLevel == LogLevel.Warning) Warning?.Invoke(message);
        }

        public static void Log(object message) {
            ImplicitInfo?.Invoke(message);
            if (XpandEventsConfig.LogLevel == LogLevel.Info) Info?.Invoke(message);
        }
    }
}