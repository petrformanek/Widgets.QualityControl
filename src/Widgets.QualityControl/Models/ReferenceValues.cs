namespace Widgets.QualityControl.Models;

public class ReferenceValues
{
    public decimal Temperature { get; set; }
    public decimal Humidity { get; set; }
    public decimal CarbonMonoxideConcetration { get; set; }

    public static ReferenceValues Parse(string value)
    {
        var referenceValues = value.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (referenceValues.Length != 4 || !string.Equals(referenceValues[0], "reference"))
        {
            throw new InvalidOperationException("Invalid reference values");
        }

        return new ReferenceValues
        {
            Temperature = decimal.Parse(referenceValues[1]),
            Humidity = decimal.Parse(referenceValues[2]),
            CarbonMonoxideConcetration = decimal.Parse(referenceValues[3])
        };
    }
}
