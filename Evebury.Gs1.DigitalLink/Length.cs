using Evebury.Gs1.DigitalLink.Unit;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Length
    /// </summary>
    public class Length : BaseUnit<LengthUnit>
    {
        /// <summary>
        /// Constructs a Length
        /// </summary>
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="unit"></param>
        public Length(double value, LengthUnit unit) : base(value, unit)
        {
        }

        /// <summary>
        /// Constructs a Length
        /// </summary>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="unit"></param>
        public Length(double value, int precision, LengthUnit unit) : base(value, precision, unit)
        {
        }

        internal Length(Double @double, LengthUnit unit) : base(@double, unit) { }


        /// <summary>
        /// Gets the symbol
        /// </summary>
        /// <returns></returns>
        protected override string GetSymbol()
        {
            return Unit switch
            {
                LengthUnit.FEET => "ft",
                LengthUnit.INCH => "in",
                LengthUnit.YARDS => "yd",
                _ => "m",
            };
        }
    }

    /// <summary>
    /// Length UOM
    /// </summary>
    public enum LengthUnit
    {
        /// <summary>
        /// Meter
        /// </summary>
        METER = 0,
        /// <summary>
        /// Inch
        /// </summary>
        INCH = 1,
        /// <summary>
        /// Feet
        /// </summary>
        FEET = 2,
        /// <summary>
        /// Yards
        /// </summary>
        YARDS = 3,
    }
}
