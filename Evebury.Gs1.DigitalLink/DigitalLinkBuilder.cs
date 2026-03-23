using Evebury.Gs1.DigitalLink.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Digital Link Builder use to generate validated digital links
    /// </summary>
    public partial class DigitalLinkBuilder
    {
        private string _uri = "https://id.gs1.org";
        private readonly List<Segment> _segments = [];
        private readonly List<ValidationError> _errors = [];
        private KeySegment _primary;


        /// <summary>
        /// Constructs the builder
        /// </summary>
        public DigitalLinkBuilder()
        {
        }


        /// <summary>
        /// Sets the primary key segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void SetPrimaryKey(PrimaryKeyType type, string value)
        {
            _primary = new(type, value);
        }


        /// <summary>
        /// Optional set to a custom domain
        /// </summary>
        /// <param name="uri"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetCustomDomainUri(string uri)
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));
            uri = uri.ToLowerInvariant();
            _uri = uri;
        }

        /// <summary>
        /// Adds a TradeItem data object to the builder. This will add all tradeItem fields if not null to the link
        /// </summary>
        /// <param name="tradeItem"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetTradeItem(TradeItem tradeItem) 
        {
            ArgumentNullException.ThrowIfNull(tradeItem);
            SetPrimaryKey(PrimaryKeyType.GTIN, tradeItem.GTIN);
            tradeItem.AddFields(this);
        }

        #region key

        /// <summary>
        /// Add Key Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddKey(KeyType type, string value)
        {
            KeySegment segment = new(type, value);
            AddSegment(segment);
        }

        #endregion

        #region date

        /// <summary>
        /// Add Date Segment 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddDate(DateType type, DateTime value)
        {
            DateSegment segment = new(type, value);
            AddSegment(segment);
        }

        /// <summary>
        /// Add DateTime Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddDateTime(DateTimeType type, DateTime value)
        {
            DateSegment segment = new(type, value);
            AddSegment(segment);
        }

        /// <summary>
        /// Add Period Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="period"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddPeriod(PeriodType type, Period period)
        {
            ArgumentNullException.ThrowIfNull(period);
            DateSegment segment = new(type, period);
            AddSegment(segment);
        }
        #endregion

        #region unit
        /// <summary>
        /// Add NetWeight Segment
        /// </summary>
        /// <param name="weight"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddNetWeight(Weight weight)
        {
            ArgumentNullException.ThrowIfNull(weight);
            WeightSegment segment = new(weight, SegmentType.NET_WEIGHT);
            AddSegment(segment, false, true);
        }


        /// <summary>
        /// Add Logistic GrossWeight Segment (KILOGRAM or POUNDS)
        /// </summary>
        /// <param name="weight"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException">Unit must be POUNDS or KILOGRAM</exception>
        public void AddLogisticGrossWeight(Weight weight)
        {
            ArgumentNullException.ThrowIfNull(weight);
            if (weight.Unit != WeightUnit.KILOGRAM && weight.Unit != WeightUnit.POUNDS) throw new ArgumentOutOfRangeException(nameof(weight),"Unit must be POUNDS or KILOGRAM");

            WeightSegment segment = new(weight, SegmentType.LOGISTIC_GROSS_WEIGHT);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add Kilograms per square Meter Segment
        /// </summary>
        /// <param name="value">raw decimals are inferred</param>
        public void AddKilogramPerSquareMeter(double value)
        {
            WeightSegment segment = new(new Weight(value, WeightUnit.KILOGRAM), SegmentType.KG_PER_SQUARE_METRE);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add Kilograms per square Meter Segment
        /// </summary>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        public void AddKilogramPerSquareMeter(double value, int precision)
        {
            WeightSegment segment = new(new Weight(value, precision, WeightUnit.KILOGRAM), SegmentType.KG_PER_SQUARE_METRE);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add Length Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddLength(LengthType type, Length length)
        {
            ArgumentNullException.ThrowIfNull(length);
            AddLength(length, type);
        }

        private void AddLength(Length length, LengthType type)
        {
            switch (type)
            {
                case LengthType.LENGTH:
                    {
                        AddLength(length, SegmentType.LENGTH);
                        break;
                    }
                case LengthType.WIDTH:
                    {
                        AddLength(length, SegmentType.WIDTH);
                        break;
                    }
                case LengthType.HEIGHT:
                    {
                        AddLength(length, SegmentType.HEIGHT);
                        break;
                    }
                case LengthType.AREA:
                    {
                        AddLength(length, SegmentType.AREA);
                        break;
                    }
            }
        }

        /// <summary>
        /// Add Logistic Length Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddLogisticLength(LengthType type, Length length)
        {
            ArgumentNullException.ThrowIfNull(length);
            AddLogisticLength(length, type);
        }

        private void AddLogisticLength(Length length, LengthType type)
        {
            switch (type)
            {
                case LengthType.LENGTH:
                    {
                        AddLength(length, SegmentType.LOGISTIC_LENGTH);
                        break;
                    }
                case LengthType.WIDTH:
                    {
                        AddLength(length, SegmentType.LOGISTIC_WIDTH);
                        break;
                    }
                case LengthType.HEIGHT:
                    {
                        AddLength(length, SegmentType.LOGISTIC_HEIGHT);
                        break;
                    }
                case LengthType.AREA:
                    {
                        AddLength(length, SegmentType.LOGISTIC_AREA);
                        break;
                    }
            }
        }

        private void AddLength(Length length, SegmentType type)
        {
            LengthSegment segment = new(length, type);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add NetVolume Segment
        /// </summary>
        /// <param name="volume"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddNetVolume(Volume volume)
        {
            ArgumentNullException.ThrowIfNull(volume);
            VolumeSegment segment = new(volume, SegmentType.NET_VOLUME);
            AddSegment(segment, false, true);
        }


        /// <summary>
        /// Add Logistic NetVolume Segment
        /// </summary>
        /// <param name="volume"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddLogisticVolume(Volume volume)
        {
            ArgumentNullException.ThrowIfNull(volume);
            VolumeSegment segment = new(volume, SegmentType.LOGISTIC_VOLUME);
            AddSegment(segment, false, true);
        }


        /// <summary>
        /// Add Price Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="price"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddPrice(PriceType type, Price price)
        {
            ArgumentNullException.ThrowIfNull(price);
            PriceSegment segment = new(price, (SegmentType)(int)type);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add MinimumTemperature
        /// </summary>
        /// <param name="temperature">in 100 of degrees. 23.3 will be multiplied by 100 for raw</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddMinimumTemperature(Temperature temperature)
        {
            ArgumentNullException.ThrowIfNull(temperature);
            TemperatureSegment segment = new(new Temperature(temperature.Value * 100, 0, temperature.Unit), SegmentType.MINIMUM_TEMPERATURE);
            AddSegment(segment);
        }

        /// <summary>
        /// Add MaximumTemperature
        /// </summary>
        /// <param name="temperature">in 100 of degrees. 23.3 will be multiplied by 100 for raw</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddMaximumTemperature(Temperature temperature)
        {
            ArgumentNullException.ThrowIfNull(temperature);
            TemperatureSegment segment = new(new Temperature(temperature.Value * 100, 0, temperature.Unit), SegmentType.MAXIMUM_TEMPERATURE);
            AddSegment(segment);
        }


        #endregion

        #region types

        /// <summary>
        /// Add String Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddString(StringType type, string value)
        {
            if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            StringSegment segment = new(type, value);
            AddSegment(segment, segment.Descriptor.MaxElements > 0);
        }

        /// <summary>
        /// Add Integer Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddInteger(IntegerType type, int value)
        {
            IntegerSegment segment = new(type, value);
            AddSegment(segment, segment.Descriptor.MaxElements > 0);
        }

        /// <summary>
        /// Add Double Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value">raw decimals are inferred</param>
        public void AddDouble(DoubleType type, double value)
        {
            DoubleSegment segment = new(type, new Double(value));
            AddSegment(segment, segment.Descriptor.MaxElements > 0);
        }


        /// <summary>
        /// Add Double Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        public void AddDouble(DoubleType type, double value, int precision)
        {
            DoubleSegment segment = new(type, new Double(value, precision));
            AddSegment(segment, segment.Descriptor.MaxElements > 0);
        }

        /// <summary>
        /// Add Boolean Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddBoolean(BooleanType type, bool value)
        {
            BooleanSegment segment = new(type, value);
            AddSegment(segment, segment.Descriptor.MaxElements > 0);
        }

        #endregion

        #region misc

        /// <summary>
        /// Add Gender Segment
        /// </summary>
        /// <param name="genderCode"></param>
        public void AddGender(GenderCode genderCode)
        {
            GenderSegment segment = new(genderCode, SegmentType.BIOLOGICAL_SEX);
            AddSegment(segment);
        }

        /// <summary>
        /// Add Country Code Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="countryCode"></param>
        public void AddCountry(CountryCodeType type, CountryCode countryCode)
        {
            AddCountry(type, [countryCode]);
        }

        /// <summary>
        /// Add Country Code Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="countryCodes">Nb! SHIP_TO_COUNTRY and COUNTRY_OF_ORIGIN can only be added once</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddCountry(CountryCodeType type, List<CountryCode> countryCodes)
        {
            ArgumentNullException.ThrowIfNull(countryCodes);
            if (countryCodes.Count == 0) throw new ArgumentNullException(nameof(countryCodes), "Count = 0");
            CountrySegment segment = new(type, countryCodes);
            AddSegment(segment);
        }


        /// <summary>
        /// Add Country With Value Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="countryCode"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddCountryWithValue(CountryType type, CountryCode countryCode, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            CountrySegment segment = new(type, new Country(countryCode, value));
            AddSegment(segment, segment.Descriptor.MaxElements > 0);
        }

        /// <summary>
        /// Add Roll Product
        /// </summary>
        /// <param name="roll"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddRoll(Roll roll)
        {
            ArgumentNullException.ThrowIfNull(roll);
            RollSegment segment = new(SegmentType.ROLL_PRODUCT, roll);
            AddSegment(segment);
        }


        /// <summary>
        /// Add Raw (use only if all fails)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="code"></param>
        /// <param name="raw"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddRaw(SegmentType type, string code, string raw)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
            if (string.IsNullOrWhiteSpace(raw)) throw new ArgumentNullException(nameof(raw));
            RawSegment segment = new(type, code, raw);
            AddSegment(segment, segment.Descriptor.MaxElements > 0);
        }
        #endregion

        internal void ParseSegments(List<DigitalLinkSegment> segments) 
        {
            foreach (DigitalLinkSegment link in segments)
            {
                if (Segment.TryParse(link, out Segment segment))
                {
                    switch (link.Type) 
                    {
                        case SegmentType.NET_WEIGHT:
                        case SegmentType.WIDTH:
                        case SegmentType.HEIGHT:
                        case SegmentType.LENGTH:
                        case SegmentType.AREA:
                        case SegmentType.NET_VOLUME:
                        case SegmentType.LOGISTIC_GROSS_WEIGHT:
                        case SegmentType.LOGISTIC_WIDTH:
                        case SegmentType.LOGISTIC_HEIGHT:
                        case SegmentType.LOGISTIC_LENGTH:
                        case SegmentType.LOGISTIC_AREA:
                        case SegmentType.LOGISTIC_VOLUME: 
                            {
                                AddSegment(segment, false, true);
                                break;
                            }
                        default: 
                            {
                                AddSegment(segment, segment.Descriptor.MaxElements > 0);
                                break;
                            }
                    }
                }
                else 
                {
                    _errors.Add(new ValidationError($"Could not parse {link.Code}: {link.Value}"));
                }
            }
  
        }

        private void AddSegment(Segment segment, bool isCollection = false, bool checkType = false)
        {
            if (isCollection)
            {
                int count = _segments.FindAll(e => e.Type == segment.Type).Count;
                if (count == segment.Descriptor.MaxElements)
                {
                    ValidationError error = new($"Maximum segment count {count} reached.", segment);
                    _errors.Add(error);
                    return;
                }
                segment.SetIndex(count);
            }
            if (checkType)
            {
                if (_segments.Exists(e => e.Type == segment.Type))
                {
                    ValidationError error = new($"Duplicate segment found.", segment);
                    _errors.Add(error);
                    return;
                }
            }
            else if (_segments.Exists(e => e.Code == segment.Code))
            {
                ValidationError error = new($"Duplicate segment found.", segment);
                _errors.Add(error);
                return;
            }
            _segments.Add(segment);
        }

        /// <summary>
        /// Build the DigitalLink
        /// </summary>
        /// <returns></returns>
        public DigitalLink Build()
        {
            DigitalLink link = new();

            if (_primary == null) 
            {
                _errors.Add(new("Missing primary segment"));
                link.SetErrors(_errors);
                return link;
            }

            List<ValidationError> errors = [];
            errors.AddRange(_errors);

            List<Segment> segments = [.. _segments.OrderBy(e => int.Parse(e.Code))]; //make canonical and mutable

          
            StringBuilder sb = new();

            string uri = _uri;
            if (uri.EndsWith('/')) uri = uri[..^1];
            sb.Append(uri);


            if (_primary.Validate(out ValidationError error))
            {
                
                link.Primary = _primary;
                WriteQualifier(sb, _primary);
            }
            else
            {
                errors.Add(error);
            }


            HashSet<string> excludes = _primary.Descriptor.Excludes;

            foreach (string qualifier in _primary.Descriptor.Qualifiers)
            {
                Segment segment = segments.Find(e => e.Code == qualifier);
                if (segment != null)
                {
                    if (segment.Validate(out error))
                    {
                        link.Qualifiers.Add(segment);
                        WriteQualifier(sb, segment);
                    }
                    else
                    {
                        errors.Add(error);
                    }
                    foreach (string exclude in segment.Descriptor.Excludes)
                    {
                        excludes.Add(exclude);
                    }
                    segments.Remove(segment);
                }
            }



            if (segments.Count > 0)
            {

                sb.Append('?');
                bool amp = false;
                foreach (Segment segment in segments)
                {
                    if (segment.Descriptor.Attribute)
                    {
                        if (IsRequiredInPath(segment))
                        {
                            if (segment.Validate(out error))
                            {
                                link.Attributes.Add(segment);
                                WriteAttribute(sb, segment, amp);
                            }
                            else
                            {
                                errors.Add(error);
                            }

                            foreach (string exclude in segment.Descriptor.Excludes)
                            {
                                excludes.Add(exclude);
                            }
                            amp = true;
                        }
                        else
                        {
                            StringBuilder eb = new();
                            foreach (string require in segment.Descriptor.Requires)
                            {
                                int code = int.Parse(require);
                                if (Enum.IsDefined(typeof(SegmentType), code))
                                {
                                    SegmentType type = (SegmentType)code;
                                    eb.Append(type);
                                    eb.Append(',');
                                }
                            }
                            error = new($"Segment is missing required segment. At least one segment of type [{eb.ToString().TrimEnd(',')}] should be included in the link.", segment);
                            errors.Add(error);
                        }
                    }
                    else
                    {
                        error = new("Segment can not be used as an attribute.", segment);
                        errors.Add(error);
                    }
                }
            }

            foreach (string exclude in excludes)
            {
                Segment segment = _segments.Find(e => e.Code == exclude);
                if (segment != null)
                {
                    error = new("Segment should be excluded in current path.", segment);
                    errors.Add(error);
                }
            }

            //finally validate uri
            uri = sb.ToString();
            Regex regex = DigitalLinkRegex();
            if (!regex.IsMatch(uri))
            {
                errors.Add(new($"Invalid digital link format '{uri}'."));
            }

            link.SetErrors(errors);

            if (link.IsValid)
            {
                link.Uri = uri;
            }

            return link;
        }

        private bool IsRequiredInPath(Segment segment)
        {
            HashSet<string> requires = segment.Descriptor.Requires;
            if (requires.Count == 0) return true;
            foreach (string require in requires)
            {
                int code = int.Parse(require);
                if (Enum.IsDefined(typeof(SegmentType), code))
                {
                    SegmentType type = (SegmentType)code;
                    if (_primary.Type == type) return true;
                    if (_segments.Exists(e => e.Type == type)) return true;
                }

            }
            return false;
        }


        private static void WriteQualifier(StringBuilder sb, Segment segment)
        {
            sb.Append('/');
            sb.Append(segment.Code);
            sb.Append('/');
            sb.Append(HttpUtility.UrlEncode(segment.Raw));
        }

        private static void WriteAttribute(StringBuilder sb, Segment segment, bool amp)
        {
            if (amp) sb.Append('&');
            sb.Append(segment.Code);
            sb.Append('=');
            sb.Append(HttpUtility.UrlEncode(segment.Raw));
        }

        [GeneratedRegex("^https?:(\\/\\/((([^\\/?#]*)@)?([^\\/?#:]*)(:([^\\/?#]*))?))?([^?#]*)(((\\/(\\d{2,12})\\/)(\\d{2,12}[^\\/]+)(\\/[^/]+\\/[^/]+)?[/]?(\\?([^?\\n]*))?(#([^\\n]*))?))")]
        internal static partial Regex DigitalLinkRegex();
    }
}
