using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
    class viewgetShippingDetails
    {
        [DataMember]
        public String ShippingNum { get; set; }

        [DataMember]
        public String DeliveryProvider { get; set; }

        [DataMember]
        public String StringDeliveryMode { get; set; }

        [DataMember]
        public String FromAddressLine1 { get; set; }

        [DataMember]
        public String FromAddressLine2 { get; set; }

        [DataMember]
        public String FromAddressLine3 { get; set; }

        [DataMember]
        public String FromAddressCity { get; set; }

        [DataMember]
        public String FromAddressState { get; set; }

        [DataMember]
        public String FromAddressCountry { get; set; }

        [DataMember]
        public String FromAddressZipCode { get; set; }

        [DataMember]
        public String ToAddressLine1 { get; set; }

        [DataMember]
        public String ToAddressLine2 { get; set; }

        [DataMember]
        public String ToAddressLine3 { get; set; }

        [DataMember]
        public String ToAddressCity { get; set; }

        [DataMember]
        public String ToAddressState { get; set; }

        [DataMember]
        public String ToAddressCountry { get; set; }

        [DataMember]
        public String ToAddressZipCode { get; set; }

        [DataMember]
        public String ShipmentStatus { get; set; }

        [DataMember]
        public String OrderID { get; set; }

        [DataMember]
        public String CustomerPO { get; set; }

        [DataMember]
        public String ShipToAddress { get; set; }

        [DataMember]
        public String OurSupplierNo { get; set; }

        [DataMember]
        public String CustomerName1 { get; set; }

        [DataMember]
        public String CustomerName2 { get; set; }

        [DataMember]
        public String WebAddress { get; set; }

        [DataMember]
        public String FreightTerms { get; set; }

        [DataMember]
        public String Carrier { get; set; }

        [DataMember]
        public String DeliveryContact { get; set; }

        [DataMember]
        public Int16 Indexcode { get; set; }

        [DataMember]
        public String Contact { get; set; }

        [DataMember]
        public String PaymentTerms { get; set; }

        [DataMember]
        public int TotalPackages { get; set; }

        [DataMember]
        public String Fax { get; set; }

        [DataMember]
        public String VendorName { get; set; }

        [DataMember]
        public String ShippingMode { get; set; }

        [DataMember]
        public Byte XB_RESFLG_0 { get; set; }

        [DataMember]
        public String CODCHG_0 { get; set; }

        [DataMember]
        public String INSVAL_0 { get; set; }

        [DataMember]
        public Byte ADDCODFRT_0 { get; set; }
        
        [DataMember]
        public String BILLOPT_0 { get; set; }
        
        [DataMember]
        public String HDLCHG_0 { get; set; }

        [DataMember]
        public Byte DOWNFLG_0 { get; set; }

        [DataMember]
        public String BACCT_0 { get; set; }

        [DataMember]
        public Byte TPBILL_0 { get; set; }

        [DataMember]
        public Byte CUSTBILL_0 { get; set; }

        [DataMember]
        public String CNTFULNAM_0 { get; set; }
        
    }

}
