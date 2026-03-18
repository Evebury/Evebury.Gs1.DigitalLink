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

        }

        public CountrySegment(CountryCodeType type, List<CountryCode> codes) : base((int)type)
        {
            StringBuilder sb = new();
            foreach (CountryCode code in codes)
            {
                sb.Append(((int)code).ToString().PadLeft(3, '0'));
            }
            Raw = sb.ToString();
            
        }

        protected override SegmentValue GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
