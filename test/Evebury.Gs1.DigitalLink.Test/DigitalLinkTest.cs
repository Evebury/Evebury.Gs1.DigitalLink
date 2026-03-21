using Evebury.Gs1.DigitalLink.Segments;

namespace Evebury.Gs1.DigitalLink.Test
{
    [TestClass]
    public sealed class DigitalLinkTest
    {
        public const string GTIN = "00074562000525";

        [TestMethod]
        public void SetPrimaryKey()
        {
            DigitalLinkBuilder builder = GetBuilder();
            DigitalLink link = builder.Build();
            Assert.Contains(GTIN, link.Uri);
        }

        [TestMethod]
        public void SetCustomDomainUri()
        {
            DigitalLinkBuilder builder = GetBuilder();
            builder.SetCustomDomainUri("https://www.evebury.com");
            DigitalLink link = builder.Build();
            Assert.StartsWith("https://www.evebury.com", link.Uri);
        }

        [TestMethod]
        public void SetTradeItem()
        {
            DigitalLinkBuilder builder = new();

            TradeItem tradeItem = new()
            {
                GTIN = GTIN,
                SerialNumber = "123456",
                ExpirationDate = DateTime.Now.Date,
                NetWeight = new(0.3, WeightUnit.KILOGRAM),
                Price = new(28, 2, CurrencyCode.EUR),
            };
            builder.SetTradeItem(tradeItem);
            DigitalLink link = builder.Build();

            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            TradeItem resolvedTradeItem = resolved.GetTradeItem();

            Assert.AreEqual(tradeItem.GTIN, resolvedTradeItem.GTIN);
            Assert.AreEqual(tradeItem.SerialNumber, resolvedTradeItem.SerialNumber);
            Assert.AreEqual(tradeItem.ExpirationDate, resolvedTradeItem.ExpirationDate);
            Assert.AreEqual(tradeItem.NetWeight.Value, resolvedTradeItem.NetWeight.Value);
            Assert.AreEqual(tradeItem.NetWeight.Unit, resolvedTradeItem.NetWeight.Unit);
            Assert.AreEqual(tradeItem.Price.Value, resolvedTradeItem.Price.Value);
            Assert.AreEqual(tradeItem.Price.Unit, resolvedTradeItem.Price.Unit);
        }

