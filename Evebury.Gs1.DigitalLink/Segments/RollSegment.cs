using System.Text;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class RollSegment : Segment
    {
        public RollSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public RollSegment(SegmentType type, Roll roll) : base((int)type)
        {
            StringBuilder sb = new();
            sb.Append(roll.SlitWidth.ToString().PadLeft(4, '0'));
            sb.Append(roll.Length.ToString().PadLeft(5, '0'));
            sb.Append(roll.Diameter.ToString().PadLeft(3, '0'));
            sb.Append((int)roll.Winding);
            sb.Append((int)roll.Splices);
            Raw = sb.ToString();
            Value = new SegmentValue(roll, SegmentValueType.Roll);
        }

        protected override SegmentValue GetValue()
        {
            int slitWidth = int.Parse(Raw[..4]);
            int length = int.Parse(Raw.Substring(4, 5));
            int diameter = int.Parse(Raw.Substring(9, 3));
            Winding winding = (Winding)int.Parse(Raw.Substring(12, 1));
            Splice splice = (Splice)int.Parse(Raw.Substring(13, 1));
            Roll roll = new(slitWidth, length, diameter, winding, splice);
            return new SegmentValue(roll, SegmentValueType.Roll);
        }
    }
}
