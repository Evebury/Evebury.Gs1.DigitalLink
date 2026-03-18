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
            Value = new(value, ValueType.String);
        }

        protected override SegmentValue GetValue()
        {
            return new SegmentValue(Raw, ValueType.String);
        }
    }
}
