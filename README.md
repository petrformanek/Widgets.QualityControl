# 365-Widgets log parser and quality evaluator
Easily extensible library for various sensor quality evaluation. The library for simplicity targetes to `.NET 6.0`.
With slight changes it can also target `netstandard2.0`.

## Usage
To parse log content and evaluate quality use `Widgets.QualityControl.SensorLogEvaluator.EvaluateLogFile(string logContentsStr)`.

To parse log file and evaluate quality use `Widgets.QualityControl.SensorLogEvaluator.EvaluateLogFromFile(string logFilePath)`.

To have more options in your hands you can use `Widgets.QualityControl.SensorLogEvaluator.LogParser` instance.

## Run demo
To run demo just:
1. `git clone https://github.com/petrformanek/Widgets.QualityControl`
1. `dotnet run --project ./Widgets.QualityControl/src/Widgets.QualityControl.ConsoleEvaluator ./Widgets.QualityControl/src/Widgets.QualityControl.ConsoleEvaluator/SampleLog.txt`

## TODOs
- Increase unit tests coverage
- Handle more edge cases - when log format is not correct
- Improve documentation - comments and readme