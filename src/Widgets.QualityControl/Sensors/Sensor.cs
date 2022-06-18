using Widgets.QualityControl.Models;
using Widgets.QualityControl.QualityEvaluators;

namespace Widgets.QualityControl.Sensors;

public abstract class Sensor : IEquatable<Sensor>
{    
    private readonly List<SensorMeasurement> _measurements = new();

    public IReadOnlyCollection<SensorMeasurement> Measurements => _measurements;

    public string Name { get; }

    public SensorQualityEvaluator QualityEvaluator { get; }

    public Sensor(string name, SensorQualityEvaluator qualityEvaluator)
    {
        Name = name;
        QualityEvaluator = qualityEvaluator;
    }

    public virtual void AddMeasurement(DateTimeOffset timestamp, decimal value)
    {
        _measurements.Add(new SensorMeasurement(timestamp, value));
    }

    public virtual SensorQuality EvaluateQuality() => QualityEvaluator.EvaluateQuality(this);

    public bool Equals(Sensor? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        
        return Equals((Sensor)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }
}

public record SensorMeasurement(DateTimeOffset Timestamp, decimal Value);
