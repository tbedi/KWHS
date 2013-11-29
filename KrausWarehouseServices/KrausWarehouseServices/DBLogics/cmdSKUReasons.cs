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
    /// Insert SKUReason in SKUReason Table
    /// </summary>
   public  class cmdSKUReasons
    {
       /// <summary>
       /// Create entity object RMAntitySyatem. 
       /// </summary>
       RMASYSTEMEntities entRMA = new RMASYSTEMEntities();

       /// <summary>
       /// Insert the SKUReasons In the SKUreasons Table
       /// </summary>
       /// <param name="skureason">
       /// SKUreason table Object pass as parameter.
       /// </param>
       /// <returns>
       /// Return Boolean value when Transaction is success. 
       /// </returns>
       public Boolean SetTransaction(SKUReasonsDTO skureason)
       {
           Boolean _flag = false;
           try
           {
               entRMA.AddToSKUReasons(skureason);
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
