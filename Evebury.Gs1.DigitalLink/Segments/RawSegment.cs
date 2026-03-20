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
            Value = new SegmentValue(raw, SegmentValueType.Raw);
        }

        protected override SegmentValue GetValue()
        {
            return new SegmentValue(Raw, SegmentValueType.Raw);
        }
    }
}
