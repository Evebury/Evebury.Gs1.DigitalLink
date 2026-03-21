using System;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class WeightSegment : UnitSegment<Weight>
    {
        public WeightSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public WeightSegment(Weight weight, SegmentType type) : base(weight, SegmentValueType.Weight, type)
        {
            if (type == SegmentType.KG_PER_SQUARE_METRE) 
            {
                weight.PostFix = " per m²";
            }
        }

        protected override int GetUnitOffset(Weight unit)
        {
            switch (unit.Unit)
            {
                case WeightUnit.KILOGRAM:
                    {
                        return 0;
                    }
                case WeightUnit.POUNDS:
                    {
                        switch (Type)
                        {
                            case SegmentType.NET_WEIGHT:
                                {
                                    return 100;
                                }
                            case SegmentType.LOGISTIC_GROSS_WEIGHT:
                                {
                                    return 100;
                                }
                        }
                        break;
                    }
                case WeightUnit.TROY_OUNCE:
                    {
                        switch (Type)
                        {
                            case SegmentType.NET_WEIGHT:
                                {
                                    return 460;
                                }
                        }
                        break;
                    }
                case WeightUnit.OUNCE:
                    {
                        switch (Type)
                        {
                            case SegmentType.NET_WEIGHT:
                                {
                                    return 470;
                                }
                        }
                        break;
                    }
            }

            return 0;
        }


        protected override SegmentValue GetValue()
        {
            WeightUnit unit = WeightUnit.KILOGRAM;
            int offset = int.MaxValue;
            int type = (int)Type;
            int code = (int)Math.Round(int.Parse(Code) /10d) * 10;
            foreach (WeightUnit @enum in Enum.GetValues<WeightUnit>())
            {
                int unitOffset = GetUnitOffset(new Weight(0, @enum));
                if (type + unitOffset == code)
                {
                    unit = @enum;
                    offset = unitOffset;
                    break;
                }

            }
            Double @double = GetDoubleValue(offset);
            return new SegmentValue(new Weight(@double, unit), SegmentValueType.Weight);
        }
    }
}
