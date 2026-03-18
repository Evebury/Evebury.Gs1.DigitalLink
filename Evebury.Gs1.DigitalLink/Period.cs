using System;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Date period
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public struct Period(DateTime start, DateTime end)
    {
        /// <summary>
        /// Start date
        /// </summary>
        public DateTime Start { get; private set; } = start;

        /// <summary>
        /// End date
        /// </summary>
        public DateTime End { get; private set; } = end;
    }
}
