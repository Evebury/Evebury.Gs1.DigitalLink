using Evebury.Gs1.DigitalLink.Segments.MetaData;
using System.Globalization;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class GenderSegment : Segment
    {
        public GenderSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public GenderSegment(GenderCode value, SegmentType type) : base((int)type)
        {
            Capture capture = Descriptor.Captures[0];
            string raw = ((int)value).ToString(CultureInfo.InvariantCulture);
            if (capture.Fixed && raw.Length < capture.Length)
            {
                Raw = raw.PadLeft(capture.Length, '0');
            }
            else Raw = raw;
            Value = new SegmentValue(value, SegmentValueType.GenderCode);
        }

        protected override SegmentValue GetValue()
        {
            GenderCode code = (GenderCode)int.Parse(Raw);
            return new SegmentValue(code, SegmentValueType.GenderCode);
        }
    }
}
