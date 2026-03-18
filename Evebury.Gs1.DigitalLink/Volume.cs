using Evebury.Gs1.DigitalLink.Unit;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Volume
    /// </summary>
    public class Volume : BaseUnit<VolumeUnit>
    {
        internal Volume(double value, VolumeUnit unit) : base(value, unit)
        {
            SetPower();
        }

        internal Volume(double value, int precision, VolumeUnit unit) : base(value, precision, unit)
        {
            SetPower();
        }

        private void SetPower() 
        {
            switch (Unit) 
            {
                case VolumeUnit.METER:
                case VolumeUnit.FEET:
                case VolumeUnit.INCH:
                case VolumeUnit.YARDS: 
                    {
                        Power = 3;
                        break;
                    }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string GetSymbol()
        {
            return Unit switch
            {
                VolumeUnit.FEET => "ft",
                VolumeUnit.INCH => "in",
                VolumeUnit.YARDS => "yd",
                VolumeUnit.QUARTS => "gt",
                VolumeUnit.GALLONS => "gal",
                _ => "l",
            };
        }
    }

    /// <summary>
    /// Volume UOM
    /// </summary>
    public enum VolumeUnit 
    {
        /// <summary>
        /// Litres
        /// </summary>
        LITRES,
        /// <summary>
        /// Cubic Meter
        /// </summary>
        METER,
        /// <summary>
        /// Quarts
        /// </summary>
        QUARTS,
        /// <summary>
        /// Gallons
        /// </summary>
        GALLONS,
        /// <summary>
        /// Cubic Inches
        /// </summary>
        INCH,
        /// <summary>
        /// Cubic Feet
        /// </summary>
        FEET,
        /// <summary>
        /// Cubic Yards
        /// </summary>
        YARDS,

    }
}
