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
        public Boolean UpsertPackageDetails(List<PackageDetailDTO> lsPackingOb)
        {
            Boolean _Retuen = true;
            try
            {
                foreach (var _PakingDetails in lsPackingOb)
                {
                    PackageDetail _Packing = new PackageDetail();
                        _Packing = entshipping.PackageDetails.FirstOrDefault(i => i.PackingDetailID == _PakingDetails.PackagedetailID);
                    if (_Packing== null)
                    {
                        _Packing = new PackageDetail();
                        _Packing.PackingDetailID = _PakingDetails.PackagedetailID;
                        _Packing.PackingId = _PakingDetails.PackingId;
                        _Packing.SKUNumber = _PakingDetails.SKUNumber;
                        _Packing.SKUQuantity = _PakingDetails.SKUQuantity;
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
                        _Packing.CreatedDateTime = _PakingDetails.CreatedDateTime;
                        _Packing.CreatedBy = _PakingDetails.CreatedBy;
                        entshipping.AddToPackageDetails(_Packing);
                    }
                    else
                    {
                        _Packing.PackingId = _PakingDetails.PackingId;
                        _Packing.SKUNumber = _PakingDetails.SKUNumber;
                        _Packing.SKUQuantity = _PakingDetails.SKUQuantity;
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
                        _Packing.CreatedDateTime = _PakingDetails.CreatedDateTime;
                        _Packing.CreatedBy = _PakingDetails.CreatedBy;
                    }
                }
                entshipping.SaveChanges();
                _Retuen = true;
            }
            catch (Exception)
            {
            }
            return _Retuen;
        }

        #endregion

        #region Get Packing Detail.

        /// <summary>
        /// Get all rows form Packing Deails table.
        /// </summary>
        /// <returns>
        /// List of PackingDetailDTO Object. 
        /// </returns>
        public List<PackageDetailDTO> GetAll()
        {
            List<PackageDetailDTO> _lsReturn = new List<PackageDetailDTO>();
            try
            {
                var PackingItems = (from ls in entshipping.PackageDetails select ls).ToList();

                foreach (var _pckitem in PackingItems)
                {
                    _lsReturn.Add(new PackageDetailDTO(_pckitem));
                }
            }
            catch (Exception)
            {
            }

            return _lsReturn;

        }


        /// <summary>
        /// Packing Details table filtered object.
        /// </summary>
        /// <param name="PackingID">
        /// Guid PackingID
        /// </param>
        /// <returns>
        /// list of packing Details object filtered by PackingID.
        /// </returns>
        public List<PackageDetailDTO> GetByPackingID(Guid PackingID)
        {
            List<PackageDetailDTO> _lsReturn = new List<PackageDetailDTO>();
            try
            {
                var PackingItems = (from ls in entshipping.PackageDetails
                                    where ls.PackingId == PackingID
                                    select ls).ToList();

                foreach (var _pckitem in PackingItems)
                {
                    _lsReturn.Add(new PackageDetailDTO(_pckitem));
                }
            }
            catch (Exception)
            {
            }
            return _lsReturn;
        }

        /// <summary>
        /// Packing Details table filtered object.
        /// </summary>
        /// <param name="BoxNumber">
        /// String Box Number.
        /// </param>
        /// <returns>
        /// list of Packing details table information 
        /// </returns>
        public List<PackageDetailDTO> GetByBoxNumber(String BoxNumber)
        {
            List<PackageDetailDTO> _lsReturn = new List<PackageDetailDTO>();
            try
            {
                var PackingItems = (from ls in entshipping.PackageDetails
                                    where ls.BoxNumber == BoxNumber
                                    select ls).ToList();

                foreach (var _pckitem in PackingItems)
                {
                    _lsReturn.Add(new PackageDetailDTO(_pckitem));
                }
            }
            catch (Exception)
            {
            }
            return _lsReturn;
        }

        #endregion

    }
}
