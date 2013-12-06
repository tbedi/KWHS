﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.Connections.Shipping;

namespace KrausWarehouseServices.DBLogics.Shipping
{
   public class cmdShipping
    {
       /// <summary>
       /// Create Entity Object. 
       /// </summary>
       Shipping_ManagerEntities1 entShipping = new Shipping_ManagerEntities1();

     #region Get Methods For Shipping
		 
       /// <summary>
       /// Get All records from The Shipping Table.
       /// </summary>
       /// <returns>
       /// Return the Records.
       /// </returns>
       public List<ShippingDTO> GetAll()
       {
           List<ShippingDTO> _lsshipping = new List<ShippingDTO>();

           try
           {
               var _shipping = (from ship in entShipping.Shippings
                                select ship).ToList();
               
               foreach (var shippingitem in _shipping)
               {
                   _lsshipping.Add(new ShippingDTO(shippingitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsshipping;
       }

       /// <summary>
       /// get Record From the Shipping By ShippingID.
       /// </summary>
       /// <param name="ShippingID">
       /// pass shippingID Parameter
       /// </param>
       /// <returns>
       /// Return List OF Shipping.
       /// </returns>
       public List<ShippingDTO> GetByShippingID(Guid ShippingID)
       {
           List<ShippingDTO> _lsShipping = new List<ShippingDTO>();
           try
           {
               var _shipping = (from ship in entShipping.Shippings
                                where ship.ShippingID == ShippingID
                                select ship).ToList();

               foreach (var shippingitem in _shipping)
               {
                   _lsShipping.Add(new ShippingDTO(shippingitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsShipping;
       
       }
       #endregion


       #region Upsert For Shipping
       
       
       /// <summary>
       /// Upsert Operation On Shipping table
       /// </summary>
       /// <param name="_shipping">
       /// pass Shipping DTO Object As parameter.
       /// </param>
       /// <returns>
       /// return Boolean Value.
       /// </returns>
       public Boolean UpsertShipping(List<ShippingDTO> _shipping)
       {
           Boolean _flag = false;
           try
           {
               foreach (var _shippingitem in _shipping)
               {
                   Connections.Shipping.Shipping ship ;
                   ship = entShipping.Shippings.SingleOrDefault(r => r.ShippingID == _shippingitem.ShippingID);
                   if (ship.ShippingID == Guid.Empty)
                   {
                       ship = new Connections.Shipping.Shipping();
                       ship.ShippingID = _shippingitem.ShippingID;
                       ship.ShippingNum = _shippingitem.ShippingNum;
                       ship.ShippingID= _shippingitem. ShippingID;
                       ship.ShippingNum= _shippingitem. ShippingNum;
                       ship.ShippingStartTime = _shippingitem.ShippingStartTime;
                       ship.ShippingEndTime= _shippingitem. ShippingEndTime;
                       ship.DeliveryProvider= _shippingitem. DeliveryProvider;
                       ship.DeliveryMode= _shippingitem. DeliveryMode;
                       ship.FromAddressLine1= _shippingitem. FromAddressLine1;
                       ship.FromAddressLine2= _shippingitem.FromAddressLine2 ;
                       ship.FromAddressLine3= _shippingitem. FromAddressLine3;
                       ship.FromAddressCity= _shippingitem. FromAddressCity;
                       ship.FromAddressState= _shippingitem. FromAddressState;
                       ship.FromAddressCountry= _shippingitem. FromAddressCountry;
                       ship.FromAddressZipCode= _shippingitem. FromAddressZipCode;
                       ship.ToAddressLine1= _shippingitem. ToAddressLine1;
                       ship.ToAddressLine2= _shippingitem. ToAddressLine2;
                       ship.ToAddressLine3= _shippingitem.ToAddressLine3; 
                       ship.ToAddressCity= _shippingitem.ToAddressCity ;
                       ship.ToAddressState= _shippingitem. ToAddressState;
                       ship.ToAddressCountry= _shippingitem. ToAddressCountry;
                       ship.ToAddressZipCode= _shippingitem. ToAddressZipCode;
                       ship.ShipmentStatus= _shippingitem. ShipmentStatus;
                       ship.OrderID= _shippingitem. OrderID;
                       ship.CustomerPO= _shippingitem. CustomerPO;
                       ship.ShipToAddress= _shippingitem.ShipToAddress ;
                       ship.OurSupplierNo= _shippingitem.OurSupplierNo ;
                       ship.CustomerName1= _shippingitem. CustomerName1;
                       ship.CustomerName2= _shippingitem. CustomerName2;
                       ship.WebAddress= _shippingitem. WebAddress;
                       ship.FreightTerms= _shippingitem.FreightTerms;
                       ship.Carrier= _shippingitem.Carrier;
                       ship.DeliveryContact= _shippingitem.DeliveryContact;
                       ship.Indexcode= _shippingitem.Indexcode;
                       ship.Contact= _shippingitem. Contact;
                       ship.PaymentTerms= _shippingitem. PaymentTerms;
                       ship.TotalPackages= _shippingitem. TotalPackages;
                       ship.Fax= _shippingitem. Fax;
                       ship.VendorName= _shippingitem. VendorName;
                       ship.MDL_0= _shippingitem. MDL_0;
                       ship.XB_RESFLG_0= _shippingitem. XB_RESFLG_0;
                       ship.CODCHG_0= _shippingitem.CODCHG_0 ;
                       ship.INSVAL_0= _shippingitem.INSVAL_0 ;
                       ship.ADDCODFRT_0= _shippingitem.ADDCODFRT_0; 
                       ship.BILLOPT_0= _shippingitem.BILLOPT_0; 
                       ship.HDLCHG_0= _shippingitem.HDLCHG_0 ;
                       ship.DOWNFLG_0= _shippingitem.DOWNFLG_0; 
                       ship.BACCT_0= _shippingitem. BACCT_0;
                       ship.TPBILL_0= _shippingitem.TPBILL_0 ;
                       ship.CUSTBILL_0= _shippingitem.CUSTBILL_0 ;
                       ship.CNTFULNAM_0= _shippingitem. CNTFULNAM_0;
                       ship.CreatedDateTime= _shippingitem. CreatedDateTime;
                       ship.UpdatedDateTime= _shippingitem.UpdatedDateTime ;
                       ship.CreatedBy= _shippingitem. CreatedBy;
                       ship.Updatedby= _shippingitem.Updatedby;
                       ship.ROWID= _shippingitem.ROWID ;
                       ship.SHIPPINGROWID=_shippingitem.SHIPPINGROWID;
                       entShipping.AddToShippings(ship);
                   }
                   else
                   {
                       ship.ShippingNum = _shippingitem.ShippingNum;
                       ship.ShippingID = _shippingitem.ShippingID;
                       ship.ShippingNum = _shippingitem.ShippingNum;
                       ship.ShippingStartTime = _shippingitem.ShippingStartTime;
                       ship.ShippingEndTime = _shippingitem.ShippingEndTime;
                       ship.DeliveryProvider = _shippingitem.DeliveryProvider;
                       ship.DeliveryMode = _shippingitem.DeliveryMode;
                       ship.FromAddressLine1 = _shippingitem.FromAddressLine1;
                       ship.FromAddressLine2 = _shippingitem.FromAddressLine2;
                       ship.FromAddressLine3 = _shippingitem.FromAddressLine3;
                       ship.FromAddressCity = _shippingitem.FromAddressCity;
                       ship.FromAddressState = _shippingitem.FromAddressState;
                       ship.FromAddressCountry = _shippingitem.FromAddressCountry;
                       ship.FromAddressZipCode = _shippingitem.FromAddressZipCode;
                       ship.ToAddressLine1 = _shippingitem.ToAddressLine1;
                       ship.ToAddressLine2 = _shippingitem.ToAddressLine2;
                       ship.ToAddressLine3 = _shippingitem.ToAddressLine3;
                       ship.ToAddressCity = _shippingitem.ToAddressCity;
                       ship.ToAddressState = _shippingitem.ToAddressState;
                       ship.ToAddressCountry = _shippingitem.ToAddressCountry;
                       ship.ToAddressZipCode = _shippingitem.ToAddressZipCode;
                       ship.ShipmentStatus = _shippingitem.ShipmentStatus;
                       ship.OrderID = _shippingitem.OrderID;
                       ship.CustomerPO = _shippingitem.CustomerPO;
                       ship.ShipToAddress = _shippingitem.ShipToAddress;
                       ship.OurSupplierNo = _shippingitem.OurSupplierNo;
                       ship.CustomerName1 = _shippingitem.CustomerName1;
                       ship.CustomerName2 = _shippingitem.CustomerName2;
                       ship.WebAddress = _shippingitem.WebAddress;
                       ship.FreightTerms = _shippingitem.FreightTerms;
                       ship.Carrier = _shippingitem.Carrier;
                       ship.DeliveryContact = _shippingitem.DeliveryContact;
                       ship.Indexcode = _shippingitem.Indexcode;
                       ship.Contact = _shippingitem.Contact;
                       ship.PaymentTerms = _shippingitem.PaymentTerms;
                       ship.TotalPackages = _shippingitem.TotalPackages;
                       ship.Fax = _shippingitem.Fax;
                       ship.VendorName = _shippingitem.VendorName;
                       ship.MDL_0 = _shippingitem.MDL_0;
                       ship.XB_RESFLG_0 = _shippingitem.XB_RESFLG_0;
                       ship.CODCHG_0 = _shippingitem.CODCHG_0;
                       ship.INSVAL_0 = _shippingitem.INSVAL_0;
                       ship.ADDCODFRT_0 = _shippingitem.ADDCODFRT_0;
                       ship.BILLOPT_0 = _shippingitem.BILLOPT_0;
                       ship.HDLCHG_0 = _shippingitem.HDLCHG_0;
                       ship.DOWNFLG_0 = _shippingitem.DOWNFLG_0;
                       ship.BACCT_0 = _shippingitem.BACCT_0;
                       ship.TPBILL_0 = _shippingitem.TPBILL_0;
                       ship.CUSTBILL_0 = _shippingitem.CUSTBILL_0;
                       ship.CNTFULNAM_0 = _shippingitem.CNTFULNAM_0;
                       ship.CreatedDateTime = _shippingitem.CreatedDateTime;
                       ship.UpdatedDateTime = _shippingitem.UpdatedDateTime;
                       ship.CreatedBy = _shippingitem.CreatedBy;
                       ship.Updatedby = _shippingitem.Updatedby;
                       ship.ROWID = _shippingitem.ROWID;
                       ship.SHIPPINGROWID = _shippingitem.SHIPPINGROWID;
                   }
               }
               entShipping.SaveChanges();
               _flag = true;
           }
           catch (Exception)
           {
           }
           return _flag;

       }
       #endregion

    }
}
