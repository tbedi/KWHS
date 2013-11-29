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
    /// Upsert Operation On ReturnImage Table 
    /// </summary>
   public  class cmdReturnImages
    {
       /// <summary>
       /// Create object of Entity RMASystem.
       /// </summary>
       RMASYSTEMEntities entRMA = new RMASYSTEMEntities();


       /// <summary>
       /// Insert and Update operation on returnImage Table.
       /// </summary>
       /// <param name="Returnimage">
       /// Returnimage table object pass  
       /// </param>
       /// <returns>
       /// return boolean value when Transaction is success.
       /// </returns>
       public Boolean UpsertRerurnImages(ReturnImagesDTO Returnimage)
       {
           Boolean _flag = false;
           try
           {
               ReturnImagesDTO Image=new ReturnImagesDTO(entRMA.ReturnImages.SingleOrDefault(ret=>ret.ReturnImageID==Returnimage.ReturnDetailID));
               if (Image == null)
               {
                   entRMA.AddToReturnImages(Returnimage);
               }
               else
               {
                   Image = Returnimage;
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