        [TestMethod]
        public void AddKey()
        {
            DigitalLinkBuilder builder = GetBuilder();
            builder.AddKey(KeyType.GTIN, GTIN);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.GTIN);
            if (segment != null)
            {
                if (segment.Value.GetKey(out string value))
                {
                    test = value == GTIN;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddDate()
        {
            DigitalLinkBuilder builder = GetBuilder();
            DateTime source = DateTime.Now.Date;
            builder.AddDate(DateType.EXPIRATION_DATE, source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.EXPIRATION_DATE);
            if (segment != null)
            {
                if (segment.Value.GetDate(out DateTime value))
                {
                    test = value == source;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddDateTime()
        {
            DigitalLinkBuilder builder = GetBuilder();
            DateTime now = DateTime.Now;
            DateTime source = new(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            builder.AddDateTime(DateTimeType.PRODUCTION_DATETIME, source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.PRODUCTION_DATETIME);
            if (segment != null)
            {
                if (segment.Value.GetDateTime(out DateTime value))
                {
                    test = value == source;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddPeriod()
        {
            DigitalLinkBuilder builder = GetBuilder();
            DateTime now = DateTime.Now.Date;
            Period source = new(now, now.AddDays(1));
            builder.AddPeriod(PeriodType.HARVEST_DATE, source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.HARVEST_DATE);
            if (segment != null)
            {
                if (segment.Value.GetPeriod(out Period value))
                {
                    test = value.Start == source.Start && value.End == source.End;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddWeight()
        {
            //methods AddNetweight, AddLogisticGrossWeight and AddKilogramPerSquareMeter all use WeightSegment
            DigitalLinkBuilder builder = GetBuilder();
            Weight source = new(0.3, WeightUnit.KILOGRAM);
            builder.AddNetWeight(source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.NET_WEIGHT);
            if (segment != null)
            {
                if (segment.Value.GetWeight(out Weight value))
                {
                    test = value.Value == source.Value && value.Unit == source.Unit && value.Format == source.Format;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddLength()
        {
            //methods AddLength, AddLogisticLength all use LengthSegment
            DigitalLinkBuilder builder = GetBuilder();
            Length source = new(0.3, LengthUnit.INCH);
            builder.AddLength(LengthType.LENGTH, source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.LENGTH);
            if (segment != null)
            {
                if (segment.Value.GetLength(out Length value))
                {
                    test = value.Value == source.Value && value.Unit == source.Unit && value.Format == source.Format;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddVolume()
        {
            //methods AddNetVolume, AddLogisticVolume all use VolumeSegment
            DigitalLinkBuilder builder = GetBuilder();
            Volume source = new(0.3, VolumeUnit.GALLONS);
            builder.AddNetVolume(source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.NET_VOLUME);
            if (segment != null)
            {
                if (segment.Value.GetVolume(out Volume value))
                {
                    test = value.Value == source.Value && value.Unit == source.Unit && value.Format == source.Format;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddPrice()
        {
            //methods AddNetVolume, AddLogisticVolume all use VolumeSegment
            DigitalLinkBuilder builder = GetBuilder();
            Price source = new(3, 2, CurrencyCode.EUR);

            builder.AddNetWeight(new Weight(0.3, WeightUnit.KILOGRAM));//required for price
            builder.AddPrice(PriceType.PRICE_TRADE_ITEM, source);

            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.PRICE_TRADE_ITEM);
            if (segment != null)
            {
                if (segment.Value.GetPrice(out Price value))
                {
                    test = value.Value == source.Value && value.Unit == source.Unit && value.Format == source.Format;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddTemperature()
        {
            //methods AddNetVolume, AddLogisticVolume all use VolumeSegment
            DigitalLinkBuilder builder = GetBuilder();
            builder.AddKey(KeyType.SSCC, "0000" + GTIN); //requires SSCC
            Temperature source = new(-6.3d, TemperatureUnit.CELSIUS);
            builder.AddMinimumTemperature(source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.MINIMUM_TEMPERATURE);
            if (segment != null)
            {
                if (segment.Value.GetTemperature(out Temperature value))
                {
                    test = value.Value == source.Value && value.Unit == source.Unit && value.Format == source.Format;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddString()
        {
            DigitalLinkBuilder builder = GetBuilder();
            string source = "some/value";
            builder.AddString(StringType.INTERNAL_COMPANY, source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.INTERNAL_COMPANY);
            if (segment != null)
            {
                if (segment.Value.GetString(out string value))
                {
                    test = value == source;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddInteger()
        {
            DigitalLinkBuilder builder = GetBuilder();
            int source = 123;
            builder.AddInteger(IntegerType.VARIANT, source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.VARIANT);
            if (segment != null)
            {
                if (segment.Value.GetInteger(out int value))
                {
                    test = value == source;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddDouble()
        {
            DigitalLinkBuilder builder = GetBuilder();
            double source = 1.23;
            builder.AddInteger(IntegerType.VARIABLE_COUNT, 1); //required
            builder.AddDouble(DoubleType.PRICE_LOCAL_TRADE_ITEM, source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.PRICE_LOCAL_TRADE_ITEM);
            if (segment != null)
            {
                if (segment.Value.GetDouble(out Double value))
                {
                    test = value.Value == source;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddBoolean()
        {
            DigitalLinkBuilder builder = GetBuilder();
            bool source = true;
            builder.AddKey(KeyType.SSCC, "0000" + GTIN); //requires SSCC
            builder.AddBoolean(BooleanType.DANGEROUS_GOODS, source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.DANGEROUS_GOODS);
            if (segment != null)
            {
                if (segment.Value.GetBoolean(out bool value))
                {
                    test = value == source;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddCountryCode()
        {
            DigitalLinkBuilder builder = GetBuilder();
            List<CountryCode> source = [];
            source.Add(CountryCode.NL);
            source.Add(CountryCode.AF);

            builder.AddCountry(CountryCodeType.COUNTRY_PROCESS, source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.COUNTRY_PROCESS);
            if (segment != null)
            {
                if (segment.Value.GetCountryCodes(out List<CountryCode> value))
                {
                    if (source.Count == value.Count)
                    {
                        test = value.Contains(CountryCode.NL) && value.Contains(CountryCode.AF);
                    }
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddCountry()
        {
            DigitalLinkBuilder builder = GetBuilder();
            Country source = new(CountryCode.NL, "A nice country");

            builder.AddCountryWithValue(CountryType.PROCESSOR_NUMBER, source.Code, source.Value);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.PROCESSOR_NUMBER);
            if (segment != null)
            {
                if (segment.Value.GetCountry(out Country value))
                {
                    test = value.Code == source.Code && value.Value == source.Value;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddGender()
        {
            DigitalLinkBuilder builder = GetBuilder();
            GenderCode source = GenderCode.Female;
            builder.AddKey(KeyType.GSRN_RECIPIENT, "0000" + GTIN);
            builder.AddGender(source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.BIOLOGICAL_SEX);
            if (segment != null)
            {
                if (segment.Value.GetGender(out GenderCode value))
                {
                    test = value == source;
                }
            }
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddRoll()
        {
            DigitalLinkBuilder builder = GetBuilder();
            Roll source = new(20, 30, 40, Winding.FACE_OUT, Splice.SPLICE_3);
            builder.AddRoll(source);
            DigitalLink link = builder.Build();

            bool test = false;
            DigitalLink resolved = DigitalLinkResolver.Resolve(link.Uri);
            Segment segment = resolved.Segments().First(e => e.Type == SegmentType.ROLL_PRODUCT);
            if (segment != null)
            {
                if (segment.Value.GetRoll(out Roll value))
                {
                    test = value.Diameter == source.Diameter && value.Splices == source.Splices && value.SlitWidth == source.SlitWidth && value.Length == source.Length && value.Winding == source.Winding;
                }
            }
            Assert.IsTrue(test);
        }


        private static DigitalLinkBuilder GetBuilder()
        {
            DigitalLinkBuilder builder = new();
            builder.SetPrimaryKey(PrimaryKeyType.GTIN, GTIN);
            return builder;
        }
    }
}
