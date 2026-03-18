using Evebury.Gs1.DigitalLink.Unit;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Weight
    /// </summary>
    public class Weight : BaseUnit<WeightUnit>
    {
        internal Weight(double value, WeightUnit unit):base(value, unit) { }

        internal Weight(double value, int precision, WeightUnit unit): base(value, precision, unit) { }

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

    /// <summary>
    /// Logistic Weight UOM
    /// </summary>
    public enum LogisticWeightUnit 
    {
        /// <summary>
        /// Kilogram
        /// </summary>
        KILOGRAM = 0,
        /// <summary>
        /// Pounds
        /// </summary>
        POUNDS = 1,
    }
}
