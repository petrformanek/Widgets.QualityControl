using Widgets.QualityControl.Models;

namespace Widgets.QualityControl.Tests;
public class LogParserTests
{
    [Fact]
    public void EvaluateLogFile_SensorDataSplit_AllDataGrouped()
    {
        // arrange
        string logContent = @"
            reference 70.0 45.0 6
            thermometer temp-1
            2007-04-05T22:00 72.4
            2007-04-05T22:01 76.0
            thermometer temp-2
            2007-04-05T22:01 69.5
            thermometer temp-1
            2007-04-05T22:00 108";

        // act
        var result = new LogParser().ParseLogLines(logContent.Split('\n', LogParser.DefaultSplitOptions).AsEnumerable())!;

        // assert
        result.ReferenceValues.Should().BeEquivalentTo(new ReferenceValues { Temperature = 70.0m, Humidity = 45.0m, CarbonMonoxideConcetration = 6.0m });
                
        result.Sensors.Should().HaveCount(2);
        
        var temp1 = result.Sensors.First();
        temp1.Name.Should().Be("temp-1");
        temp1.Measurements.Should().HaveCount(3);
        temp1.Measurements.Sum(m => m.Value).Should().Be(72.4m + 76.0m + 108m);

        var temp2 = result.Sensors.ElementAt(1);
        temp2.Name.Should().Be("temp-2");
        temp2.Measurements.Should().HaveCount(1);
        temp2.Measurements.Sum(m => m.Value).Should().Be(69.5m);
    }
}
