enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{

    public static LogLevel ParseLogLevel(string logLine)
    {
        int openIndex = logLine.IndexOf("[");
        int closeIndex = logLine.IndexOf("]");

        string logLevelString = logLine.Substring(openIndex + 1 , closeIndex - openIndex - 1);

        switch (logLevelString)
        {
            case "TRC":
                return LogLevel.Trace;
            case "DBG":
                return LogLevel.Debug;
            case "INF":
                return LogLevel.Info;
            case "WRN":
                return LogLevel.Warning;
            case "ERR":
                return LogLevel.Error;
            case "FTL":
                return LogLevel.Fatal;
            default:
                return LogLevel.Unknown;
        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) 
        => $"{(int)logLevel}:{message}";
}
