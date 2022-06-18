using Widgets.QualityControl;

if (args.Length == 0)
{
    Console.WriteLine("Provide file name as argument");
    return;
}

Console.WriteLine($"Evaluating file '{args[0]}'{Environment.NewLine}.");

var result = SensorLogEvaluator.EvaluateLogFromFile(args[0]);

Console.WriteLine("Result:");
Console.WriteLine(result);
