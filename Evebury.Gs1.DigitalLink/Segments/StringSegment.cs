namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class StringSegment : Segment
    {
        public StringSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public StringSegment(StringType type, string value) : base((int)type)
        {
            if (string.IsNullOrWhiteSpace(value)) value = string.Empty;
            Raw = value;
            Value = new(value, SegmentValueType.String);
        }

        protected override SegmentValue GetValue()
        {
            return new SegmentValue(Raw, SegmentValueType.String);
        }
    }
}
