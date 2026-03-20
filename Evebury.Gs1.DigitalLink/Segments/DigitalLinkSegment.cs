namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class DigitalLinkSegment(string code, string value)
    {
        public string Code { get; set; } = code;

        public string Value { get; set; } = value;

        public SegmentType Type { get; set; }

        public SegmentValueType ValueType { get; set; } = SegmentValueType.Raw;

        public bool IsInvalid => Code == null || Value == null;
    }
}
