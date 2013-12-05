using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.DTO.Shipping;
using KrausWarehouseServices.Connections.Shipping;

namespace KrausWarehouseServices.DBLogics.Shipping
{
  public class cmdPackageDetail
    {
      /// <summary>
      /// Create Entity Object.
      /// </summary>
      Shipping_ManagerEntities1 entshipping = new Shipping_ManagerEntities1();

      #region Set Package Details Functions.
      /// <summary>
      /// Save the list values to the packing Detail table.
      /// </summary>
      /// <param name="lsPackingOb">list of values of packing Detail </param>
      /// <returns>Success if transaction Success else Fail.</returns>
      public string savePackageDetails(List<PackageDetailDTO> lsPackingOb)
      {
          string Retuen = "Fail";
          try
          {
              foreach (var _PakingDetails in lsPackingOb)
              {
                  PackageDetail _Packing = new PackageDetail();
                  _Packing.PackingDetailID = Guid.NewGuid();
                  _Packing.PackingId = _PakingDetails.PackingId;
                  _Packing.SKUNumber = _PakingDetails.SKUNumber;
                  _Packing.SKUQuantity = _PakingDetails.SKUQuantity;
                  _Packing.SKUScanDateTime = Convert.ToDateTime(_PakingDetails.PackingDetailStartDateTime);
                  _Packing.BoxNumber = _PakingDetails.BoxNumber;
                  _Packing.ShipmentLocation = _PakingDetails.ShipmentLocation;

                  //view added extra
                  _Packing.ItemName = _PakingDetails.ItemName;
                  _Packing.ProductName = _PakingDetails.ProductName;
                  _Packing.UnitOfMeasure = _PakingDetails.UnitOfMeasure;
                  _Packing.CountryOfOrigin = _PakingDetails.CountryOfOrigin;
                  _Packing.MAP_Price = _PakingDetails.MAP_Price;
                  _Packing.TCLCOD_0 = _PakingDetails.TCLCOD_0;
                  _Packing.TarrifCode = _PakingDetails.TarrifCode;
                  //created Time set
                  _Packing.CreatedDateTime = DateTime.UtcNow;
                  _Packing.CreatedBy = GlobalClasses.ClGlobal.UserID;
                  entshipping.AddToPackageDetails(_Packing);
              }
              entshipping.SaveChanges();
              Retuen = "Success";
          }
          catch (Exception Ex)
          {
              Error_Loger.elAction.save("SetPakingDetailsCommand.Execute()", Ex.Message.ToString());
          }
          return Retuen;
      }
      #endregion
    }
}
