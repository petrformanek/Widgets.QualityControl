using Widgets.QualityControl.Models;
using Widgets.QualityControl.Sensors;

namespace Widgets.QualityControl.QualityEvaluators;

public class ThermometerQualityEvaluator : SensorQualityEvaluator
{
    private readonly decimal _referenceValue;

    public ThermometerQualityEvaluator(decimal referenceValue)
    {
        _referenceValue = referenceValue;
    }

    public override SensorQuality EvaluateQuality(Sensor sensor)
    {
        // For a thermometer, it is branded “ultra precise” if the mean of the readings is within 0.5 degrees of the known temperature, and the standard
        // deviation is less than 3.
        // It is branded “very precise” if the mean is within 0.5 degrees of the room, and the standard deviation is under 5.
        // Otherwise, it’s sold as “precise”.

        if (!sensor.Measurements.Any())
        {
            return SensorQuality.Precise;
        }

        var average = sensor.Measurements.Average(m => m.Value);
        var stdDev = Math.Sqrt((double)sensor.Measurements.Average(m => (m.Value - average) * (m.Value - average)));

        if (average <= _referenceValue + 0.5m && average >= _referenceValue - 0.5m)
        {
            if (stdDev < 3)
            {
                return SensorQuality.UltraPrecise;
            }
            if (stdDev < 5)
            {
                return SensorQuality.VeryPrecise;
            }
        }

        return SensorQuality.Precise;
    }
}
