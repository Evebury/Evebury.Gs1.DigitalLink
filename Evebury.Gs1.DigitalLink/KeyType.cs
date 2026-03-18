namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// Key Segment Type
    /// </summary>
    public enum KeyType 
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
        ///Global Trade Item Number (GTIN) of contained trade items
        ///</summary>
        GTIN_CONTENT = 02,
        ///<summary>
        ///Identification of a Made-to-Order (MtO) trade item (GTIN)
        ///</summary>
        GTIN_MTO = 03,
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
        ///Ship to / Deliver to Global Location Number (GLN)
        ///</summary>
        SHIP_TO_GLN = 410,
        ///<summary>
        ///Bill to / Invoice to Global Location Number (GLN)
        ///</summary>
        BILL_TO_GLN = 411,
        ///<summary>
        ///Purchased from Global Location Number (GLN)
        ///</summary>
        PURCHASE_FROM_GLN = 412,
        ///<summary>
        ///Ship for / Deliver for - Forward to Global Location Number (GLN)
        ///</summary>
        SHIP_FOR_LOC_GLN = 413,
        ///<summary>
        ///Identification of a physical location - Global Location Number (GLN)
        ///</summary>
        LOCATION_GLN = 414,
        ///<summary>
        ///Global Location Number (GLN) of the invoicing party
        ///</summary>
        PAY_TO_GLN = 415,
        ///<summary>
        ///Global Location Number (GLN) of the production or service location
        ///</summary>
        PRODUCTION_SERVICE_LOCATION_GLN = 416,
        ///<summary>
        ///Party Global Location Number (GLN)
        ///</summary>
        PARTY_GLN = 417,
        ///<summary>
        ///Global Individual Asset Identifier (GIAI) of an assembly
        ///</summary>
        ASSEMBLY_GIAI = 7023,
        ///<summary>
        ///Global Returnable Asset Identifier (GRAI)
        ///</summary>
        GRAI = 8003,
        ///<summary>
        ///Global Individual Asset Identifier (GIAI)
        ///</summary>
        GIAI = 8004,
        ///<summary>
        ///Component/Part Identifier (CPID)
        ///</summary>
        CPID = 8010,
        ///<summary>
        ///Global Model Number (GMN)
        ///</summary>
        GMN = 8013,
        ///<summary>
        ///Highly Individualised Device Registration Identifier (HIDRI)
        ///</summary>
        HIDRI = 8014,
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
