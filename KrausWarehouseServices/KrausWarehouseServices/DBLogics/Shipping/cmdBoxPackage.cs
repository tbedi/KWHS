using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO;

namespace KrausWarehouseServices.DBLogics.Shipping
{
   public class cmdBoxPackage
    {
       
       /// <summary>
       /// Shipping Database class object.
       /// </summary>
       Connections.Shipping.Shipping_ManagerEntities1 entShipping = new Connections.Shipping.Shipping_ManagerEntities1();

       #region Get Fucntions

       /// <summary>
       /// Get all BoxPackage Table Information
       /// </summary>
       /// <returns>List<DTO.Shipping.BoxPackageDTO></returns>
       public List<DTO.Shipping.BoxPackageDTO> GetAll()
       {
           List<DTO.Shipping.BoxPackageDTO> lsreturn = new List<DTO.Shipping.BoxPackageDTO>();
           try
           {
               var allBoxInfo = from b in entShipping.BoxPackages
                                select b;

               foreach (var _boxitem in allBoxInfo)
               {

                   lsreturn.Add(new DTO.Shipping.BoxPackageDTO(_boxitem));
               }
           }
           catch (Exception)
           { }
           return lsreturn;

       }

       /// <summary>
       /// Selected single Row by filter Box id
       /// </summary>
       /// <param name="BoxID">Guid Box ID</param>
       /// <returns>DTO.Shipping.BoxPackageDTO Object</returns>
       public DTO.Shipping.BoxPackageDTO GetSelectedByBoxID(Guid BoxID)
       {
           DTO.Shipping.BoxPackageDTO _return = new DTO.Shipping.BoxPackageDTO();
           try
           {
              Connections.Shipping.BoxPackage _boxitem = entShipping.BoxPackages.SingleOrDefault(i => i.BoxID == BoxID);

              DTO.Shipping.BoxPackageDTO _box = new DTO.Shipping.BoxPackageDTO(_boxitem);
               _return = _box;
           }
           catch (Exception)
           { }
           return _return;
       }

       /// <summary>
       /// Get BoxPackage Table information sorted by BOXNUM
       /// </summary>
       /// <param name="BoxNumber">String Box Nuber</param>
       /// <returns>BoxPackage Object </returns>
       public DTO.Shipping.BoxPackageDTO GetSelectedByBoxNumber(String BoxNumber)
       {
           DTO.Shipping.BoxPackageDTO _return = new DTO.Shipping.BoxPackageDTO();
           try
           {
               _return = new DTO.Shipping.BoxPackageDTO(entShipping.BoxPackages.SingleOrDefault(i => i.BOXNUM == BoxNumber));

           }
           catch (Exception)
           { }
           return _return;
       }

       /// <summary>
       /// list of information by Packing ID
       /// </summary>
       /// <param name="PackingID">Guid Packing ID</param>
       /// <returns>List<DTO.Shipping.BoxPackageDTO> </returns>
       public List<DTO.Shipping.BoxPackageDTO> GetSelectedByPackingID(Guid PackingID)
       {
           List<DTO.Shipping.BoxPackageDTO> lsreturn = new List<DTO.Shipping.BoxPackageDTO>();
           try
           {
               var allBoxInfo = from b in entShipping.BoxPackages
                                where b.PackingID == PackingID
                                select b;

               foreach (var _boxitem in allBoxInfo)
               {
                   lsreturn.Add(new DTO.Shipping.BoxPackageDTO(_boxitem));
               }
           }
           catch (Exception)
           { }
           return lsreturn;
       }

       #endregion

       #region Set Functions

       /// <summary>
       /// Save Box information to the database
       /// </summary>
       /// <param name="lsBoxpackage">list of information of box</param>
       /// <returns>Guid of New Box Id</returns>
       public Boolean UpsertBoxPackage(List<DTO.Shipping.BoxPackageDTO> lsBoxpackage)
       {
           Boolean _return = false;
           try
           {
               foreach (var _boxitem in lsBoxpackage)
               {
                   Connections.Shipping.BoxPackage _boxPackage = new Connections.Shipping.BoxPackage();
                   _boxPackage = entShipping.BoxPackages.SingleOrDefault(i => i.BoxID == _boxitem.BoxID);
                   if (_boxPackage ==null)
                   {
                       _boxPackage = new Connections.Shipping.BoxPackage();
                       _boxPackage.BoxID = _boxitem.BoxID;
                       _boxPackage.PackingID = _boxitem.PackingID;
                       _boxPackage.BoxType = _boxitem.BoxType;
                       _boxPackage.BoxWeight = _boxitem.BoxWeight;
                       _boxPackage.BoxLength = _boxitem.BoxLength;
                       _boxPackage.BoxHeight = _boxitem.BoxHeight;
                       _boxPackage.BoxWidth = _boxitem.BoxWidth;
                       _boxPackage.BoxCreatedTime = _boxitem.BoxCreatedTime;
                       _boxPackage.BoxMeasurementTime = _boxitem.BoxMeasurementTime;
                       entShipping.AddToBoxPackages(_boxPackage);
                   }
                   else
                   {
                       _boxPackage.PackingID = _boxitem.PackingID;
                       _boxPackage.BoxType = _boxitem.BoxType;
                       _boxPackage.BoxWeight = _boxitem.BoxWeight;
                       _boxPackage.BoxLength = _boxitem.BoxLength;
                       _boxPackage.BoxHeight = _boxitem.BoxHeight;
                       _boxPackage.BoxWidth = _boxitem.BoxWidth;
                       _boxPackage.BoxCreatedTime = _boxitem.BoxCreatedTime;
                       _boxPackage.BoxMeasurementTime = _boxitem.BoxMeasurementTime;
                       
                   }
                   _return = true;
               }
               entShipping.SaveChanges();
           }
           catch (Exception)
           { }
           return _return;
       }

       #endregion
    }
}
