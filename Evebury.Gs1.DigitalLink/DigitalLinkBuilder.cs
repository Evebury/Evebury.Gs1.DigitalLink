using Evebury.Gs1.DigitalLink.Segments;
using Evebury.Gs1.DigitalLink.Segments.MetaData;
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
        private readonly KeySegment _primary;

        /// <summary>
        /// Construct the root elements of the Uri
        /// </summary>
        /// <param name="primary">Primary (key) segment</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DigitalLinkBuilder(Primary primary)
        {
            if (primary.Value == null) throw new ArgumentOutOfRangeException(nameof(primary));
            _primary = new(primary.Type, primary.Value);
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


        #region key

        /// <summary>
        /// Add Key Segement
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
        /// <param name="value"></param>
        public void AddPeriod(PeriodType type, Period value)
        {
            DateSegment segment = new(type, value);
            AddSegment(segment);
        }
        #endregion

        #region unit
        /// <summary>
        /// Add NetWeight Segment
        /// </summary>
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="unit"></param>
        public void AddNetWeight(double value, WeightUnit unit)
        {
            WeightSegment segment = new(new Weight(value, unit), SegmentType.NET_WEIGHT);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add NetWeight Segment
        /// </summary>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="unit"></param>
        public void AddNetWeight(double value, int precision, WeightUnit unit)
        {
            WeightSegment segment = new(new Weight(value, precision, unit), SegmentType.NET_WEIGHT);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add Logistic GrossWeight Segment
        /// </summary>
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="unit"></param>
        public void AddLogisticGrossWeight(double value, LogisticWeightUnit unit)
        {
            WeightSegment segment = new(new Weight(value, (WeightUnit)(int)unit), SegmentType.LOGISTIC_GROSS_WEIGHT);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add Logistic GrossWeight Segment
        /// </summary>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="unit"></param>
        public void AddLogisticGrossWeight(double value, int precision, LogisticWeightUnit unit)
        {
            WeightSegment segment = new(new Weight(value, precision, (WeightUnit)(int)unit), SegmentType.LOGISTIC_GROSS_WEIGHT);
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
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="unit"></param>
        public void AddLength(LengthType type, double value, LengthUnit unit)
        {
            Length length = new(value, unit);
            AddLength(length, type);
        }

        /// <summary>
        /// Add Length Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="unit"></param>
        public void AddLength(LengthType type, double value, int precision, LengthUnit unit)
        {
            Length length = new(value, precision, unit);
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
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="unit"></param>
        public void AddLogisticLength(LengthType type, double value, LengthUnit unit)
        {
            Length length = new(value, unit);
            AddLogisticLength(length, type);
        }

        /// <summary>
        /// Add Logistic Length Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="unit"></param>
        public void AddLogisticLength(LengthType type, double value, int precision, LengthUnit unit)
        {
            Length length = new(value, precision, unit);
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
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="unit"></param>
        public void AddNetVolume(double value, VolumeUnit unit)
        {
            VolumeSegment segment = new(new Volume(value, unit), SegmentType.NET_VOLUME);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add NetVolume Segment
        /// </summary>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="unit"></param>
        public void AddNetVolume(double value, int precision, VolumeUnit unit)
        {
            VolumeSegment segment = new(new Volume(value, precision, unit), SegmentType.NET_VOLUME);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add Logistic NetVolume Segment
        /// </summary>
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="unit"></param>
        public void AddLogisticVolume(double value, VolumeUnit unit)
        {
            VolumeSegment segment = new(new Volume(value, unit), SegmentType.LOGISTIC_VOLUME);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add Logistic Volume Segment
        /// </summary>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="unit"></param>
        public void AddLogisticVolume(double value, int precision, VolumeUnit unit)
        {
            VolumeSegment segment = new(new Volume(value, precision, unit), SegmentType.LOGISTIC_VOLUME);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add Price Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value">raw decimals are inferred</param>
        /// <param name="currency"></param>
        public void AddPrice(PriceType type, double value, CurrencyCode currency) 
        {
            PriceSegment segment = new(new Price(value,currency),(SegmentType)(int)type);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add Price Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value">raw decimals are set to given precision</param>
        /// <param name="precision">precision e.g. precision=2 value=1.1d raw="1.10"</param>
        /// <param name="currency"></param>
        public void AddPrice(PriceType type, double value, int precision, CurrencyCode currency)
        {
            PriceSegment segment = new(new Price(value, precision, currency), (SegmentType)(int)type);
            AddSegment(segment, false, true);
        }

        /// <summary>
        /// Add MinimumTemperature
        /// </summary>
        /// <param name="value">in 100 of degrees. 23.3 will be multiplied by 100 for raw</param>
        /// <param name="unit"></param>
        public void AddMinimumTemperature(double value, TemperatureUnit unit) 
        {
            TemperatureSegment segment = new(new Temperature(value * 100, 0, unit), SegmentType.MINIMUM_TEMPERATURE);
            AddSegment(segment);
        }

        /// <summary>
        /// Add MaximumTemperature
        /// </summary>
        /// <param name="value">in 100 of degrees. 23.3 will be multiplied by 100 for raw</param>
        /// <param name="unit"></param>
        public void AddMaximumTemperature(double value, TemperatureUnit unit)
        {
            TemperatureSegment segment = new(new Temperature(value * 100, 0, unit), SegmentType.MAXIMUM_TEMPERATURE);
            AddSegment(segment);
        }


        #endregion

        #region types

        /// <summary>
        /// Add String Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void AddString(StringType type, string value)
        {
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
            IntegerSegment segment = new(SegmentType.BIOLOGICAL_SEX, (int)genderCode);
            AddSegment(segment);
        }

        /// <summary>
        /// Add Country Code Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="countryCode"></param>
        public void AddCountry(CountryCodeType type, CountryCode countryCode)
        {
            if (type == CountryCodeType.SHIP_TO_COUNTRY)
            {
                StringSegment segment = new(StringType.SHIP_TO_COUNTRY, countryCode.ToString());
                AddSegment(segment);
            }
            else
            {
                CountrySegment segment = new(type, [countryCode]);
                AddSegment(segment);
            }
        }

        /// <summary>
        /// Add Country Code Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="countryCodes">Nb! SHIP_TO_COUNTRY can only be added once</param>
        public void AddCountry(CountryCodeType type, List<CountryCode> countryCodes)
        {
            if (type == CountryCodeType.SHIP_TO_COUNTRY)
            {
                foreach (CountryCode countryCode in countryCodes)
                {
                    StringSegment segment = new(StringType.SHIP_TO_COUNTRY, countryCode.ToString());
                    AddSegment(segment);
                }
            }
            else
            {
                CountrySegment segment = new(type, countryCodes);
                AddSegment(segment);
            }
        }


        /// <summary>
        /// Add Country With Value Segment
        /// </summary>
        /// <param name="type"></param>
        /// <param name="countryCode"></param>
        /// <param name="value"></param>
        public void AddCountryWithValue(CountryType type, CountryCode countryCode, string value) 
        {
            CountrySegment segment = new(type, new Country(countryCode, value));
            AddSegment(segment, segment.Descriptor.MaxElements > 0);
        }

        /// <summary>
        /// The GS1 Application Identifier (8001) indicates that the GS1 Application Identifier data fields contain 
        /// the variable attributes of a roll product.Depending on the method of production, some roll products 
        /// cannot be numbered according to standard criteria that have been determined in advance.They are,
        /// therefore, classified as variable items.For those products where the standard trade measures are 
        /// not sufficient, the following guidelines should be used
        /// </summary>
        /// <param name="slitWidth">slit width in millimetres (width of the roll)</param>
        /// <param name="length"> actual length in metres</param>
        /// <param name="diameter">internal core diameter in millimetres</param>
        /// <param name="winding">winding direction (face out 0, face in 1, undefined 9)</param>
        /// <param name="splices">number of splices (0 to 8 = actual number, 9 = number unknown)</param>
        public void AddRollProduct(int slitWidth, int length, int diameter, int winding, int splices) 
        {
            StringBuilder sb = new();
            sb.Append(slitWidth.ToString().PadLeft(4, '0'));
            sb.Append(length.ToString().PadLeft(5, '0'));
            sb.Append(diameter.ToString().PadLeft(3, '0'));
            sb.Append(winding);
            sb.Append(splices);
            RawSegment segment = new(SegmentType.ROLL_PRODUCT, SegmentType.ROLL_PRODUCT.ToCode(), sb.ToString());
            AddSegment(segment);
        }


        /// <summary>
        /// Add Raw (use only if all fails)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="code"></param>
        /// <param name="raw"></param>
        public void AddRaw(SegmentType type, string code, string raw) 
        {
            RawSegment segment = new(type, code, raw);
            AddSegment(segment, segment.Descriptor.MaxElements > 0);
        }
        #endregion


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
            List<ValidationError> errors = [];
            errors.AddRange(_errors);

            string uri = _uri;
            if (uri.EndsWith('/')) uri = uri[..^1];


            List<Segment> segments = [.. _segments.OrderBy(e => e.Code)]; //make canonical and mutable

            DigitalLink link = new();
            StringBuilder sb = new();


            if (_primary.Validate(out ValidationError error))
            {
                sb.Append(uri);
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
                errors.Add(new($"Invalid digital link uri '{uri}'."));
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
        private static partial Regex DigitalLinkRegex();
    }
}
