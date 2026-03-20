namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Date Segment Type
    /// </summary>
    public enum DateType : int
    {
        ///<summary>
        ///Production date (YYMMDD)
        ///</summary>
        PRODUCTION_DATE = 11,
        ///<summary>
        ///Due date (YYMMDD)
        ///</summary>
        DUE_DATE = 12,
        ///<summary>
        ///Packaging date (YYMMDD)
        ///</summary>
        PACKAGING_DATE = 13,
        ///<summary>
        ///Best before date (YYMMDD)
        ///</summary>
        BEST_BEFORE_DATE = 15,
        ///<summary>
        ///Sell by date (YYMMDD)
        ///</summary>
        SELL_BY_DATE = 16,
        ///<summary>
        ///Expiration date (YYMMDD)
        ///</summary>
        EXPIRATION_DATE = 17,
        ///<summary>
        ///Release date (YYMMDD)
        ///</summary>
        RELEASE_DATE = 4326,
        ///<summary>
        ///First freeze date (YYMMDD)
        ///</summary>
        FIRST_FREEZE_DATE = 7006,
        ///<summary>
        ///Harvest date (YYMMDD[YYMMDD])
        ///</summary>
        HARVEST_DATE = 7007,
        ///<summary>
        ///Test by date (YYMMDD[hhmm])
        ///</summary>
        TEST_BY_DATE = 7011,
        ///<summary>
        ///Date of birth (YYYYMMDD)
        ///</summary>
        DATE_OF_BIRTH = 7250,
    }
}
