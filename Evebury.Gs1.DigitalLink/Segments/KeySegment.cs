namespace Evebury.Gs1.DigitalLink.Segments
{
    internal class KeySegment : Segment
    {
        public KeySegment(DigitalLinkSegment segment) : base(segment)
        {
        }

        public KeySegment(PrimaryType type, string value) : base((int)type)
        {
            SetValue(value);
        }

        public KeySegment(KeyType type, string value) : base((int)type)
        {
            SetValue(value);
        }

        private void SetValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Raw = string.Empty;
                return;
            }

            KeyType type = (KeyType)(int)Type;
            switch (type)
            {
                case KeyType.GTIN:
                case KeyType.GTIN_CONTENT:
                case KeyType.GTIN_MTO:
                    {
                        int length = Descriptor.Captures[0].Length;
                        if (value.Length != length)
                        {
                            value = value.PadLeft(length, '0');
                        }
                        break;
                    }
            }
            Raw = value;
        }


        protected override SegmentValue GetValue()
        {
            return new SegmentValue(Raw, ValueType.String);
        }
    }
}
