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

           
       }

       public Guid ShippingID { get; set; }
       public String ShippingNum { get; set; }
       public DateTime ShippingStartTime { get; set; }
       public DateTime ShippingEndTime { get; set; }
       public String DeliveryProvider { get; set; }
       public String DeliveryMode { get; set; }
       public String FromAddressLine1 { get; set; }
       public String FromAddressLine2 { get; set; }
       public String FromAddressLine3 { get; set; }
       public String FromAddressCity { get; set; }
       public String FromAddressState { get; set; }
       public string FromAddressCountry { get; set; }
       public String FromAddressZipCode { get; set; }
       public String ToAddressLine1 { get; set; }
       public String ToAddressLine2 { get; set; }
       public String ToAddressLine3 { get; set; }
       public String ToAddressCity { get; set; }
       public String ToAddressState { get; set; }
       public String ToAddressCountry { get; set; }
       public String ToAddressZipCode { get; set; }
       public String ShipmentStatus { get; set; }
       public String OrderID { get; set; }
       public String CustomerPO { get; set; }
       public String ShipToAddress { get; set; }
       public String OurSupplierNo { get; set; }
       public String CustomerName1 { get; set; }
       public String CustomerName2 { get; set; }
       public String WebAddress { get; set; }
       public String FreightTerms { get; set; }
       public String Carrier { get; set; }
       public String DeliveryContact { get; set; }
       public Int16 Indexcode { get; set; }
       public String Contact { get; set; }
       public String PaymentTerms { get; set; }
       public int TotalPackages { get; set; }
       public String Fax { get; set; }
       public String VendorName { get; set; }
       public string MDL_0 { get; set; }
       public String YCARSRV_0 { get; set; }
       public Byte XB_RESFLG_0 { get; set; }
       public String CODCHG_0 { get; set; }
       public Decimal INSVAL_0 { get; set; }
       public Byte ADDCODFRT_0 { get; set; }
       public String BILLOPT_0 { get; set; }
       public String HDLCHG_0 { get; set; }
       public Byte DOWNFLG_0 { get; set; }
       public String BACCT_0 { get; set; }
       public Byte TPBILL_0 { get; set; }
       public Byte CUSTBILL_0 { get; set; }
       public String CNTFULNAM_0 { get; set; }
       public String SHIPPINGROWID { get; set; }


    }
}
