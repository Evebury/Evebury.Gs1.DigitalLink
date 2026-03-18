using System;

namespace Evebury.Gs1.DigitalLink.Segments
{
    /// <summary>
    /// Strongly Typed Segment Value
    /// </summary>
    public struct SegmentValue
    {
        /// <summary>
        /// Raw object value
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// Type of the value
        /// </summary>
        public ValueType Type { get; private set; }

        internal SegmentValue(object value, ValueType type) 
        {
            Value = value;
            Type = type;
        }

        #region value
        /// <summary>
        /// Gets the date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public readonly bool GetDate(out DateTime date)
        {
            date = DateTime.MinValue;
            if (Value is DateTime value)
            {
                date = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public readonly bool GetDateTime(out DateTime date)
        {
           return GetDate(out date);
        }

        /// <summary>
        /// Gets the period
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public readonly bool GetPeriod(out Period period)
        {
            period = new();
            if (Value is Period value)
            {
                period = value;
                return true;
            }
            return false;
        }


        /// <summary>
        /// Gets the string
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public readonly bool GetString(out string @string)
        {
            @string = null;
            if (Value is string value)
            {
                @string = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the key
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public readonly bool GetKey(out string @string)
        {
            return GetString(out @string);
        }

        #endregion

        /// <summary>
        /// The value as a formatted string value
        /// </summary>
        /// <returns></returns>
        public override readonly string ToString()
        {
            return Value.ToString();
        }
    }
}
