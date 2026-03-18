namespace Evebury.Gs1.DigitalLink.Unit
{
    /// <summary>
    /// Unit
    /// </summary>
    public interface IBaseUnit
    {
        /// <summary>
        /// String format
        /// </summary>
        string Format { get; }

        /// <summary>
        /// Decimal precision
        /// </summary>
        int Precision { get; }

        /// <summary>
        /// Value
        /// </summary>
        double Value { get; }
    }
}