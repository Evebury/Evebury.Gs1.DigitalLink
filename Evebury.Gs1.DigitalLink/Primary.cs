namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Primary Segment or Root Segment
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    public struct Primary(PrimaryType type, string value)
    {
        /// <summary>
        /// Type
        /// </summary>
        public PrimaryType Type { get; private set; } = type;

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; private set; } = value;


        /// <summary>
        /// GTIN Primary Segment
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Primary GTIN(string value) => new(PrimaryType.GTIN, value);
    }
}
