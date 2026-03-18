using Evebury.Gs1.DigitalLink.Unit;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Temperature
    /// </summary>
    public class Temperature : BaseUnit<TemperatureUnit>
    {
        internal Temperature(double value, TemperatureUnit unit) : base(value, unit)
        {
        }

        internal Temperature(double value, int precision, TemperatureUnit unit) : base(value, precision, unit)
        {
        }

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
