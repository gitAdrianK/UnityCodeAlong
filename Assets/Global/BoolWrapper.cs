public class BoolWrapper
{
    public bool Value { get; set; }

    public BoolWrapper(bool value)
    {
        this.Value = value;
    }

    public static implicit operator bool(BoolWrapper obj)
    {
        return obj.Value;
    }

    public static implicit operator BoolWrapper(bool obj)
    {
        return new BoolWrapper(obj);
    }
}
