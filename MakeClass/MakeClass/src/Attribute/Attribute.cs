using System;

namespace MakeClass.Attribute;

public abstract class Attribute : IEquatable<Attribute>
{
    public double Value { get; }
    public abstract string Key { get; }
    protected Attribute(double value) => Value = value;
    public abstract string DisplayValue();

    public bool Equals(Attribute other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value.Equals(other.Value) && Key == other.Key;
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Attribute)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Key);
    }
}