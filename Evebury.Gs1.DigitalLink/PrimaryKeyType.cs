namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Primary Segment Type
    /// </summary>
    public enum PrimaryKeyType : int
    {
        ///<summary>
        ///Serial Shipping Container Code (SSCC)
        ///</summary>
        SSCC = 00,
        ///<summary>
        ///Global Trade Item Number (GTIN)
        ///</summary>
        GTIN = 01,
        ///<summary>
        ///Global Document Type Identifier (GDTI)
        ///</summary>
        GDTI = 253,
        ///<summary>
        ///Global Coupon Number (GCN)
        ///</summary>
        GCN = 255,
        ///<summary>
        ///Global Identification Number for Consignment (GINC)
        ///</summary>
        GINC = 401,
        ///<summary>
        ///Global Shipment Identification Number (GSIN)
        ///</summary>
        GSIN = 402,
        ///<summary>
        ///Identification of a physical location - Global Location Number (GLN)
        ///</summary>
        LOCATION_GLN = 414,
        ///<summary>
        ///Global Location Number (GLN) of the invoicing party
        ///</summary>
        PAY_TO_GLN = 415,
        ///<summary>
        ///Party Global Location Number (GLN)
        ///</summary>
        PARTY_GLN = 417,
        ///<summary>
        ///Global Returnable Asset Identifier (GRAI)
        ///</summary>
        GRAI = 8003,
        ///<summary>
        ///Global Individual Asset Identifier (GIAI)
        ///</summary>
        GIAI = 8004,
        ///<summary>
        ///Identification of an individual trade item piece (ITIP)
        ///</summary>
        ITIP = 8006,
        ///<summary>
        ///Component/Part Identifier (CPID)
        ///</summary>
        CPID = 8010,
        ///<summary>
        ///Global Model Number (GMN)
        ///</summary>
        GMN = 8013,
        ///<summary>
        ///Global Service Relation Number (GSRN) to identify the relationship between an organisation offering services and the provider of services
        ///</summary>
        GSRN_PROVIDER = 8017,
        ///<summary>
        ///Global Service Relation Number (GSRN) to identify the relationship between an organisation offering services and the recipient of services
        ///</summary>
        GSRN_RECIPIENT = 8018,

    }
}
