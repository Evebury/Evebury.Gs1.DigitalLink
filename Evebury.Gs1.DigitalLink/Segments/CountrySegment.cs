using System;
using System.Collections.Generic;
using System.Text;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class CountrySegment : Segment
    {
        public CountrySegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public CountrySegment(CountryType type, Country country) : base((int)type)
        {
            string raw = ((int)country.Code).ToString().PadLeft(3, '0');
            Raw = $"{raw}{country.Value}";
            Value = new(country, SegmentValueType.Country);

        }

        public CountrySegment(CountryCodeType type, List<CountryCode> codes) : base((int)type)
        {
            if (type == CountryCodeType.SHIP_TO_COUNTRY)
            {
                StringBuilder sb = new();
                foreach (CountryCode code in codes)
                {
                    sb.Append(code.ToString());
                }
                Raw = sb.ToString();
            }
            else
            {
                StringBuilder sb = new();
                foreach (CountryCode code in codes)
                {
                    sb.Append(((int)code).ToString().PadLeft(3, '0'));
                }
                Raw = sb.ToString();
            }
            
            Value = new(codes, SegmentValueType.CountryCode);

        }

        protected override SegmentValue GetValue()
        {
            int type = (int)Type;
            if (Enum.IsDefined(typeof(CountryCodeType), type))
            {
                List<CountryCode> codes = [];
                if (Type == SegmentType.SHIP_TO_COUNTRY)
                {
                    CountryCode country = Enum.Parse<CountryCode>(Raw);
                    codes.Add(country);
                }
                else
                {
                    int index = 0;
                    int length = Raw.Length;
                    while (index < length)
                    {
                        string raw = Raw.Substring(index, 3);
                        CountryCode country = (CountryCode)int.Parse(raw);
                        codes.Add(country);
                        index += 3;
                    }
                }
                return new SegmentValue(codes, SegmentValueType.CountryCode);
            }
            else 
            {
                string code = Raw[..3];
                Country country = new((CountryCode) int.Parse(code), Raw[3..]);
                return new SegmentValue(country, SegmentValueType.CountryCode);
            }
        }
    }
}
