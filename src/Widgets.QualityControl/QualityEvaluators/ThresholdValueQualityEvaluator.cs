using Widgets.QualityControl.Models;
using Widgets.QualityControl.Sensors;

namespace Widgets.QualityControl.QualityEvaluators;

public class ThresholdValueQualityEvaluator : SensorQualityEvaluator
{
    private readonly decimal _referenceValue;
    private readonly decimal _threshold;

    public ThresholdValueQualityEvaluator(decimal referenceValue, decimal threshold)
    {
        _referenceValue = referenceValue;
        _threshold = threshold;
    }
    
    public override SensorQuality EvaluateQuality(Sensor sensor)
    {
        return sensor.Measurements.All(m => m.Value <= _referenceValue + _threshold && m.Value >= _referenceValue - _threshold) 
            ? SensorQuality.Keep 
            : SensorQuality.Discard;
    }
}
