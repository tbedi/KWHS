using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using KrausWarehouseServices.Connections;


namespace KrausWarehouseServices.DTO.Shipping
{
    [DataContract]
   public class ShippingDTO
    {
       /// <summary>
       /// Blank Constructor.
       /// </summary>
       public ShippingDTO()
       {
       }

        [DataMember]
       public Guid ShippingID { get; set; }

        [DataMember]
       public String ShippingNum { get; set; }

        [DataMember]
       public DateTime ShippingStartTime { get; set; }

        [DataMember]
       public DateTime ShippingEndTime { get; set; }

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
       public string FromAddressCountry { get; set; }

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
       public string MDL_0 { get; set; }

        [DataMember]
       public String YCARSRV_0 { get; set; }

        [DataMember]
       public Byte XB_RESFLG_0 { get; set; }

        [DataMember]
       public String CODCHG_0 { get; set; }

        [DataMember]
       public Decimal INSVAL_0 { get; set; }

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

        [DataMember]
       public String SHIPPINGROWID { get; set; }

        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public Guid Updatedby { get; set; }

        [DataMember]
        public DateTime? CreatedDateTime { get; set; }

        [DataMember]
        public DateTime? UpdatedDateTime { get; set; }

        [DataMember]
        public int ROWID { get; set; }
        /// <summary>
        /// Paramiterised Constructor.
        /// </summary>
        /// <param name="_shipping">
        /// pass Shipping Object.
        /// </param>
       public ShippingDTO(Connections.Shipping.Shipping _shipping)
       {
           if (_shipping.ShippingID != null) this.ShippingID = (Guid)_shipping.ShippingID;
           if (_shipping.ShippingNum != null) this.ShippingNum = (String)_shipping.ShippingNum;
           if (_shipping.ShippingStartTime != Convert.ToDateTime("01/01/00001")) this.ShippingStartTime = (DateTime)_shipping.ShippingStartTime;
           if (_shipping.ShippingEndTime != Convert.ToDateTime("01/01/0001")) this.ShippingEndTime = (DateTime)_shipping.ShippingEndTime;
           if (_shipping.DeliveryProvider != null) this.DeliveryProvider =(string) _shipping.DeliveryProvider;
           if (_shipping.DeliveryMode != null) this.DeliveryMode =(String) _shipping.DeliveryMode;
           if (_shipping.FromAddressLine1 != null) this.FromAddressLine1 = (String)_shipping.FromAddressLine1;
           if (_shipping.FromAddressLine2 != null) this.FromAddressLine2 = (String)_shipping.FromAddressLine2;
           if (_shipping.FromAddressLine3 != null) this.FromAddressLine3 = (string)_shipping.FromAddressLine3;
           if (_shipping.FromAddressCity != null) this.FromAddressCity = (String)_shipping.FromAddressCity;
           if (_shipping.FromAddressState != null) this.FromAddressState = (string)_shipping.FromAddressState;
           if (_shipping.FromAddressCountry != null) this.FromAddressCountry = (String)_shipping.FromAddressCountry;
           if (_shipping.FromAddressZipCode != null) this.FromAddressZipCode = (String)_shipping.FromAddressZipCode;
           if (_shipping.ToAddressLine1 != null) this.ToAddressLine1 = (String)_shipping.ToAddressLine1;
           if (_shipping.ToAddressLine2 != null) this.ToAddressLine2 = (String)_shipping.ToAddressLine2;
           if (_shipping.ToAddressLine3 != null) this.ToAddressLine3 = (string)_shipping.ToAddressLine3;
           if (_shipping.ToAddressCity != null) this.ToAddressCity = (String)_shipping.ToAddressCity;
           if (_shipping.ToAddressState != null) this.ToAddressState = (String)_shipping.ToAddressState;
           if (_shipping.ToAddressCountry != null) this.ToAddressCountry = (String)_shipping.ToAddressCountry;
           if (_shipping.ToAddressZipCode != null) this.ToAddressZipCode = (String)_shipping.ToAddressZipCode;
           if (_shipping.ShipmentStatus != null) this.ShipmentStatus = (String)_shipping.ShipmentStatus;
           if (_shipping.OrderID != null) this.OrderID = (String)_shipping.OrderID;
           if (_shipping.CustomerPO != null) this.CustomerPO = (String)_shipping.CustomerPO;
           if (_shipping.ShipToAddress != null) this.ShipToAddress = (String)_shipping.ShipToAddress;
           if (_shipping.OurSupplierNo != null) this.OurSupplierNo = (String)_shipping.OurSupplierNo;
           if (_shipping.CustomerName1 != null) this.CustomerName1 = (String)_shipping.CustomerName1;
           if (_shipping.CustomerName2 != null) this.CustomerName2 = (String)_shipping.CustomerName2;
           if (_shipping.WebAddress != null) this.WebAddress = (String)_shipping.WebAddress;
           if (_shipping.FreightTerms != null) this.FreightTerms = (String)_shipping.FreightTerms;
           if (_shipping.Carrier != null) this.Carrier = (String)_shipping.Carrier;
           if (_shipping.DeliveryContact != null) this.DeliveryContact = (String)_shipping.DeliveryContact;
           this.Indexcode =(Int16) _shipping.Indexcode;
           if (_shipping.Contact != null) this.Contact = _shipping.Contact;
           if (_shipping.PaymentTerms != null) this.PaymentTerms = _shipping.PaymentTerms;
           this.TotalPackages =(int)_shipping.TotalPackages;
           if (_shipping.Fax != null) this.Fax = _shipping.Fax;
           if (_shipping.VendorName != null) this.VendorName = _shipping.VendorName;
           if (_shipping.MDL_0 != null) this.MDL_0 = (String)_shipping.MDL_0;
           //if (_shipping.yca != null) this.YCARSRV_0 = (String)_shipping.YCARSRV_0;
           if (_shipping.XB_RESFLG_0 != null) this.XB_RESFLG_0 = (Byte)_shipping.XB_RESFLG_0;
           if (_shipping.CODCHG_0 != null) this.CODCHG_0 = (String)_shipping.CODCHG_0;
           if (_shipping.INSVAL_0 != null) this.INSVAL_0 = (Decimal)_shipping.INSVAL_0;
           if (_shipping.ADDCODFRT_0 != null) this.ADDCODFRT_0 = (Byte)_shipping.ADDCODFRT_0;
           if (_shipping.BILLOPT_0 != null) this.BILLOPT_0 = (String)_shipping.BILLOPT_0;
           if (_shipping.HDLCHG_0 != null) this.HDLCHG_0 = (String)_shipping.HDLCHG_0;
           if (_shipping.DOWNFLG_0 != null) this.DOWNFLG_0 = (Byte)_shipping.DOWNFLG_0;
           if (_shipping.BACCT_0 != null) this.BACCT_0 = (String)_shipping.BACCT_0;
           if (_shipping.TPBILL_0 != null) this.TPBILL_0 = (Byte)_shipping.TPBILL_0;
           if (_shipping.CUSTBILL_0 != null) this.CUSTBILL_0 = (Byte)_shipping.CUSTBILL_0;
           if (_shipping.CNTFULNAM_0 != null) this.CNTFULNAM_0 = (String)_shipping.CNTFULNAM_0;
           if (_shipping.SHIPPINGROWID != null) this.SHIPPINGROWID = (String)_shipping.SHIPPINGROWID;
           this.ROWID = (int)_shipping.ROWID;
           if (_shipping.CreatedBy != null) this.CreatedBy = (Guid)_shipping.CreatedBy;
           if (_shipping.Updatedby != null) this.Updatedby = (Guid)_shipping.Updatedby;
           if (_shipping.CreatedDateTime != Convert.ToDateTime("01/01/0001")) this.CreatedDateTime = _shipping.CreatedDateTime;
           if (_shipping.UpdatedDateTime != Convert.ToDateTime("01/01/0001")) this.UpdatedDateTime = _shipping.UpdatedDateTime;
       }







      
    }
}
