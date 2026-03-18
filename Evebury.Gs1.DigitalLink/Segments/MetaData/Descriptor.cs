using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Evebury.Gs1.DigitalLink.Segments.MetaData
{
    internal class Descriptor
    {
        [JsonIgnore]
        public SegmentType Type { get; private set; }

        public string Label { get; set; }

        /// <summary>
        /// Can be included as an attribute
        /// </summary>
        public bool Attribute { get; set; }

        public HashSet<string> Qualifiers { get; set; } = [];

        public HashSet<string> Requires { get; set; } = [];

        public HashSet<string> Excludes { get; set; } = [];

        public int MaxElements { get; set; }

        public string Regex { get; set; }

        public List<Capture> Captures { get; set; } = [];

        public bool Validate(Segment segment, string value, out List<Capture> captures, out ValidationError error)
        {
            captures = null;
            error = null;

            Regex regex = new(Regex);
            Match match = regex.Match(value);
            if (match.Success)
            {
                captures = [];
                //skip group 0 as it always the match.Value
                for (int i = 1; i < match.Groups.Count; i++)
                {
                    System.Text.RegularExpressions.Capture regexCapture = match.Groups[i];
                    string matched = regexCapture.Value;
                    if (!string.IsNullOrEmpty(matched))
                    {
                        Capture capture = Captures[i - 1];
                        if (capture.CheckDigit) 
                        {
                            if (IsInvalidCheckDigit(matched))
                            {
                                error = new($"Value '{matched}' does not have a valid check digit.", segment);
                                return false;
                            }
                        }
                        captures.Add(new Capture(Captures[i - 1], matched));
                    }
                }
                return true;
            }

            error = new($"Value does not comply to regex '{Regex}'", segment);
            return false;

        }

        private static bool IsInvalidCheckDigit(string checkDigit)
        {
            if (string.IsNullOrEmpty(checkDigit)) return true;
            List<int> digits = [];
            for (int i = 0; i < checkDigit.Length; i++)
            {
                char @char = checkDigit[i];
                if (!char.IsDigit(@char)) return true;
                digits.Add(Convert.ToInt16($"{@char}"));
            }
            int sum = digits.Take(digits.Count - 1).Reverse().Select((t, i) => t * ((i % 2) > 0 ? 1 : 3)).Sum();
            int lastDigit = (sum % 10 > 0) ? 10 - sum % 10 : 0;
            return !(lastDigit == digits.Last());
        }

        public static Descriptor Load(SegmentType type)
        {
            string json = Resource.Descriptor.ResourceManager.GetString($"D{type.ToCode()}");
            Descriptor descriptor = JsonSerializer.Deserialize<Descriptor>(json);
            descriptor.Type = type;
            return descriptor;
        }
    }
}
