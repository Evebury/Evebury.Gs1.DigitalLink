using Evebury.Gs1.DigitalLink.Segments;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// TradeItem
    /// </summary>
    public class TradeItem
    {
        /// <summary>
        /// GTIN (= primary key and is required)
        /// </summary>
        public string GTIN { get; set; }

        /// <summary>
        /// Expiration date
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Serial Number
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Batch or Lot Number
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public Price Price { get; set; }

        /// <summary>
        /// Netto Weight
        /// </summary>
        public Weight NetWeight { get; set; }

        /// <summary>
        /// Consumer Product Variant
        /// </summary>
        public string ConsumerVariant { get; set; }

        /// <summary>
        /// Best before date
        /// </summary>
        public DateTime? BestBeforeDate { get; set; }


        /// <summary>
        /// Any other segments
        /// </summary>
        public IReadOnlyList<Segment> Segments { get; private set; } = [];


        internal void SetFields(List<Segment> segments) 
        {
            Segment segment;

            segment = segments.Find(e => e.Type == SegmentType.EXPIRATION_DATE);
            if (segment != null)
            {
                if (segment.Value.GetDate(out DateTime date)) 
                {
                    ExpirationDate = date;
                }
                segments.Remove(segment);
            }

            segment = segments.Find(e => e.Type == SegmentType.SERIAL);
            if (segment != null)
            {
                if (segment.Value.GetString(out string str))
                {
                    SerialNumber = str;
                }
                segments.Remove(segment);
            }

            segment = segments.Find(e => e.Type == SegmentType.PRICE_TRADE_ITEM);
            if (segment != null)
            {
                if (segment.Value.GetPrice(out Price price))
                {
                    Price = price;
                }
                segments.Remove(segment);
            }

            segment = segments.Find(e => e.Type == SegmentType.NET_WEIGHT);
            if (segment != null)
            {
                if (segment.Value.GetWeight(out Weight weight))
                {
                    NetWeight = weight;
                }
                segments.Remove(segment);
            }

            segment = segments.Find(e => e.Type == SegmentType.BATCH_LOT);
            if (segment != null)
            {
                if (segment.Value.GetString(out string str))
                {
                    BatchNumber = str;
                }
                segments.Remove(segment);
            }

            segment = segments.Find(e => e.Type == SegmentType.CPV);
            if (segment != null)
            {
                if (segment.Value.GetString(out string str))
                {
                    ConsumerVariant = str;
                }
                segments.Remove(segment);
            }

            segment = segments.Find(e => e.Type == SegmentType.BEST_BEFORE_DATE);
            if (segment != null)
            {
                if (segment.Value.GetDate(out DateTime date))
                {
                    BestBeforeDate = date;
                }
                segments.Remove(segment);
            }

            Segments = segments;
        }

        internal void AddFields(DigitalLinkBuilder builder) 
        {
            if (ExpirationDate.HasValue) 
            {
                builder.AddDate(DateType.EXPIRATION_DATE, ExpirationDate.Value);
            }

            if (!string.IsNullOrEmpty(SerialNumber)) 
            {
                builder.AddString(StringType.SERIAL, SerialNumber);
            }

            if (!string.IsNullOrEmpty(BatchNumber))
            {
                builder.AddString(StringType.BATCH_LOT, BatchNumber);
            }

            if (Price != null)
            {
                builder.AddPrice(PriceType.PRICE_TRADE_ITEM, Price);
            }

            if (NetWeight != null) 
            {
                builder.AddNetWeight(NetWeight);
            }

            if (!string.IsNullOrEmpty(ConsumerVariant))
            {
                builder.AddString(StringType.CPV, ConsumerVariant);
            }

            if (BestBeforeDate.HasValue)
            {
                builder.AddDate(DateType.BEST_BEFORE_DATE, BestBeforeDate.Value);
            }
        }

        /// <summary>
        /// Output TradeItem as Json
        /// </summary>
        /// <returns></returns>
        public string ToJson() 
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
