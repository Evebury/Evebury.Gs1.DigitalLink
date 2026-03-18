using System.Collections.Generic;

namespace Evebury.Gs1.DigitalLink.Segments.MetaData
{
    internal static class TypeManager
    {
        //private static Dictionary<int, ValueType> _typeMap;

        public static ValueType GetValueType(int code) 
        {
            //if (_typeMap.TryGetValue(code, out ValueType type))
            //{
            //    return type;
            //}
            return ValueType.String;
        }

        public static string ToCode(this SegmentType type) 
        {
            return ((int)type).ToString().PadLeft(2, '0');
        }
    }
}
