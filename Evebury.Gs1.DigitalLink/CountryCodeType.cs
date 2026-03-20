namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Country Code Segment Type
    /// </summary>
    public enum CountryCodeType : int
    {
        ///<summary>
        ///Country of origin of a trade item
        ///</summary>
        COUNTRY_OF_ORIGIN = 422,
        ///<summary>
        ///Country of initial processing
        ///</summary>
        COUNTRY_INITIAL_PROCESS = 423,
        ///<summary>
        ///Country of processing
        ///</summary>
        COUNTRY_PROCESS = 424,
        ///<summary>
        ///Country of disassembly
        ///</summary>
        COUNTRY_DISASSEMBLY = 425,
        ///<summary>
        ///Country covering full process chain
        ///</summary>
        COUNTRY_FULL_PROCESS = 426,
        ///<summary>
        ///Ship-to / Deliver-to country code
        ///</summary>
        SHIP_TO_COUNTRY = 4307,
    }


}
