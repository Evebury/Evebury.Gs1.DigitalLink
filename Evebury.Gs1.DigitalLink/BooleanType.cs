namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Boolean Segment Type
    /// </summary>
    public enum BooleanType : int
    {
        ///<summary>
        ///Dangerous goods flag
        ///</summary>
        DANGEROUS_GOODS = 4321,
        ///<summary>
        ///Authority to leave
        ///</summary>
        AUTHORITY_LEAVE = 4322,
        ///<summary>
        ///Signature required flag
        ///</summary>
        SIGNATURE_REQUIRED = 4323,
    }
}
