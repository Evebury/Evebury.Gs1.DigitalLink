using System;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class VolumeSegment : UnitSegment<Volume>
    {
        public VolumeSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public VolumeSegment(Volume unit, SegmentType type) : base(unit, SegmentValueType.Volume, type)
        {
        }

        protected override int GetUnitOffset(Volume unit)
        {
            switch (unit.Unit) 
            {
                case VolumeUnit.LITRES: 
                    {
                        return 0;
                    }
                default: 
                    {
                        switch (Type) 
                        {
                            case SegmentType.NET_VOLUME: 
                                {
                                    switch (unit.Unit) 
                                    {
                                        case VolumeUnit.METER: return 10;
                                        case VolumeUnit.QUARTS: return 450;
                                        case VolumeUnit.GALLONS: return 460;
                                        case VolumeUnit.INCH: return 490;
                                        case VolumeUnit.FEET: return 500;
                                        case VolumeUnit.YARDS: return 510;
                                    }
                                    break;
                                }
                            case SegmentType.LOGISTIC_VOLUME:
                                {
                                    switch (unit.Unit)
                                    {
                                        case VolumeUnit.METER: return 10;
                                        case VolumeUnit.QUARTS: return 270;
                                        case VolumeUnit.GALLONS: return 280;
                                        case VolumeUnit.INCH: return 320;
                                        case VolumeUnit.FEET: return 330;
                                        case VolumeUnit.YARDS: return 340;
                                    }
                                    break;
                                }
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
