namespace Evebury.Gs1.DigitalLink.Segments
{
    /// <summary>
    /// Segment Type
    /// </summary>
    public enum SegmentType
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
        ///Batch or lot number
        ///</summary>
        BATCH_LOT = 10,
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
        ///Internal product variant
        ///</summary>
        VARIANT = 20,
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
        ///Made-to-Order variation number
        ///</summary>
        MTO_VARIANT = 242,
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
        ///Global Document Type Identifier (GDTI)
        ///</summary>
        GDTI = 253,
        ///<summary>
        ///Global Location Number (GLN) extension component
        ///</summary>
        EXTENSION_COMPONENT_GLN = 254,
        ///<summary>
        ///Global Coupon Number (GCN)
        ///</summary>
        GCN = 255,
        ///<summary>
        ///Variable count of items (variable measure trade item)
        ///</summary>
        VARIABLE_COUNT = 30,
        ///<summary>
        ///Net weight (variable measure trade item)
        ///</summary>
        NET_WEIGHT = 3100,
        ///<summary>
        ///Length or first dimension (variable measure trade item)
        ///</summary>
        LENGTH = 3110,
        ///<summary>
        ///Width, diameter, or second dimension (variable measure trade item)
        ///</summary>
        WIDTH = 3120,
        ///<summary>
        ///Depth, thickness, height, or third dimension (variable measure trade item)
        ///</summary>
        HEIGHT = 3130,
        ///<summary>
        ///Area (variable measure trade item)
        ///</summary>
        AREA = 3140,
        ///<summary>
        ///Net volume (variable measure trade item)
        ///</summary>
        NET_VOLUME = 3150,
        ///<summary>
        ///Logistic weight
        ///</summary>
        LOGISTIC_GROSS_WEIGHT = 3300,
        ///<summary>
        ///Length or first dimension
        ///</summary>
        LOGISTIC_LENGTH = 3310,
        ///<summary>
        ///Width, diameter, or second dimension
        ///</summary>
        LOGISTIC_WIDTH = 3320,
        ///<summary>
        ///Depth, thickness, height, or third dimension
        ///</summary>
        LOGISTIC_HEIGHT = 3330,
        ///<summary>
        ///Area
        ///</summary>
        LOGISTIC_AREA = 3340,
        ///<summary>
        ///Logistic volume
        ///</summary>
        LOGISTIC_VOLUME = 3350,
        ///<summary>
        ///Kilograms per square metre
        ///</summary>
        KG_PER_SQUARE_METRE = 3370,
        ///<summary>
        ///Count of trade items or trade item pieces contained in a logistic unit
        ///</summary>
        COUNT = 37,
        ///<summary>
        ///Applicable amount payable or Coupon value, local currency
        ///</summary>
        PRICE_LOCAL = 3900,
        ///<summary>
        ///Applicable amount payable with ISO currency code
        ///</summary>
        PRICE = 3910,
        ///<summary>
        ///Applicable amount payable, single monetary area (variable measure trade item)
        ///</summary>
        PRICE_LOCAL_TRADE_ITEM = 3920,
        ///<summary>
        ///Applicable amount payable with ISO currency code (variable measure trade item)
        ///</summary>
        PRICE_TRADE_ITEM = 3930,
        ///<summary>
        ///Percentage discount of a coupon
        ///</summary>
        PERCENTAGE_OFF = 3940,
        ///<summary>
        ///Amount Payable per unit of measure single monetary area (variable measure trade item)
        ///</summary>
        PRICE_UOM = 3950,
        ///<summary>
        ///Customers purchase order number
        ///</summary>
        ORDER_NUMBER = 400,
        ///<summary>
        ///Global Identification Number for Consignment (GINC)
        ///</summary>
        GINC = 401,
        ///<summary>
        ///Global Shipment Identification Number (GSIN)
        ///</summary>
        GSIN = 402,
        ///<summary>
        ///Routing code
        ///</summary>
        ROUTE = 403,
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
        ///Ship to / Deliver to postal code within a single postal authority
        ///</summary>
        SHIP_TO_POSTALCODE_LOCAL = 420,
        ///<summary>
        ///Ship to / Deliver to postal code with ISO country code
        ///</summary>
        SHIP_TO_POSTALCODE = 421,
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
        ///<summary>
        ///Not before delivery date time (YYMMDDhhmm)
        ///</summary>
        NOT_BEFORE_DELIVERY_DATETIME = 4324,
        ///<summary>
        ///Not after delivery date time (YYMMDDhhmm)
        ///</summary>
        NOT_AFTER_DELIVERY_DATETIME = 4325,
        ///<summary>
        ///Release date (YYMMDD)
        ///</summary>
        RELEASE_DATE = 4326,
        ///<summary>
        ///Maximum temperature (expressed in hundredths of degrees)
        ///</summary>
        MAXIMUM_TEMPERATURE = 4330,
        ///<summary>
        ///Minimum temperature (expressed in hundredths of degrees)
        ///</summary>
        MINIMUM_TEMPERATURE = 4333,
        ///<summary>
        ///NATO Stock Number (NSN)
        ///</summary>
        NSN = 7001,
        ///<summary>
        ///UN/ECE meat carcasses and cuts classification
        ///</summary>
        MEAT_CUT_UN_ECE = 7002,
        ///<summary>
        ///Expiration date and time (YYMMDDhhmm)
        ///</summary>
        EXPIRATION_DATETIME = 7003,
        ///<summary>
        ///Active potency
        ///</summary>
        ACTIVE_POTENCY = 7004,
        ///<summary>
        ///Catch area
        ///</summary>
        CATCH_AREA = 7005,
        ///<summary>
        ///First freeze date (YYMMDD)
        ///</summary>
        FIRST_FREEZE_DATE = 7006,
        ///<summary>
        ///Harvest date (YYMMDD[YYMMDD])
        ///</summary>
        HARVEST_DATE = 7007,
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
        ///Test by date (YYMMDD[hhmm])
        ///</summary>
        TEST_BY_DATE = 7011,
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
        ///Global Individual Asset Identifier (GIAI) of an assembly
        ///</summary>
        ASSEMBLY_GIAI = 7023,
        ///<summary>
        ///Number of processor with three-digit ISO country code
        ///</summary>
        PROCESSOR_NUMBER = 7030,
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
        ///AIDC media type
        ///</summary>
        AIDC_MEDIA_TYPE = 7241,
        ///<summary>
        ///Version Control Number (VCN)
        ///</summary>
        VCN = 7242,
        ///<summary>
        ///Date of birth (YYYYMMDD)
        ///</summary>
        DATE_OF_BIRTH = 7250,
        ///<summary>
        ///Date and time of birth (YYYYMMDDhhmm)
        ///</summary>
        DATETIME_OF_BIRTH = 7251,
        ///<summary>
        ///Biological sex
        ///</summary>
        BIOLOGICAL_SEX = 7252,
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
        ///Roll products (width, length, core diameter, direction, splices)
        ///</summary>
        ROLL_PRODUCT = 8001,
        ///<summary>
        ///Cellular mobile telephone identifier
        ///</summary>
        CELLULAR_MOBILE_TELEPHONE = 8002,
        ///<summary>
        ///Global Returnable Asset Identifier (GRAI)
        ///</summary>
        GRAI = 8003,
        ///<summary>
        ///Global Individual Asset Identifier (GIAI)
        ///</summary>
        GIAI = 8004,
        ///<summary>
        ///Price per unit of measure
        ///</summary>
        PRICE_PER_UNIT = 8005,
        ///<summary>
        ///Identification of an individual trade item piece (ITIP)
        ///</summary>
        ITIP = 8006,
        ///<summary>
        ///International Bank Account Number (IBAN)
        ///</summary>
        IBAN = 8007,
        ///<summary>
        ///Date and time of production (YYMMDDhh[mm[ss]])
        ///</summary>
        PRODUCTION_DATETIME = 8008,
        ///<summary>
        ///Optically Readable Sensor Indicator
        ///</summary>
        OPTSEN = 8009,
        ///<summary>
        ///Component/Part Identifier (CPID)
        ///</summary>
        CPID = 8010,
        ///<summary>
        ///Component/Part Identifier serial number (CPID SERIAL)
        ///</summary>
        CPID_SERIAL = 8011,
        ///<summary>
        ///Software version
        ///</summary>
        VERSION = 8012,
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
        ///Loyalty points of a coupon
        ///</summary>
        LOYALTY_POINTS = 8111,
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
