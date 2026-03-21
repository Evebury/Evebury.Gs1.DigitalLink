using Evebury.Gs1.DigitalLink.Unit;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Volume
    /// </summary>
    public class Volume : BaseUnit<VolumeUnit>
    {
        /// <summary>
        /// Constructs a Volume
        /// </summary>
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="unit"></param>
        public Volume(double value, VolumeUnit unit) : base(value, unit)
        {
            SetPower();
        }

        /// <summary>
        /// Constructs a Volume
        /// </summary>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="unit"></param>
        public Volume(double value, int precision, VolumeUnit unit) : base(value, precision, unit)
        {
            SetPower();
        }

        internal Volume(Double @double, VolumeUnit unit) : base(@double, unit) 
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
