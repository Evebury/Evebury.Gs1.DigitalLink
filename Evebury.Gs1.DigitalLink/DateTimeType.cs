namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// DateTime Segement Type
    /// </summary>
    public enum DateTimeType
    {
        ///<summary>
        ///Not before delivery date time (YYMMDDhhmm)
        ///</summary>
        NOT_BEFORE_DELIVERY_DATETIME = 4324,
        ///<summary>
        ///Not after delivery date time (YYMMDDhhmm)
        ///</summary>
        NOT_AFTER_DELIVERY_DATETIME = 4325,
        ///<summary>
        ///Expiration date and time (YYMMDDhhmm)
        ///</summary>
        EXPIRATION_DATETIME = 7003,
        ///<summary>
        ///Test by date (YYMMDD[hhmm])
        ///</summary>
        TEST_BY_DATE = 7011,
        ///<summary>
        ///Date and time of birth (YYYYMMDDhhmm)
        ///</summary>
        DATETIME_OF_BIRTH = 7251,
        ///<summary>
        ///Date and time of production (YYMMDDhh[mm[ss]])
        ///</summary>
        PRODUCTION_DATETIME = 8008,
    }
}
