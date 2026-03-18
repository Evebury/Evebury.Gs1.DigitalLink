namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Integer Segment Type
    /// </summary>
    public enum IntegerType
    {
        ///<summary>
        ///Internal product variant
        ///</summary>
        VARIANT = 20,
        ///<summary>
        ///Made-to-Order variation number
        ///</summary>
        MTO_VARIANT = 242,
        ///<summary>
        ///Variable count of items (variable measure trade item)
        ///</summary>
        VARIABLE_COUNT = 30,
        ///<summary>
        ///Count of trade items or trade item pieces contained in a logistic unit
        ///</summary>
        COUNT = 37,
        ///<summary>
        ///Active potency
        ///</summary>
        ACTIVE_POTENCY = 7004,
        ///<summary>
        ///AIDC media type
        ///</summary>
        AIDC_MEDIA_TYPE = 7241,
        ///<summary>
        ///Loyalty points of a coupon
        ///</summary>
        LOYALTY_POINTS = 8111,
        ///<summary>
        ///Price per unit of measure
        ///</summary>
        PRICE_PER_UNIT = 8005,
    }
}
