namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class BooleanSegment : Segment
    {
        public BooleanSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public BooleanSegment(BooleanType type, bool value) : base((int)type)
        {
            Raw = value ? "1" : "0";
            Value = new SegmentValue(value, ValueType.Boolean);
        }

        protected override SegmentValue GetValue()
        {
            return new SegmentValue(Raw == "1", ValueType.Boolean);
        }
    }
}
