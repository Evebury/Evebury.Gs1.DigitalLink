using Evebury.Gs1.DigitalLink.Segments.MetaData;
using System;
using System.Globalization;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class IntegerSegment : Segment
    {
        public IntegerSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public IntegerSegment(IntegerType type, int value) : this((SegmentType)(int)type, value) { }

        public IntegerSegment(SegmentType type, int value) : base((int)type)
        {
            Capture capture = Descriptor.Captures[0];
            string raw = value.ToString(CultureInfo.InvariantCulture);
            if (capture.Fixed && raw.Length < capture.Length)
            {
                Raw = raw.PadLeft(capture.Length, '0');
            }
            else Raw = raw;
            Value = new SegmentValue(value, ValueType.Integer);
        }

        protected override SegmentValue GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
