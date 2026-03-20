namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class PriceSegment : UnitSegment<Price>
    {
        public PriceSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public PriceSegment(Price unit, SegmentType type) : base(unit, SegmentValueType.Price, type)
        {
            string currency = ((int)unit.Unit).ToString().PadLeft(3,'0');
            Raw = $"{currency}{Raw}";
        }

        protected override int GetUnitOffset(Price unit)
        {
            return 0;
        }

        protected override SegmentValue GetValue()
        {
            CurrencyCode currency = (CurrencyCode) int.Parse(Raw[..3]);
            string value = Raw[3..];
            Double @double = GetDoubleValue(value, 0);
            return new SegmentValue(new Price(@double, currency), SegmentValueType.Price);
        }
    }
}
