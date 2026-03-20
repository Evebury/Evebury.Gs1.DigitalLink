using System;
using System.Collections.Generic;

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
        public SegmentValueType Type { get; private set; }

        internal SegmentValue(object value, SegmentValueType type) 
        {
            Value = value;
            Type = type;
        }

        #region value
        /// <summary>
        /// Type == ValueType.Date
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
        /// Type == ValueType.DateTime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public readonly bool GetDateTime(out DateTime date)
        {
           return GetDate(out date);
        }

        /// <summary>
        /// Type == ValueType.Period
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
        /// Type == ValueType.String
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
        /// Type == ValueType.Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public readonly bool GetKey(out string key)
        {
           return GetString(out key);
        }

        /// <summary>
        /// Type == ValueType.Raw
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public readonly bool GetRaw(out string raw)
        {
            return GetString(out raw);
        }

        /// <summary>
        /// Type == ValueType.Weight
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public readonly bool GetWeight(out Weight weight)
        {
            weight = null;
            if (Value is Weight value)
            {
                weight = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Type == ValueType.Length
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public readonly bool GetLength(out Length length)
        {
            length = null;
            if (Value is Length value)
            {
                length = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Type == ValueType.Volume
        /// </summary>
        /// <param name="volume"></param>
        /// <returns></returns>
        public readonly bool GetVolume(out Volume volume)
        {
            volume = null;
            if (Value is Volume value)
            {
                volume = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Type == ValueType.Double
        /// </summary>
        /// <param name="double"></param>
        /// <returns></returns>
        public readonly bool GetDouble(out Double @double)
        {
            @double = null;
            if (Value is Double value)
            {
                @double = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Type == ValueType.Price
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public readonly bool GetPrice(out Price price)
        {
            price = null;
            if (Value is Price value)
            {
                price = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Type == ValueType.Temperature
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        public readonly bool GetTemperature(out Temperature temperature)
        {
            temperature = null;
            if (Value is Temperature value)
            {
                temperature = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Type == ValueType.Integer
        /// </summary>
        /// <param name="integer"></param>
        /// <returns></returns>
        public readonly bool GetInteger(out int integer)
        {
            integer = 0;
            if (Value is int value)
            {
                integer = value;
                return true;
            }
            return false;
        }


        /// <summary>
        /// Type == ValueType.Boolean
        /// </summary>
        /// <param name="boolean"></param>
        /// <returns></returns>
        public readonly bool GetBoolean(out bool boolean)
        {
            boolean = false;
            if (Value is bool value)
            {
                boolean = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Type == ValueType.Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public readonly bool GetCountry(out Country country)
        {
            country = null;
            if (Value is Country value)
            {
                country = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Type == ValueType.CountryCode
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        public readonly bool GetCountryCodes(out List<CountryCode> countries)
        {
            countries = [];
            if (Value is List<CountryCode> value)
            {
                countries = value;
                return true;
            }
            return false;
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
