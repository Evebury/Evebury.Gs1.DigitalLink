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
            Code = segment.Key;
            Raw = segment.Value;
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

        internal static bool TryParse(DigitalLinkSegment link, out Segment segment, out ValidationError error)
        {
            error = null;
            segment = null;
            if (!int.TryParse(link.Key, out int key)) return false;
            if (string.IsNullOrEmpty(link.Value)) return false;
            ValueType type = TypeManager.GetValueType(key);
            switch (type) 
            {
                case ValueType.Date:
                case ValueType.DateTime:
                case ValueType.Period: 
                    {
                        segment = new DateSegment(link);
                        break;
                    }
                default: return false;
            }
            segment.Type = segment.GetType(key);
            segment.Descriptor = Descriptor.Load(segment.Type);
            if (!segment.Validate(out error))
            { 
                return false;
            }
            segment.Value = segment.GetValue();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual SegmentType GetType(int key) 
        { 
            return (SegmentType)key;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract SegmentValue GetValue();
        #endregion
    }
}
