using System.Text.Json;
using Widgets.QualityControl.Models;

namespace Widgets.QualityControl;

internal static class OutputFormatter
{
    public static string FormatOutput(LogParserResult? parserResult)
    {
        var results = parserResult?.Sensors.ToDictionary(ks => ks.Name, vs => FormatSensorQuality(vs.EvaluateQuality())) ??
            new Dictionary<string, string>();

        return JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });
    }

    private static string FormatSensorQuality(SensorQuality sensorQuality)
    {
        switch (sensorQuality)
        {
            case SensorQuality.VeryPrecise:
                return "very precise";

            case SensorQuality.UltraPrecise:
                return "ultra precise";

            default:
                return sensorQuality.ToString().ToLowerInvariant();
        }
    }
}
