using Evebury.Gs1.DigitalLink.Segments.MetaData;
using System.Collections.Generic;

namespace Evebury.Gs1.DigitalLink.Segments
{
    /// <summary>
    /// Segment
    /// </summary>
    public abstract class Segment
    {
        internal Descriptor Descriptor { get; private set; }

        /// <summary>
        /// Type
        /// </summary>
        public SegmentType Type { get; private set; }

        /// <summary>
        /// Code (as used in Digital Link Uri)
        /// </summary>
        public string Code { get; protected set; }

        /// <summary>
        /// Value (as used in Digital Link Uri)
        /// </summary>
        public string Raw { get; protected set; }

        /// <summary>
        /// Strongly typed value
        /// </summary>
        public SegmentValue Value { get; protected set; }
    
        internal Segment(DigitalLinkSegment segment) 
        {
            Code = segment.Code;
            Raw = segment.Value;
            Type = segment.Type;
            Descriptor = Descriptor.Load(Type);
        }

        internal Segment(int type)
        {
            Type = (SegmentType)type;
            Code = Type.ToCode();
            Descriptor = Descriptor.Load(Type);
        }


        #region internal

        internal void SetIndex(int count) 
        {
            int key = int.Parse(Code);
            key += count;
            Code = key.ToString().PadLeft(2, '0');
        }

        internal virtual bool Validate(out ValidationError error)
        {
            error = null;
            if (string.IsNullOrWhiteSpace(Raw))
            {
                error = new("Value is null or empty.", this);
                return false;
            }
            if (!Descriptor.Validate(this, Raw, out List<Capture> captures, out error))
            {
                return false;
            }
            return Validate(captures, out error);
        }

        internal virtual bool Validate(List<Capture> groups, out ValidationError error)
        {
            error = null;
            return true;
        }

        internal static bool TryParse(DigitalLinkSegment link, out Segment segment)
        {
            segment = null;
            if (!int.TryParse(link.Code, out _)) return false;
            if (string.IsNullOrWhiteSpace(link.Value)) return false;
            switch (link.ValueType) 
            {
                case SegmentValueType.Key:
                    {
                        segment = new KeySegment(link);
                        break;
                    }
                case SegmentValueType.String: 
                    {
                        segment = new StringSegment(link);
                        break;
                    }
                case SegmentValueType.Date:
                case SegmentValueType.DateTime:
                case SegmentValueType.Period: 
                    {
                        segment = new DateSegment(link);
                        break;
                    }
                case SegmentValueType.Weight:
                    {
                        segment = new WeightSegment(link);
                        break;
                    }
                case SegmentValueType.Length:
                    {
                        segment = new LengthSegment(link);
                        break;
                    }
                case SegmentValueType.Volume:
                    {
                        segment = new VolumeSegment(link);
                        break;
                    }
                case SegmentValueType.Double:
                    {
                        segment = new DoubleSegment(link);
                        break;
                    }
                case SegmentValueType.Price:
                    {
                        segment = new PriceSegment(link);
                        break;
                    }
                case SegmentValueType.Integer:
                    {
                        segment = new IntegerSegment(link);
                        break;
                    }
                case SegmentValueType.Boolean:
                    {
                        segment = new BooleanSegment(link);
                        break;
                    }
                case SegmentValueType.Temperature:
                    {
                        segment = new TemperatureSegment(link);
                        break;
                    }
                case SegmentValueType.Country:
                case SegmentValueType.CountryCode:
                    {
                        segment = new CountrySegment(link);
                        break;
                    }
                case SegmentValueType.GenderCode:
                    {
                        segment = new GenderSegment(link);
                        break;
                    }
                case SegmentValueType.Roll:
                    {
                        segment = new RollSegment(link);
                        break;
                    }
                default: 
                    {
                        segment = new RawSegment(link);
                        break;
                    }
            }
            segment.Value = segment.GetValue();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract SegmentValue GetValue();
        #endregion
    }
}
