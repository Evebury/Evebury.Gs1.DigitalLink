using Evebury.Gs1.DigitalLink.Segments;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Validation Error
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Error Message
        /// </summary>
        public string Message { get; private set; }

        internal ValidationError(string message, Segment segment = null) 
        {
            Message = message;
            if (segment != null)
            {
                Message = $"{message} Segment: {segment.Type} - {segment.Descriptor.Label}.";
            }
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>Message</returns>
        public override string ToString()
        {
            return Message;
        }
    }
}
