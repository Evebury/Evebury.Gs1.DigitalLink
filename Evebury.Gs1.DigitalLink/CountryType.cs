namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Country Segment Type
    /// </summary>
    public enum CountryType : int
    {
        ///<summary>
        ///Ship to / Deliver to postal code with ISO country code
        ///</summary>
        SHIP_TO_POSTALCODE = 421,
        ///<summary>
        ///Number of processor with three-digit ISO country code
        ///</summary>
        PROCESSOR_NUMBER = 7030,
    }


}
