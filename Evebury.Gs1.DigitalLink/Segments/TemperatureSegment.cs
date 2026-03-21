namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class TemperatureSegment : UnitSegment<Temperature>
    {
        public TemperatureSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public TemperatureSegment(Temperature unit, SegmentType type) : base(unit, SegmentValueType.Temperature, type)
        {
        }

        protected override int GetUnitOffset(Temperature unit)
        {
            if (unit.Unit == TemperatureUnit.CELSIUS) return 1;
            return 0;
        }

        protected override SegmentValue GetValue()
        {
            TemperatureUnit unit = TemperatureUnit.FAHRENHEIT;
            int offset = 0;
            if (int.Parse(Code) != (int)Type) 
            {
                unit = TemperatureUnit.CELSIUS;
                offset = 1;
            }
            bool negate = false;
            string raw = Raw;
            if (raw.EndsWith('-')) 
            {
                raw = raw[..^1];
                negate = true;
            }
            Double @double = GetDoubleValue(raw, offset);
            double d = @double.Value;
            d *= 0.01;
            if (negate) 
            {
                d *= -1;
            }
            @double = new(d);
            return new SegmentValue(new Temperature(@double, unit), SegmentValueType.Temperature);
        }
    }
}
