using Evebury.Gs1.DigitalLink.Segments.MetaData;
using System;
using System.Globalization;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class DoubleSegment : Segment
    {
        public DoubleSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public DoubleSegment(DoubleType type, Double value) : base((int)type)
        {
            int code = (int)Type;
            code += value.Precision;

            Capture capture = Descriptor.Captures[0];
            Code = code.ToString();
            string raw = value.Value.ToString(value.Format, CultureInfo.InvariantCulture);
            raw = raw.Replace(".", "");
            if (capture.Fixed && raw.Length < capture.Length)
            {
                Raw = raw.PadLeft(capture.Length, '0');
            }
            else Raw = raw;

            Value = new SegmentValue(value, ValueType.Double);
        }



        protected override SegmentValue GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
