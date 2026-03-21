using Evebury.Gs1.DigitalLink.Segments.MetaData;
using System.Globalization;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class DoubleSegment : Segment
    {
        public DoubleSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public DoubleSegment(DoubleType type, Double value) : base((int)type)
        {
            int code = (int)Type;
            code += value.Precision;

            Capture capture = Descriptor.Captures[0];
            Code = code.ToString();
            string raw = value.Value.ToString(value.Format, CultureInfo.InvariantCulture);
            raw = raw.Replace(".", "");
            if (capture.Fixed && raw.Length < capture.Length)
            {
                Raw = raw.PadLeft(capture.Length, '0');
            }
            else Raw = raw;

            Value = new SegmentValue(value, SegmentValueType.Double);
        }


        protected override SegmentValue GetValue()
        {
            int code = (int)Type;
            int precision = int.Parse(Code) - code;
            if (precision > 0)
            {
                string number = Raw[..^precision];
                string decimals = Raw.Substring(number.Length, precision);
                double value = double.Parse($"{number}.{decimals}", CultureInfo.InvariantCulture);
                return new SegmentValue(new Double(value, precision), SegmentValueType.Double);
            }
            else 
            {
                double value = double.Parse(Raw);
                return new SegmentValue(new Double(value), SegmentValueType.Double);
            }
        }
    }
}
