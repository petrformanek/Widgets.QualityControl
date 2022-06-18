using Widgets.QualityControl;

if (args.Length == 0)
{
    Console.WriteLine("Provide file name as argument");
    return;
}

var result = SensorLogEvaluator.EvaluateLogFromFile(args[0]);

Console.WriteLine(result);
