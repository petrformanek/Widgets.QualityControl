using Widgets.QualityControl.Models;
using Widgets.QualityControl.QualityEvaluators;

namespace Widgets.QualityControl.Sensors;

internal class SensorFactory
{
    private readonly ReferenceValues _referenceValues;

    public SensorFactory(ReferenceValues referenceValues)
    {
        _referenceValues = referenceValues;
    }

    public bool TryCreate(string value, out Sensor sensor)
    {
        ArgumentNullException.ThrowIfNull(value);
        sensor = default!;

        var sensorValues = value.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (sensorValues.Length != 2)
        {
            return false;
        }

        switch (sensorValues[0])
        {
            case "thermometer":
                sensor = new Thermometer(sensorValues[1], new ThermometerQualityEvaluator(_referenceValues.Temperature));
                return true;

            case "humidity":
                sensor = new Humidistat(sensorValues[1], new ThresholdValueQualityEvaluator(_referenceValues.Humidity, 1));
                return true;

            case "monoxide":
                sensor = new CarbonMonoxideDetector(sensorValues[1], new ThresholdValueQualityEvaluator(_referenceValues.CarbonMonoxideConcetration, 3));
                return true;

            default:
                return false;
        }
    }
}
