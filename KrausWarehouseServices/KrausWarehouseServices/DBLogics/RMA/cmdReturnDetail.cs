using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.RMA;


namespace KrausWarehouseServices.DBLogics.RMA
{
    /// <summary>
    /// Upsert operation on the Return Detail Table.
    /// </summary>
   public class cmdReturnDetail
    {
       //Create object Of Entitity RMASYATEM
       Shipping_ManagerEntities1 entRMA = new Shipping_ManagerEntities1();

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
           {}
           return _flag;
       }


       /// <summary>
       /// Get all information of Return detail By ReturnID.
       /// </summary>
       /// <param name="RetunID">
       /// returnID pass as parameter.
       /// </param>
       /// <returns>
       /// return list.
       /// </returns>
       public List<ReturnDetailsDTO> GetreturnDetailByretrnID(Guid RetunID)
       {
           List<ReturnDetailsDTO> _lsreturn =new List<ReturnDetailsDTO>();
           try
           {
               var redetail = (from _returnfdetail in entRMA.ReturnDetails
                               where _returnfdetail.ReturnID == RetunID
                               select _returnfdetail).ToList();

               foreach (var item in redetail)
               {
                   ReturnDetailsDTO returndetail = new ReturnDetailsDTO(item);
                   _lsreturn.Add(returndetail);
               }
           }
           catch (Exception)
           {
           }
           return _lsreturn;
       
       }

       /// <summary>
       /// Get all information of Return detail By RGADROWID.
       /// </summary>
       /// <param name="RGADROWID">
       /// RGADROWID pass as parameter.
       /// </param>
       /// <returns>
       /// return list.
       /// </returns>
       public List<ReturnDetailsDTO> GetreturnDetailByRGADROWID(String RGADROWID)
       {
           List<ReturnDetailsDTO> _lsreturn = new List<ReturnDetailsDTO>();
           try
           {
               var redetail = (from _returnfdetail in entRMA.ReturnDetails
                               where _returnfdetail.RGADROWID == RGADROWID
                               select _returnfdetail).ToList();

               foreach (var item in redetail)
               {
                   ReturnDetailsDTO returndetail = new ReturnDetailsDTO(item);
                   _lsreturn.Add(returndetail);
               }
           }
           catch (Exception)
           {
           }
           return _lsreturn;
       }

       /// <summary>
       /// Get all information of Return detail By RGAROWID.
       /// </summary>
       /// <param name="RGAROWID">
       /// RGAROWID pass as parameter.
       /// </param>
       /// <returns>
       /// return list.
       /// </returns>
       public List<ReturnDetailsDTO> GetreturnDetailByRGAROWID(String RGAROWID)
       {
           List<ReturnDetailsDTO> _lsreturn = new List<ReturnDetailsDTO>();
           try
           {
               var redetail = (from _returnfdetail in entRMA.ReturnDetails
                               join _return in entRMA.Returns
                               on _returnfdetail.ReturnID equals _return.ReturnID
                               where _return.RGAROWID == RGAROWID
                               select _returnfdetail).ToList();

               foreach (var item in redetail)
               {
                   ReturnDetailsDTO returndetail = new ReturnDetailsDTO(item);
                   _lsreturn.Add(returndetail);
               }
           }
           catch (Exception)
           {
           }
           return _lsreturn;
       }



    }
}
