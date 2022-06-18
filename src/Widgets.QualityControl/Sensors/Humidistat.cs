using Widgets.QualityControl.QualityEvaluators;

namespace Widgets.QualityControl.Sensors;

public class Humidistat : Sensor
{
    public Humidistat(string name, SensorQualityEvaluator qualityEvaluator) : base(name, qualityEvaluator)
    {
    }
}
