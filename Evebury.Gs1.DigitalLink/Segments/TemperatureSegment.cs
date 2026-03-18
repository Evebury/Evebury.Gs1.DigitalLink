using System;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class TemperatureSegment : UnitSegment<Temperature>
    {
        public TemperatureSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public TemperatureSegment(Temperature unit, SegmentType type) : base(unit, ValueType.Temperature, type)
        {
        }

        protected override int GetUnitOffset(Temperature unit)
        {
            if (unit.Unit == TemperatureUnit.CELSIUS) return 1;
            return 0;
        }

        protected override SegmentValue GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
