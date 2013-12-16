using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.Shipping;

namespace KrausWarehouseServices.DBLogics.Shipping
{
   public class cmdViewGetShippingDetail
    {
       /// <summary>
       /// Create the Object OF Shipping Entity.
       /// </summary>
       Shipping_ManagerEntities1 entshipping = new Shipping_ManagerEntities1();

       /// <summary>
       /// Get all Records from View Shipping Detail.
       /// </summary>
       /// <returns>
       /// Return The List of all Shipping Detail.
       /// </returns>
       public List<viewgetShippingDetails> GetAll()
       {
           List<viewgetShippingDetails> _lsViewShippingdetail = new List<viewgetShippingDetails>();
           try
           {
               var viewShip = (from viewshippingdetail in entshipping.getShippingDetails
                               select viewshippingdetail).ToList();

               foreach (var viewShippingitem in viewShip)
               {
                   _lsViewShippingdetail.Add(new viewgetShippingDetails(viewShippingitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsViewShippingdetail;
       
       }

       /// <summary>
       /// Get Shipping Details By ShipmentNum.
       /// </summary>
       /// <param name="ShipmentNumber">
       /// pass Shipment Num.
       /// </param>
       /// <returns>
       /// return list.
       /// </returns>
       public List<viewgetShippingDetails> GetByShipmentNum(String ShipmentNumber)
       {
           List<viewgetShippingDetails> _lsviewShipmentDetail = new List<viewgetShippingDetails>();
           try
           {
               var ship = (from viewdetail in entshipping.getShippingDetails
                           where viewdetail.ShippingNum == ShipmentNumber
                           select viewdetail).ToList();

               foreach (var shippingitem in ship)
               {
                   _lsviewShipmentDetail.Add(new viewgetShippingDetails(shippingitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsviewShipmentDetail;
       }

       /// <summary>
       /// Get Shipping Details By OrderID
       /// </summary>
       /// <param name="_orderID"></param>
       /// <returns></returns>
       public List<viewgetShippingDetails> GetByOrderID(String _orderID)
       {
           List<viewgetShippingDetails> _lsviewShipmentDetail = new List<viewgetShippingDetails>();
           try
           {
               var ship = (from viewdetail in entshipping.getShippingDetails
                           where viewdetail.OrderID == _orderID
                           select viewdetail).ToList();

               foreach (var shippingitem in ship)
               {
                   _lsviewShipmentDetail.Add(new viewgetShippingDetails(shippingitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsviewShipmentDetail;
       }

       /// <summary>
       /// Get Shipping Details By ponum
       /// </summary>
       /// <param name="_POnumber">
       /// pass Ponum as parameter.
       /// </param>
       /// <returns>
       /// return List.
       /// </returns>
       public List<viewgetShippingDetails> GetByPoNumber(String _POnumber)
       {
           List<viewgetShippingDetails> _lsviewShipmentDetail = new List<viewgetShippingDetails>();
           try
           {
               var ship = (from viewdetail in entshipping.getShippingDetails
                           where viewdetail.CustomerPO == _POnumber
                           select viewdetail).ToList();

               foreach (var shippingitem in ship)
               {
                   _lsviewShipmentDetail.Add(new viewgetShippingDetails(shippingitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsviewShipmentDetail;
       }


       /// <summary>
       /// Get Shipping Details By supplierNo.
       /// </summary>
       /// <param name="_supplirNumber">
       /// pass suppilerNo as parameter.
       /// </param>
       /// <returns>
       /// return List.
       /// </returns>
       public List<viewgetShippingDetails> GetBySupplierNumber(String _supplirNumber)
       {
           List<viewgetShippingDetails> _lsviewShipmentDetail = new List<viewgetShippingDetails>();
           try
           {
               var ship = (from viewdetail in entshipping.getShippingDetails
                           where viewdetail.OurSupplierNo == _supplirNumber
                           select viewdetail).ToList();

               foreach (var shippingitem in ship)
               {
                   _lsviewShipmentDetail.Add(new viewgetShippingDetails(shippingitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsviewShipmentDetail;
       }

       /// <summary>
       /// Get Shipping Details By vendername.
       /// </summary>
       /// <param name="_venderName">
       /// pass vendername as parameter.
       /// </param>
       /// <returns>
       /// return List.
       /// </returns>
       public List<viewgetShippingDetails> GetByVendorName(String _venderName)
       {
           List<viewgetShippingDetails> _lsviewShipmentDetail = new List<viewgetShippingDetails>();
           try
           {
               var ship = (from viewdetail in entshipping.getShippingDetails
                           where viewdetail.VendorName == _venderName
                           select viewdetail).ToList();

               foreach (var shippingitem in ship)
               {
                   _lsviewShipmentDetail.Add(new viewgetShippingDetails(shippingitem));
               }
           }
           catch (Exception)
           {
           }
           return _lsviewShipmentDetail;
       }
    }
}
