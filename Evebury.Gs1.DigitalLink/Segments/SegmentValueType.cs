namespace Evebury.Gs1.DigitalLink.Segments
{
    /// <summary>
    /// Value Type
    /// </summary>
    public enum SegmentValueType
    {
        /// <summary>
        /// Raw or unparsed value (equivalent to string type)
        /// </summary>
        Raw = 0,
        /// <summary>
        /// Key (equivalent to string type)
        /// </summary>
        Key = 1,
        /// <summary>
        /// String
        /// </summary>
        String = 2,
        /// <summary>
        /// Date
        /// </summary>
        Date = 3,
        /// <summary>
        /// DateTime
        /// </summary>
        DateTime = 4,
        /// <summary>
        /// Period
        /// </summary>
        Period = 5,
        /// <summary>
        /// Weight
        /// </summary>
        Weight = 6,
        /// <summary>
        /// Length
        /// </summary>
        Length = 7,
        /// <summary>
        /// Volume
        /// </summary>
        Volume = 8,
        /// <summary>
        /// Double
        /// </summary>
        Double = 9,
        /// <summary>
        /// Price
        /// </summary>
        Price = 10,
        /// <summary>
        /// Integer
        /// </summary>
        Integer = 11,
        /// <summary>
        /// Boolean
        /// </summary>
        Boolean = 12,
        /// <summary>
        /// Temperature
        /// </summary>
        Temperature = 13,
        /// <summary>
        /// Country
        /// </summary>
        Country = 14,
        /// <summary>
        /// Country Code List
        /// </summary>
        CountryCode = 15,
        /// <summary>
        /// Gender Code
        /// </summary>
        GenderCode = 16,
        /// <summary>
        /// Roll
        /// </summary>
        Roll = 17,
    }
}
