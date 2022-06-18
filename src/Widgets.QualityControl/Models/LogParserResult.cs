using Widgets.QualityControl.Sensors;

namespace Widgets.QualityControl.Models;
public record LogParserResult(ReferenceValues ReferenceValues, IReadOnlyCollection<Sensor> Sensors);
