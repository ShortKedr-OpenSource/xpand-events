namespace Xpand.Events {
    public enum LogLevel {
        /// <summary>
        /// Disable all logs
        /// </summary>
        None = 0,
        /// <summary>
        /// Enable info logs
        /// </summary>
        Info = 1,
        /// <summary>
        /// Enable info, warning logs
        /// </summary>
        Warning = 2,
        /// <summary>
        /// Enable info, warning, exception logs
        /// </summary>
        Exception = 3,
    }
}