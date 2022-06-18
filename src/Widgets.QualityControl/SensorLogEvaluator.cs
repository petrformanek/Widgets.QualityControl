namespace Widgets.QualityControl;

public static class SensorLogEvaluator
{
    public static LogParser LogParser => new LogParser();

    public static string EvaluateLogFile(string logContentsStr)
    {
        var logLines = logContentsStr.Split('\n', LogParser.DefaultSplitOptions);

        var parserResult = LogParser.ParseLogLines(logLines);

        return OutputFormatter.FormatOutput(parserResult);
    }

    public static string EvaluateLogFromFile(string logFile)
    {
        var logLines = File.ReadLines(logFile);

        var parserResult = LogParser.ParseLogLines(logLines);

        return OutputFormatter.FormatOutput(parserResult);
    }
}
