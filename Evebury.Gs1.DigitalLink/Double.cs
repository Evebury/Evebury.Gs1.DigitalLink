using System.Globalization;
using System.Text;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Double
    /// </summary>
    public class Double
    {
        /// <summary>
        /// Value
        /// </summary>
        public double Value { get; protected set; }

        /// <summary>
        /// Precision number of decimals
        /// </summary>
        public int Precision { get; protected set; }

        /// <summary>
        /// Double to string Format
        /// </summary>
        public string Format { get; protected set; }

        internal Double(double value) 
        {
            int precision = 0;
            string d = value.ToString(CultureInfo.InvariantCulture);
            if (d.Contains('.'))
            {
                string decimals = d.Split('.')[1];
                precision = decimals.Length;
            }
            SetDouble(value, precision);
        }

        internal Double(double value, int precision) 
        {
            SetDouble(value, precision);
        }

        internal Double(Double @double)
        {
            Value = @double.Value;
            Precision = @double.Precision;
            Format = @double.Format;
        }

        internal void SetDouble(double value, int precision)
        {
            Value = value;
            Precision = precision;
            string format = "0";
            if (precision > 0)
            {
                StringBuilder sb = new();
                sb.Append(format);
                sb.Append('.');
                for (int i = 0; i < precision; i++)
                {
                    sb.Append('0');
                }
                Format = sb.ToString();
            }
            else Format = format;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString(Format, CultureInfo.InvariantCulture);
        }
    }
}
