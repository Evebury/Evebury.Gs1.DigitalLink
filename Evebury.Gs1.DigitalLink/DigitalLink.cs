using Evebury.Gs1.DigitalLink.Segments;
using System.Collections.Generic;
using System;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Digital Link
    /// </summary>
    public class DigitalLink
    {
        private List<ValidationError> _errors;

        /// <summary>
        /// If false use Uri will be null use <c ref="GetValidationErrors"></c>
        /// </summary>
        public bool IsValid { get; private set; } = true;

        /// <summary>
        /// Uri or Payload of the Digital Link
        /// </summary>
        public string Uri { get; internal set; }

        /// <summary>
        /// Primary Segment
        /// </summary>
        public Segment Primary { get; internal set; }

        /// <summary>
        /// Qualifier Segments
        /// </summary>
        public List<Segment> Qualifiers { get; private set; } = [];

        /// <summary>
        /// Attribute Segments
        /// </summary>
        public List<Segment> Attributes { get; private set; } = [];

        internal DigitalLink() { }

        /// <summary>
        /// Returns segments [qualifiers, attributes] as one list
        /// </summary>
        /// <param name="includePrimary">if true will include primary segment</param>
        /// <returns></returns>
        public List<Segment> Segments(bool includePrimary = false) 
        {
            List<Segment> segments = [];
            if(includePrimary) segments.Add(Primary);
            segments.AddRange(Qualifiers);
            segments.AddRange(Attributes);
            return segments;
        }

        internal void SetErrors(List<ValidationError> errors) 
        {
            _errors = errors;
            IsValid = errors.Count == 0;
            if (!IsValid) 
            {
                Uri = null;
                Primary = null;
                Qualifiers.Clear();
                Attributes.Clear();
            }
        }

        /// <summary>
        /// If IsValid = false returns a list of all validation errors
        /// </summary>
        /// <returns></returns>
        public List<ValidationError> GetValidationErrors() 
        {
            if (_errors == null) return [];
            return _errors;
        }

        /// <summary>
        /// Gets a TradeItem object
        /// </summary>
        /// <returns>null if primary not set to type GTIN</returns>
        /// <exception cref="InvalidOperationException">if link is invalid</exception>
        public TradeItem GetTradeItem() 
        {
            if (!IsValid) throw new InvalidOperationException("Digital Link is not valid");
            if(Primary.Type != SegmentType.GTIN) return null;

            Primary.Value.GetKey(out string gtin);
            TradeItem tradeItem = new()
            {
                GTIN = gtin
            };
            tradeItem.SetFields(Segments());
            return tradeItem;
        }
    }
}
