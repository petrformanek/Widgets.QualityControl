using Widgets.QualityControl.QualityEvaluators;

namespace Widgets.QualityControl.Sensors;

public class Thermometer : Sensor
{
    public Thermometer(string name, SensorQualityEvaluator qualityEvaluator) : base(name, qualityEvaluator)
    {
    }
}
