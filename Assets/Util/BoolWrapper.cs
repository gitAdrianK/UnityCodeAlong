/// <summary>
/// Bool wrapper.
/// </summary>
public class BoolWrapper
{
    public bool Value { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BoolWrapper"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public BoolWrapper(bool value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Sets value.
    /// </summary>
    /// <param name="boolean">The boolean.</param>
    public void SetValue(bool boolean)
    {
        Value = boolean;
    }

    /// <summary>
    /// Sets the internal value to true.
    /// </summary>
    public void SetTrue()
    {
        SetValue(true);
    }

    /// <summary>
    /// Sets the internal value to true.
    /// </summary>
    public void SetFalse()
    {
        SetValue(false);
    }

    public static implicit operator bool(BoolWrapper obj)
    {
        return obj.Value;
    }
}
