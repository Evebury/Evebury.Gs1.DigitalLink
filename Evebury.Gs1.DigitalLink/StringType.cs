namespace Evebury.Gs1.DigitalLink
{
    /// <summary>
    /// String Segment Type
    /// </summary>
    public enum StringType
    {
        ///<summary>
        ///Batch or lot number
        ///</summary>
        BATCH_LOT = 10,
        ///<summary>
        ///Serial number
        ///</summary>
        SERIAL = 21,
        ///<summary>
        ///Consumer product variant
        ///</summary>
        CPV = 22,
        ///<summary>
        ///Third Party Controlled, Serialised Extension of Global Trade Item Number (GTIN) (TPX)
        ///</summary>
        TPX = 235,
        ///<summary>
        ///Additional product identification assigned by the manufacturer
        ///</summary>
        ADDITIONAL_ID = 240,
        ///<summary>
        ///Customer part number
        ///</summary>
        CUSTOMER_PART_NUMBER = 241,
        ///<summary>
        ///Packaging component number
        ///</summary>
        PCN = 243,
        ///<summary>
        ///Secondary serial number
        ///</summary>
        SECONDARY_SERIAL = 250,
        ///<summary>
        ///Reference to source entity
        ///</summary>
        REF_TO_SOURCE = 251,
        ///<summary>
        ///Global Location Number (GLN) extension component
        ///</summary>
        EXTENSION_COMPONENT_GLN = 254,
        ///<summary>
        ///Customers purchase order number
        ///</summary>
        ORDER_NUMBER = 400,
        ///<summary>
        ///Routing code
        ///</summary>
        ROUTE = 403,
        ///<summary>
        ///Ship to / Deliver to postal code within a single postal authority
        ///</summary>
        SHIP_TO_POSTALCODE_LOCAL = 420,
        ///<summary>
        ///Country subdivision Of origin
        ///</summary>
        ORIGIN_SUBDIVISION = 427,
        ///<summary>
        ///Ship-to / Deliver-to company name
        ///</summary>
        SHIP_TO_COMPANY = 4300,
        ///<summary>
        ///Ship-to / Deliver-to contact
        ///</summary>
        SHIP_TO_NAME = 4301,
        ///<summary>
        ///Ship-to / Deliver-to address line 1
        ///</summary>
        SHIP_TO_ADDRESS1 = 4302,
        ///<summary>
        ///Ship-to / Deliver-to address line 2
        ///</summary>
        SHIP_TO_ADDRESS2 = 4303,
        ///<summary>
        ///Ship-to / Deliver-to suburb
        ///</summary>
        SHIP_TO_SUBURB = 4304,
        ///<summary>
        ///Ship-to / Deliver-to locality
        ///</summary>
        SHIP_TO_LOCALITY = 4305,
        ///<summary>
        ///Ship-to / Deliver-to region
        ///</summary>
        SHIP_TO_REGION = 4306,
        ///<summary>
        ///Ship-to / Deliver-to country code
        ///</summary>
        SHIP_TO_COUNTRY = 4307,
        ///<summary>
        ///Ship-to / Deliver-to telephone number
        ///</summary>
        SHIP_TO_PHONE = 4308,
        ///<summary>
        ///Ship-to / Deliver-to GEO location
        ///</summary>
        SHIP_TO_GEO_LOCATION = 4309,
        ///<summary>
        ///Return-to company name
        ///</summary>
        RETURN_TO_COMPANY = 4310,
        ///<summary>
        ///Return-to contact
        ///</summary>
        RETURN_TO_NAME = 4311,
        ///<summary>
        ///Return-to address line 1
        ///</summary>
        RETURN_TO_ADDRESS1 = 4312,
        ///<summary>
        ///Return-to address line 2
        ///</summary>
        RETURN_TO_ADDRESS2 = 4313,
        ///<summary>
        ///Return-to suburb
        ///</summary>
        RETURN_TO_SUBURB = 4314,
        ///<summary>
        ///Return-to locality
        ///</summary>
        RETURN_TO_LOCALITY = 4315,
        ///<summary>
        ///Return-to region
        ///</summary>
        RETURN_TO_REGION = 4316,
        ///<summary>
        ///Return-to country code
        ///</summary>
        RETURN_TO_COUNTRY = 4317,
        ///<summary>
        ///Return-to postal code
        ///</summary>
        RETURN_TO_POSTALCODE = 4318,
        ///<summary>
        ///Return-to telephone number
        ///</summary>
        RETURN_TO_PHONE = 4319,
        ///<summary>
        ///Service code description
        ///</summary>
        SERVICE_DESCRIPTION = 4320,
        ///<summary>
        ///NATO Stock Number (NSN)
        ///</summary>
        NSN = 7001,
        ///<summary>
        ///UN/ECE meat carcasses and cuts classification
        ///</summary>
        MEAT_CUT_UN_ECE = 7002,
        ///<summary>
        ///Catch area
        ///</summary>
        CATCH_AREA = 7005,
        ///<summary>
        ///Species for fishery purposes
        ///</summary>
        AQUATIC_SPECIES = 7008,
        ///<summary>
        ///Fishing gear type
        ///</summary>
        FISHING_GEAR_TYPE = 7009,
        ///<summary>
        ///Production method
        ///</summary>
        PRODUCTION_METHOD = 7010,
        ///<summary>
        ///Refurbishment lot ID
        ///</summary>
        REFURBISHMENT_LOT = 7020,
        ///<summary>
        ///Functional status
        ///</summary>
        FUNCTIONAL_STATUS = 7021,
        ///<summary>
        ///Revision status
        ///</summary>
        REVISION_STATUS = 7022,
        ///<summary>
        ///GS1 UIC with Extension 1 and Importer index
        ///</summary>
        UIC_EXTENSION = 7040,
        ///<summary>
        ///UN/CEFACT freight unit type
        ///</summary>
        FREIGHT_UNIT_TYPE_UN_CEFACT = 7041,
        ///<summary>
        ///National Healthcare Reimbursement Number (NHRN) - Germany PZN
        ///</summary>
        NATIONAL_HEALTH_CARE_REIMBURSEMENT_NUMBER_PZN = 710,
        ///<summary>
        ///National Healthcare Reimbursement Number (NHRN) - France CIP
        ///</summary>
        NATIONAL_HEALTH_CARE_REIMBURSEMENT_NUMBER_CIP = 711,
        ///<summary>
        ///National Healthcare Reimbursement Number (NHRN) - Spain CN
        ///</summary>
        NATIONAL_HEALTH_CARE_REIMBURSEMENT_NUMBER_CN = 712,
        ///<summary>
        ///National Healthcare Reimbursement Number (NHRN) - Brasil DRN
        ///</summary>
        NATIONAL_HEALTH_CARE_REIMBURSEMENT_NUMBER_DRN = 713,
        ///<summary>
        ///National Healthcare Reimbursement Number (NHRN) - Portugal AIM
        ///</summary>
        NATIONAL_HEALTH_CARE_REIMBURSEMENT_NUMBER_AIM = 714,
        ///<summary>
        ///National Healthcare Reimbursement Number (NHRN) - United States of America NDC
        ///</summary>
        NATIONAL_HEALTH_CARE_REIMBURSEMENT_NUMBER_NDC = 715,
        ///<summary>
        ///National Healthcare Reimbursement Number (NHRN) - Italy AIC
        ///</summary>
        NATIONAL_HEALTH_CARE_REIMBURSEMENT_NUMBER_AIC = 716,
        ///<summary>
        ///National Healthcare Reimbursement Number (NHRN) - Costa Rica Sanitary Register Number
        ///</summary>
        NATIONAL_HEALTH_CARE_REIMBURSEMENT_NUMBER_SRN = 717,
        ///<summary>
        ///Certification Reference
        ///</summary>
        CERTIFICATE = 7230,
        ///<summary>
        ///Protocol ID
        ///</summary>
        PROTOCOL = 7240,
        ///<summary>
        ///Version Control Number (VCN)
        ///</summary>
        VCN = 7242,
        ///<summary>
        ///Family name of person
        ///</summary>
        FAMILY_NAME = 7253,
        ///<summary>
        ///Given name of person
        ///</summary>
        GIVEN_NAME = 7254,
        ///<summary>
        ///Name suffix of person
        ///</summary>
        NAME_SUFFIX = 7255,
        ///<summary>
        ///Full name of person
        ///</summary>
        FULL_NAME = 7256,
        ///<summary>
        ///Address of person
        ///</summary>
        PERSON_ADDRESS = 7257,
        ///<summary>
        ///Baby birth sequence
        ///</summary>
        BIRTH_SEQUENCE = 7258,
        ///<summary>
        ///Baby of family name
        ///</summary>
        BABY_NAME = 7259,
        ///<summary>
        ///Cellular mobile telephone identifier
        ///</summary>
        CELLULAR_MOBILE_TELEPHONE = 8002,
        ///<summary>
        ///Identification of an individual trade item piece (ITIP)
        ///</summary>
        ITIP = 8006,
        ///<summary>
        ///International Bank Account Number (IBAN)
        ///</summary>
        IBAN = 8007,
        ///<summary>
        ///Optically Readable Sensor Indicator
        ///</summary>
        OPTSEN = 8009,
        ///<summary>
        ///Component/Part Identifier serial number (CPID SERIAL)
        ///</summary>
        CPID_SERIAL = 8011,
        ///<summary>
        ///Software version
        ///</summary>
        VERSION = 8012,
        ///<summary>
        ///Service Relation Instance Number (SRIN)
        ///</summary>
        SRIN = 8019,
        ///<summary>
        ///Payment slip reference number
        ///</summary>
        PAYMENT_REFERENCE = 8020,
        ///<summary>
        ///Identification of pieces of a trade item (ITIP) contained in a logistic unit
        ///</summary>
        ITIP_CONTENT = 8026,
        ///<summary>
        ///Digital Signature (DigSig)
        ///</summary>
        DIGSIG = 8030,
        ///<summary>
        ///Internatinal Mobile Equipment Identity (IMEI)
        ///</summary>
        IMEI = 8040,
        ///<summary>
        ///Internatinal Mobile Equipment Identity 2 (IMEI2)
        ///</summary>
        IMEI2 = 8041,
        ///<summary>
        ///Embedded SIM number
        ///</summary>
        ESIM = 8042,
        ///<summary>
        ///Physical SIM number
        ///</summary>
        PSIM = 8043,
        ///<summary>
        ///Coupon code identification for use in North America
        ///</summary>
        COUPON_CODE = 8110,
        ///<summary>
        ///Positive offer file coupon code identification for use in North America
        ///</summary>
        POSITIVE_OFFER_COUPON_CODE = 8112,
        ///<summary>
        ///Extended Packaging URL
        ///</summary>
        PRODUCT_URL = 8200,
        ///<summary>
        ///Information mutually agreed between trading partners
        ///</summary>
        INTERNAL_TRADEPARTNER = 90,
        ///<summary>
        ///Company internal information
        ///</summary>
        INTERNAL_COMPANY = 91,

    }
}
