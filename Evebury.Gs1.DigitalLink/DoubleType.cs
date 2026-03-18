namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Double Segment Type
    /// </summary>
    public enum DoubleType
    {
        ///<summary>
        ///Applicable amount payable or Coupon value, local currency
        ///</summary>
        PRICE_LOCAL = 3900,
        ///<summary>
        ///Applicable amount payable, single monetary area (variable measure trade item)
        ///</summary>
        PRICE_LOCAL_TRADE_ITEM = 3920,
        ///<summary>
        ///Percentage discount of a coupon
        ///</summary>
        PERCENTAGE_OFF = 3940,
        ///<summary>
        ///Amount Payable per unit of measure single monetary area (variable measure trade item)
        ///</summary>
        PRICE_UOM = 3950,
    }
}
