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
    /// Insert SKUReason in SKUReason Table
    /// </summary>
   public  class cmdSKUReasons
    {
       /// <summary>
       /// Create entity object RMAntitySyatem. 
       /// </summary>
       Shipping_ManagerEntities1 entRMA = new Shipping_ManagerEntities1();

       /// <summary>
       /// Insert the SKUReasons In the SKUreasons Table
       /// </summary>
       /// <param name="skureason">
       /// SKUreason table Object pass as parameter.
       /// </param>
       /// <returns>
       /// Return Boolean value when Transaction is success. 
       /// </returns>
       public Boolean UpsertSKUReasons (SKUReasonsDTO skureason)
       {
           Boolean _flag = false;
           try
           {
               SKUReason _SKUReason = new SKUReason();
               _SKUReason = entRMA.SKUReasons.FirstOrDefault(i => i.SKUReasonID == skureason.SKUReasonID);

               if (_SKUReason == null)
               {
                   _SKUReason = new SKUReason();
                   _SKUReason.SKUReasonID = skureason.SKUReasonID;
                   _SKUReason.ReasonID = skureason.ReasonID;
                   _SKUReason.ReturnDetailID = skureason.ReturnDetailID;

                   entRMA.AddToSKUReasons(_SKUReason);
               }
               else
               {
                   _SKUReason.ReasonID = skureason.ReasonID;
                   _SKUReason.ReturnDetailID = skureason.ReturnDetailID;
               }
               entRMA.SaveChanges();
               _flag = true;

           }
           catch (Exception)
           {
           }
           return _flag;
       }


       public string ListOfReasons(Guid ReturnDetailID)
       {
           string List = "";
           try
           {
               var lsreason = (from sku in entRMA.SKUReasons
                               join reson in entRMA.Reasons
                                   on sku.ReasonID equals reson.ReasonID
                               where sku.ReturnDetailID == ReturnDetailID
                               select sku).ToList();

               if (lsreason.Count>0)
               {
                   if (lsreason.Count == 1)
                   {
                       foreach (var item in lsreason)
                       {
                           List += item.Reason.Reason1.ToString();
                       }
                   }
                   else
                   {
                       foreach (var item in lsreason)
                       {
                           List += "," + item.Reason.Reason1.ToString();
                       }
                   }
               }
           }
           catch (Exception)
           {
           }
           return List;
       }

    }
}
