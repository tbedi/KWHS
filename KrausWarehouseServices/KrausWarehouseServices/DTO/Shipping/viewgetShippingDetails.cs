using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
   public class viewgetShippingDetails
    {
        [DataMember]
        public String ShippingNum { get; set; }

        [DataMember]
        public String DeliveryProvider { get; set; }

        [DataMember]
        public String DeliveryMode { get; set; }

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
        public decimal INSVAL_0 { get; set; }

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

        /// <summary>
        /// Blank Constructor.
        /// </summary>
        public viewgetShippingDetails()
        {

        }

        public viewgetShippingDetails(Connections.Shipping.getShippingDetail _viewgetshippingdetial)
        {

            if (_viewgetshippingdetial.ShippingNum != null) this.ShippingNum = _viewgetshippingdetial.ShippingNum;
            if (_viewgetshippingdetial.DeliveryProvider != null) this.DeliveryProvider = _viewgetshippingdetial.DeliveryProvider;
            if (_viewgetshippingdetial.DeliveryMode != null) this.DeliveryMode = _viewgetshippingdetial.DeliveryMode;
            if (_viewgetshippingdetial.FromAddressLine1 != null) this.FromAddressLine1 = _viewgetshippingdetial.FromAddressLine1;
            if (_viewgetshippingdetial.FromAddressLine2 != null) this.FromAddressLine2 = _viewgetshippingdetial.FromAddressLine2;
            if (_viewgetshippingdetial.FromAddressLine3 != null) this.FromAddressLine3 = _viewgetshippingdetial.FromAddressLine3;
            if (_viewgetshippingdetial.FromAddressCity != null) this.FromAddressCity = _viewgetshippingdetial.FromAddressCity;
            if (_viewgetshippingdetial.FromAddressState != null) this.FromAddressState = _viewgetshippingdetial.FromAddressState;
            if (_viewgetshippingdetial.FromAddressCountry != null) this.FromAddressCountry = _viewgetshippingdetial.FromAddressCountry;
            if (_viewgetshippingdetial.FromAddressZipCode != null) this.FromAddressZipCode = _viewgetshippingdetial.FromAddressZipCode;
            if (_viewgetshippingdetial.ToAddressLine1 != null) this.ToAddressLine1 = _viewgetshippingdetial.ToAddressLine1;
            if (_viewgetshippingdetial.ToAddressLine2 != null) this.ToAddressLine2 = _viewgetshippingdetial.ToAddressLine2;
            if (_viewgetshippingdetial.ToAddressLine3 != null) this.ToAddressLine3 = _viewgetshippingdetial.ToAddressLine3;
            if (_viewgetshippingdetial.ToAddressCity != null) this.ToAddressCity = _viewgetshippingdetial.ToAddressCity;
            if (_viewgetshippingdetial.ToAddressState != null) this.ToAddressState = _viewgetshippingdetial.ToAddressState;
            if (_viewgetshippingdetial.ToAddressCountry != null) this.ToAddressCountry = _viewgetshippingdetial.ToAddressCountry;
            if (_viewgetshippingdetial.ToAddressZipCode != null) this.ToAddressZipCode = _viewgetshippingdetial.ToAddressZipCode;
            if (_viewgetshippingdetial.ShipmentStatus != null) this.ShipmentStatus = _viewgetshippingdetial.ShipmentStatus;
            if (_viewgetshippingdetial.OrderID != null) this.OrderID = _viewgetshippingdetial.OrderID;
            if (_viewgetshippingdetial.CustomerPO != null) this.CustomerPO = _viewgetshippingdetial.CustomerPO;
            if (_viewgetshippingdetial.ShipToAddress != null) this.ShipToAddress = _viewgetshippingdetial.ShipToAddress;
            if (_viewgetshippingdetial.OurSupplierNo != null) this.OurSupplierNo = _viewgetshippingdetial.OurSupplierNo;
            if (_viewgetshippingdetial.CustomerName1 != null) this.CustomerName1 = _viewgetshippingdetial.CustomerName1;
            if (_viewgetshippingdetial.CustomerName2 != null) this.CustomerName2 = _viewgetshippingdetial.CustomerName2;
            if (_viewgetshippingdetial.WebAddress != null) this.WebAddress = _viewgetshippingdetial.WebAddress;
            if (_viewgetshippingdetial.FreightTerms != null) this.FreightTerms = _viewgetshippingdetial.FreightTerms;
            if (_viewgetshippingdetial.Carrier != null) this.Carrier = _viewgetshippingdetial.Carrier;
            if (_viewgetshippingdetial.DeliveryContact != null) this.DeliveryContact = _viewgetshippingdetial.DeliveryContact;
            this.Indexcode = _viewgetshippingdetial.Indexcode;
            if (_viewgetshippingdetial.Contact != null) this.Contact = _viewgetshippingdetial.Contact;
            if (_viewgetshippingdetial.PaymentTerms != null) this.PaymentTerms = _viewgetshippingdetial.PaymentTerms;
            this.TotalPackages = _viewgetshippingdetial.TotalPackages;
            if (_viewgetshippingdetial.Fax != null) this.Fax = _viewgetshippingdetial.Fax;
            if (_viewgetshippingdetial.VendorName != null) this.VendorName = _viewgetshippingdetial.VendorName;
            if (_viewgetshippingdetial.ShippingMode != null) this.ShippingMode = _viewgetshippingdetial.ShippingMode;
            this.XB_RESFLG_0 = _viewgetshippingdetial.XB_RESFLG_0;
            if (_viewgetshippingdetial.CODCHG_0 != null) this.CODCHG_0 = _viewgetshippingdetial.CODCHG_0;
            this.INSVAL_0 = _viewgetshippingdetial.INSVAL_0;
            this.ADDCODFRT_0 = _viewgetshippingdetial.ADDCODFRT_0;
            if (_viewgetshippingdetial.BILLOPT_0 != null) this.BILLOPT_0 = _viewgetshippingdetial.BILLOPT_0;
            if (_viewgetshippingdetial.HDLCHG_0 != null) this.HDLCHG_0 = _viewgetshippingdetial.HDLCHG_0;
            this.DOWNFLG_0 = _viewgetshippingdetial.DOWNFLG_0;
            if (_viewgetshippingdetial.BACCT_0 != null) this.BACCT_0 = _viewgetshippingdetial.BACCT_0;
            this.TPBILL_0 = _viewgetshippingdetial.TPBILL_0;
            this.CUSTBILL_0 = _viewgetshippingdetial.CUSTBILL_0;
            if (_viewgetshippingdetial.CNTFULNAM_0 != null) this.CNTFULNAM_0 = _viewgetshippingdetial.CNTFULNAM_0;
        }
    }

}
