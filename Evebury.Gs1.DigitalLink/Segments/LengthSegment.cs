using System;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class LengthSegment : UnitSegment<Length>
    {
        public LengthSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public LengthSegment(Length unit, SegmentType type) : base(unit, ValueType.Length, type)
        {
            if (type == SegmentType.AREA) unit.Power = 2;
        }

        protected override int GetUnitOffset(Length unit)
        {
            switch (Type)
            {
                case SegmentType.LENGTH:
                case SegmentType.LOGISTIC_LENGTH:
                    {
                        switch (unit.Unit)
                        {
                            case LengthUnit.METER: return 0;
                            case LengthUnit.INCH: return 100;
                            case LengthUnit.FEET: return 110;
                            case LengthUnit.YARDS: return 120;
                        }
                        break;
                    }
                case SegmentType.AREA:
                    {
                        switch (unit.Unit)
                        {
                            case LengthUnit.METER: return 0;
                            case LengthUnit.INCH: return 360;
                            case LengthUnit.FEET: return 370;
                            case LengthUnit.YARDS: return 380;
                        }
                        break;
                    }
                case SegmentType.LOGISTIC_AREA:
                    {
                        switch (unit.Unit)
                        {
                            case LengthUnit.METER: return 0;
                            case LengthUnit.INCH: return 190;
                            case LengthUnit.FEET: return 200;
                            case LengthUnit.YARDS: return 210;
                        }
                        break;
                    }
                case SegmentType.WIDTH:
                case SegmentType.LOGISTIC_WIDTH:
                    {
                        switch (unit.Unit)
                        {
                            case LengthUnit.METER: return 0;
                            case LengthUnit.INCH: return 120;
                            case LengthUnit.FEET: return 130;
                            case LengthUnit.YARDS: return 140;
                        }
                        break;
                    }
                case SegmentType.HEIGHT:
                case SegmentType.LOGISTIC_HEIGHT:
                    {
                        switch (unit.Unit)
                        {
                            case LengthUnit.METER: return 0;
                            case LengthUnit.INCH: return 140;
                            case LengthUnit.FEET: return 150;
                            case LengthUnit.YARDS: return 160;
                        }
                        break;
                    }
            }
            return 0;
        }

        protected override SegmentValue GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
