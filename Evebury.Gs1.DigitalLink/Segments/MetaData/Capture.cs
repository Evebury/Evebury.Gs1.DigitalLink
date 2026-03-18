using System.Text.Json.Serialization;

namespace Evebury.Gs1.DigitalLink.Segments.MetaData
{
    internal struct Capture(Capture capture, string value)
    {
        [JsonIgnore]
        public string Value { get; set; } = value;

        public bool Fixed { get; set; } = capture.Fixed;

        public int Length { get; set; } = capture.Length;

        public bool CheckDigit { get; set; } = capture.CheckDigit;
    }
}
