using Evebury.Gs1.DigitalLink.Segments.MetaData;
using Evebury.Gs1.DigitalLink.Unit;
using System.Globalization;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal abstract class UnitSegment<T> : Segment where T : IBaseUnit
    {
        protected UnitSegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        protected UnitSegment(T unit, SegmentValueType valueType, SegmentType type) : base((int)type)
        {
            Set(unit, valueType);
        }

        private void Set(T unit, SegmentValueType type)
        {
            int code = (int)Type;
            code += unit.Precision;
            code += GetUnitOffset(unit);

            Capture capture = Descriptor.Captures[0];
            Code = code.ToString();
            string value = System.Math.Abs(unit.Value).ToString(unit.Format, CultureInfo.InvariantCulture);
            value = value.Replace(".", "");
            if (capture.Fixed && value.Length < capture.Length)
            {
                Raw = value.PadLeft(capture.Length, '0');
            }
            else Raw = value;

            if (unit.Value < 0) Raw = $"{Raw}-";

            Value = new SegmentValue(unit, type);
        }

        protected abstract int GetUnitOffset(T unit);

        protected Double GetDoubleValue(int offset) 
        { 
            return GetDoubleValue(Raw, offset);
        }

        protected Double GetDoubleValue(string raw, int offset)
        {
            int code = (int)Type;
            code += offset;
            int precision = int.Parse(Code) - code;
            if (precision > 0)
            {
                string number = raw[..^precision];
                string decimals = raw.Substring(number.Length, precision);
                double value = double.Parse($"{number}.{decimals}", CultureInfo.InvariantCulture);
                return new Double(value, precision);
            }
            else
            {
                double value = double.Parse(raw);
                return new Double(value);
            }

        }
    }
}
