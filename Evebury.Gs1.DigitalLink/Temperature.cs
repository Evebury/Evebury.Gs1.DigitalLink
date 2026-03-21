using Evebury.Gs1.DigitalLink.Unit;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Temperature
    /// </summary>
    public class Temperature : BaseUnit<TemperatureUnit>
    {
        /// <summary>
        /// Constructs a Temperature
        /// </summary>
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="unit"></param>
        public Temperature(double value, TemperatureUnit unit) : base(value, unit)
        {
        }

        /// <summary>
        /// Constructs a Temperature
        /// </summary>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="unit"></param>
        internal Temperature(double value, int precision, TemperatureUnit unit) : base(value, precision, unit)
        {
        }

        internal Temperature(Double @double, TemperatureUnit unit) : base(@double, unit) { }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string GetSymbol()
        {
            if (Unit == TemperatureUnit.FAHRENHEIT) return "°F";
            return "°C";
        }
    }


    /// <summary>
    /// Temperature UOM
    /// </summary>
    public enum TemperatureUnit 
    {
        /// <summary>
        /// Celsius
        /// </summary>
        CELSIUS = 0,
        /// <summary>
        /// Fahrenheit
        /// </summary>
        FAHRENHEIT = 1,
    }
}
