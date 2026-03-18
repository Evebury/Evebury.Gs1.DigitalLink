using Evebury.Gs1.DigitalLink.Segments;
using System.Collections.Generic;

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
        /// Concats all segements in one list
        /// </summary>
        /// <returns></returns>
        public List<Segment> Segments() 
        {
            List<Segment> segments = [];
            segments.Add(Primary);
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
    }
}
