using Evebury.Gs1.DigitalLink.Unit;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Weight
    /// </summary>
    public class Weight : BaseUnit<WeightUnit>
    {
        /// <summary>
        /// Constructs a Weight
        /// </summary>
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="unit"></param>
        public Weight(double value, WeightUnit unit):base(value, unit) { }

        /// <summary>
        /// Constructs a Weight
        /// </summary>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="unit"></param>
        public Weight(double value, int precision, WeightUnit unit): base(value, precision, unit) { }

        internal Weight(Double @double, WeightUnit unit):base(@double, unit) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string GetSymbol()
        {
            string symbol = "kg";
            switch (Unit)
            {
                case WeightUnit.POUNDS:
                    {
                        symbol = "lb";
                        break;
                    }
                case WeightUnit.OUNCE:
                    {
                        symbol = "oz";
                        break;
                    }
                case WeightUnit.TROY_OUNCE:
                    {
                        symbol = "ozt";
                        break;
                    }
            }
            return symbol;
        }
    }

    /// <summary>
    /// Weight UOM
    /// </summary>
    public enum WeightUnit
    {
        /// <summary>
        /// Kilogram
        /// </summary>
        KILOGRAM = 0,
        /// <summary>
        /// Pounds
        /// </summary>
        POUNDS = 1,
        /// <summary>
        /// Ounce
        /// </summary>
        OUNCE = 2,
        /// <summary>
        /// Troy Ounce
        /// </summary>
        TROY_OUNCE = 3,
    }
}
