using Widgets.QualityControl.Models;
using Widgets.QualityControl.Sensors;

namespace Widgets.QualityControl;

public class LogParser
{
    public const StringSplitOptions DefaultSplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

    public LogParserResult? ParseLogLines(IEnumerable<string> logLines)
    {
        //var sensors = new Dictionary<string, Sensor>();
        var sensors = new HashSet<Sensor>();

        var logLinesEnumerator = logLines.GetEnumerator();
        if (!logLinesEnumerator.MoveNext())
        {
            return null;
        }
        var referenceValues = ReferenceValues.Parse(logLinesEnumerator.Current);
        var sensorFactory = new SensorFactory(referenceValues);
        
        // no other rows on input
        if (!logLinesEnumerator.MoveNext() || !sensorFactory.TryCreate(logLinesEnumerator.Current, out var sensor))
        {
            return new(referenceValues, sensors);
        }
        sensors.Add(sensor);

        // go through all lines
        while (logLinesEnumerator.MoveNext())
        {
            var dataItems = logLinesEnumerator.Current.Split(" ", DefaultSplitOptions);

            if (DateTimeOffset.TryParse(dataItems[0], out var timestamp) && decimal.TryParse(dataItems[1], out var sensorValue))
            {
                sensor.AddMeasurement(timestamp, sensorValue);
            }
            else if (sensorFactory.TryCreate(logLinesEnumerator.Current, out sensor))
            {
                if (sensors.TryGetValue(sensor, out var foundSensor))
                {
                    sensor = foundSensor;
                }
                else
                {
                    sensors.Add(sensor);
                }
            }
            else
            {
                break;
            }
        }

        return new(referenceValues, sensors);
    }
}
