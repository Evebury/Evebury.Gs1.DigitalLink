using System;

namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class DateSegment : Segment
    {

        public DateSegment(DigitalLinkSegment segment) : base(segment) 
        { }

        public DateSegment(DateType type, DateTime value) : base((int)type) 
        {
            value = value.Date;
            Raw = value.ToString("yyMMdd");
            Value = new(value, SegmentValueType.Date);
        }

        public DateSegment(DateTimeType type, DateTime value) : base((int)type)
        {
            Raw = value.ToString("yyMMddHHmm");
            Value = new(value, SegmentValueType.DateTime);
        }

        public DateSegment(PeriodType type, Period value) : base((int)type)
        {
            Raw = $"{value.Start:yyMMdd}{value.End:yyMMdd}";
            Value = new(value, SegmentValueType.Period);
        }

        protected override SegmentValue GetValue()
        {
            switch (Type)
            {
                case SegmentType.HARVEST_DATE: 
                    {
                        if (Raw.Length == 12) 
                        {
                            GetDate(Raw[..6]).GetDate(out DateTime start);
                            GetDate(Raw.Substring(6, 6)).GetDate(out DateTime end);
                            return new SegmentValue(new Period(start, end), SegmentValueType.Period);
                        }
                        return GetDate(Raw);
                    }
                default: return GetDate(Raw);
            }
        }

        private SegmentValue GetDate(string value)
        {
            short year = 0;
            short month = 0;
            short day = 0;
            short hour = 0;
            short minute = 0;
            short second = 0;
            for (int i = 0; i < value.Length; i+=2)
            {
                switch (i) 
                {
                    case 0: 
                        {
                            year = Convert.ToInt16($"20{value[i]}{value[i + 1]}");
                            break;
                        }
                    case 2:
                        {
                            month = Convert.ToInt16($"{value[i]}{value[i + 1]}");
                            break;
                        }
                    case 4:
                        {
                            day = Convert.ToInt16($"{value[i]}{value[i + 1]}");
                            break;
                        }
                    case 6:
                        {
                            hour = Convert.ToInt16($"{value[i]}{value[i + 1]}");
                            break;
                        }
                    case 8:
                        {
                            minute = Convert.ToInt16($"{Raw[i]}{Raw[i + 1]}");
                            break;
                        }
                    case 10:
                        {
                            second = Convert.ToInt16($"{value[i]}{value[i + 1]}");
                            break;
                        }
                }
            }

            DateTime date = new(year, month, day, hour, minute, second);
            if (hour > 0) return new SegmentValue(date, SegmentValueType.DateTime);
            return new SegmentValue(date, SegmentValueType.Date);
            
        }
    }
}
