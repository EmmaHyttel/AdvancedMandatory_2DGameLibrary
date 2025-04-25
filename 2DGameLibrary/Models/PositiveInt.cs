namespace GameLibrary.Models;

public class PositiveInt
{
    private int _value;
    public PositiveInt(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be positive.");
        _value = value;
    }

    public static PositiveInt operator +(PositiveInt a, PositiveInt b)
    {
        return new PositiveInt(a._value + b._value);
    }

    public static PositiveInt operator *(PositiveInt a, int b)
    {
        return new PositiveInt(a._value * b);
    }

    public static implicit operator int(PositiveInt a) => a._value;

    public static implicit operator PositiveInt(int a) => new PositiveInt(a);

    public override string ToString()
    {
        return _value.ToString();
    }
}
