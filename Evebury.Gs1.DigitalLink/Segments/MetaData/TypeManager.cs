using System.Collections.Generic;

namespace Evebury.Gs1.DigitalLink.Segments.MetaData
{
    internal static class TypeManager
    {
        //private static Dictionary<int, ValueType> _typeMap;

        public static SegmentValueType GetValueType(int code) 
        {
            //if (_typeMap.TryGetValue(code, out ValueType type))
            //{
            //    return type;
            //}
            return SegmentValueType.String;
        }

        public static string ToCode(this SegmentType type) 
        {
            return ((int)type).ToString().PadLeft(2, '0');
        }
    }
}
