using Evebury.Gs1.DigitalLink.Unit;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Length
    /// </summary>
    public class Length : BaseUnit<LengthUnit>
    {
        internal Length(double value, LengthUnit unit) : base(value, unit)
        {
        }

        internal Length(double value, int precision, LengthUnit unit) : base(value, precision, unit)
        {
        }

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
