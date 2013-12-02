using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections;
using KrausWarehouseServices.DTO.RMA;


namespace KrausWarehouseServices.DBLogics.RMA
{
    /// <summary>
    /// Upsert operation on the Return Detail Table.
    /// </summary>
   public class cmdReturnDetail
    {
       //Create object Of Entitity RMASYATEM
       RMASYSTEMEntities entRMA = new RMASYSTEMEntities();

       /// <summary>
       /// Insert and update operation on the Return detail Table
       /// </summary>
       /// <param name="ReturnsDetail">
       /// Pass Return Detail table object
       /// </param>
       /// <returns>
       /// return Boolean Value When transaction is success.
       /// </returns>
       public Boolean UpsertReturnDetail(ReturnDetailsDTO ReturnsDetail)
       {
           Boolean _flag = false;
           try
           {
               ReturnDetail _ReturnDetail = new ReturnDetail();
               _ReturnDetail = entRMA.ReturnDetails.SingleOrDefault(ret => ret.ReturnDetailID == ReturnsDetail.ReturnDetailID);

               //if redto is null then insert
               if (_ReturnDetail == null)
               {
                   _ReturnDetail = new ReturnDetail();
                   _ReturnDetail.ReturnDetailID = ReturnsDetail.ReturnDetailID;
                   _ReturnDetail.ReturnID = ReturnsDetail.ReturnID;
                   _ReturnDetail.SKUNumber = ReturnsDetail.SKUNumber;
                   _ReturnDetail.ProductName = ReturnsDetail.ProductName;
                   _ReturnDetail.TCLCOD_0 = ReturnsDetail.TCLCOD_0;
                   _ReturnDetail.DeliveredQty = ReturnsDetail.DeliveredQty;
                   _ReturnDetail.ExpectedQty = ReturnsDetail.ExpectedQty;
                   _ReturnDetail.ReturnQty = ReturnsDetail.ReturnQty;
                   _ReturnDetail.ProductStatus = ReturnsDetail.ProductStatus;
                   _ReturnDetail.CreatedBy = ReturnsDetail.CreatedBy;
                   _ReturnDetail.UpdatedBy = ReturnsDetail.UpdatedBy;
                   _ReturnDetail.CreatedDate = ReturnsDetail.CreatedDate;
                   _ReturnDetail.UpadatedDate = ReturnsDetail.UpadatedDate;
                   entRMA.AddToReturnDetails(_ReturnDetail);
               }
               else//otherwise update.
               {
                   _ReturnDetail.ReturnID = ReturnsDetail.ReturnID;
                   _ReturnDetail.SKUNumber = ReturnsDetail.SKUNumber;
                   _ReturnDetail.ProductName = ReturnsDetail.ProductName;
                   _ReturnDetail.TCLCOD_0 = ReturnsDetail.TCLCOD_0;
                   _ReturnDetail.DeliveredQty = ReturnsDetail.DeliveredQty;
                   _ReturnDetail.ExpectedQty = ReturnsDetail.ExpectedQty;
                   _ReturnDetail.ReturnQty = ReturnsDetail.ReturnQty;
                   _ReturnDetail.ProductStatus = ReturnsDetail.ProductStatus;
                   _ReturnDetail.CreatedBy = ReturnsDetail.CreatedBy;
                   _ReturnDetail.UpdatedBy = ReturnsDetail.UpdatedBy;
                   _ReturnDetail.CreatedDate = ReturnsDetail.CreatedDate;
                   _ReturnDetail.UpadatedDate = ReturnsDetail.UpadatedDate;
               }
               entRMA.SaveChanges();
               _flag = true;
       
           }
           catch (Exception)
           {
           }
           return _flag;
       }

    }
}
