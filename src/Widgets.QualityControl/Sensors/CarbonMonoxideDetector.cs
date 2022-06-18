using Widgets.QualityControl.QualityEvaluators;

namespace Widgets.QualityControl.Sensors;

public class CarbonMonoxideDetector : Sensor
{
    public CarbonMonoxideDetector(string name, SensorQualityEvaluator qualityEvaluator) : base(name, qualityEvaluator)
    {
    }
}
