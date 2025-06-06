public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string message, string delimiter)
    {
        int delimIndex = message.IndexOf(delimiter);
        return message.Substring(delimIndex + delimiter.Length);
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string message, string startDelimiter, string endDelimiter)
    {
        int startDelimIndex = message.IndexOf(startDelimiter) + startDelimiter.Length;
        int endDelimIndex = message.IndexOf(endDelimiter, startDelimIndex);
        return message.Substring(startDelimIndex, endDelimIndex - startDelimIndex);
    }

    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string log)
    {
        return log.SubstringAfter("]:").Trim();
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string log)
    {
        return log.SubstringBetween("[", "]");
    }
}