using System;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class RawSegment : Segment
    {
        public RawSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public RawSegment(SegmentType type, string code, string raw) : base((int)type)
        {
            Code = code;
            Raw = raw;
            Value = new SegmentValue(raw, ValueType.String);
        }

        protected override SegmentValue GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
