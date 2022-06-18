using Widgets.QualityControl.Models;
using Widgets.QualityControl.Sensors;

namespace Widgets.QualityControl.QualityEvaluators;

public abstract class SensorQualityEvaluator
{
    public abstract SensorQuality EvaluateQuality(Sensor sensor);
}
