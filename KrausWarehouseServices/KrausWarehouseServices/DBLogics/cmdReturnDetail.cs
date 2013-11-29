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
               ReturnDetailsDTO redto = new ReturnDetailsDTO(entRMA.ReturnDetails.SingleOrDefault(ret => ret.ReturnDetailID == ReturnsDetail.ReturnDetailID));
               //if redto is null then insert
               if (redto==null)
               {
                   entRMA.AddToReturnDetails(ReturnsDetail);
               }//other wise update.
               else
               {
                   redto = ReturnsDetail;
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
