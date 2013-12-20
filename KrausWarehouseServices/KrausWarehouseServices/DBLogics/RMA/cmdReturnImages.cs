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
    /// Upsert Operation On ReturnImage Table 
    /// </summary>
   public  class cmdReturnImages
    {
       /// <summary>
       /// Create object of Entity RMASystem.
       /// </summary>
       Shipping_ManagerEntities1 entRMA = new Shipping_ManagerEntities1();


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
               ReturnImage _RImages = new ReturnImage();
               _RImages = entRMA.ReturnImages.SingleOrDefault(ret => ret.ReturnImageID == Returnimage.ReturnDetailID);
               if (_RImages == null)
               {
                   _RImages = new ReturnImage();
                   _RImages.ReturnImageID = Returnimage.ReturnImageID;
                   _RImages.ReturnDetailID = Returnimage.ReturnDetailID;
                   _RImages.SKUImagePath = Returnimage.SKUImagePath;
                   _RImages.CreatedBy = Returnimage.CreatedBy;
                   _RImages.UpadatedBy = Returnimage.UpadatedBy;
                   _RImages.CreatedDate = Returnimage.CreatedDate;
                   _RImages.UpadatedDate = Returnimage.UpadatedDate;

                   entRMA.AddToReturnImages(_RImages);
               }
               else
               {
                   _RImages.ReturnDetailID = Returnimage.ReturnDetailID;
                   _RImages.SKUImagePath = Returnimage.SKUImagePath;
                   _RImages.CreatedBy = Returnimage.CreatedBy;
                   _RImages.UpadatedBy = Returnimage.UpadatedBy;
                   _RImages.CreatedDate = Returnimage.CreatedDate;
                   _RImages.UpadatedDate = Returnimage.UpadatedDate;
               }
               entRMA.SaveChanges();
               _flag = true;
           }
           catch (Exception)
           {
           }
           return _flag;
       }

        #region Get methods for Return Images.

       /// <summary>
       /// Get image from Returnimage table. 
       /// </summary>
       /// <param name="ReturnDetailID">
       /// pass ReturnDetailID as parameter.
       /// </param>
       /// <returns>
       /// return String.
       /// </returns>
       public List<ReturnImagesDTO> PathImage(Guid ReturnDetailID)
       {
           List<ReturnImagesDTO> _lsimage = new List<ReturnImagesDTO>();
           try
           {
              // path = entRMA.ReturnImages.SingleOrDefault(r => r.ReturnDetailID == ReturnImageID).ToString();
               var image = (from img in entRMA.ReturnImages
                            where img.ReturnDetailID == ReturnDetailID
                            select img).ToList();

               foreach (var item in image)
               {
                   ReturnImagesDTO imagepath = new ReturnImagesDTO(item);
                   _lsimage.Add(imagepath);
               }
           }
           catch (Exception)
           {
           }
           return _lsimage;
       }


       public List<String> PathImageStringList(Guid ReturnDetailID)
       {
           List<String> _lsimage = new List<String>();
           try
           {
               // path = entRMA.ReturnImages.SingleOrDefault(r => r.ReturnDetailID == ReturnImageID).ToString();
               var image = (from img in entRMA.ReturnImages
                            where img.ReturnDetailID == ReturnDetailID
                            select img).ToList();

               foreach (var item in image)
               {
                   _lsimage.Add(item.SKUImagePath.ToString());
               }
           }
           catch (Exception)
           {
           }
           return _lsimage;
       }
        

        #endregion

    }
}
