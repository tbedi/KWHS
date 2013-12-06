using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.Shipping;

namespace KrausWarehouseServices.DBLogics.Shipping
{
    /// <summary>
    /// Get And Set Operation of package table.
    /// </summary>
    class cmdPackage
    {
        /// <summary>
        /// Create Object Of Entity Shipping.
        /// </summary>
        Shipping_ManagerEntities1 entShippling = new Shipping_ManagerEntities1();

        #region GET Methods

        /// <summary>
        /// Get All Records from The package Table.
        /// </summary>
        /// <returns></returns>
        public List<PackageDTO> GetAll()
        {
            List<PackageDTO> _lspackage = new List<PackageDTO>();
            try
            {
                var _package = (from packagelist in entShippling.Packages
                                select packagelist).ToList();

                foreach (var packageitem in _package)
                {
                    _lspackage.Add(new PackageDTO(packageitem));
                }
            }
            catch (Exception)
            {
            }
            return _lspackage;
        }

        /// <summary>
        /// Get all record By PackgeID from Package Table.
        /// </summary>
        /// <param name="_packageID">
        /// pass packageID as parameter.
        /// </param>
        /// <returns>
        /// Return list.
        /// </returns>
        public List<PackageDTO> GetByPackageID(Guid _packageID)
        {

            List<PackageDTO> _lspackage = new List<PackageDTO>();
            try
            {
                var package = (from pack in entShippling.Packages
                               where pack.PackingId == _packageID
                               select pack).ToList();

                foreach (var packageitem in package)
                {
                    _lspackage.Add(new PackageDTO(packageitem));    
                }
                
            }
            catch (Exception)
            {
            }
            return _lspackage;
        }
        #endregion

        /// <summary>
        /// Get All Data from The Package table By stationID.
        /// </summary>
        /// <param name="_stationID">
        /// pass StationId as parameter.
        /// </param>
        /// <returns>
        /// Return the List.
        /// </returns>
        public List<PackageDTO> GetByStationID(Guid _stationID)
        {
            List<PackageDTO> _lspackage = new List<PackageDTO>();
            try
            {
                var pack = (from package in entShippling.Packages
                            where package.StationID == _stationID
                            select package).ToList();

                foreach (var packageitem in pack)
                {
                    _lspackage.Add(new PackageDTO(packageitem));    
                }
            }
            catch (Exception)
            {
            }

            return _lspackage;
        }

        /// <summary>
        /// get record from package by userid
        /// </summary>
        /// <param name="_userID">
        /// pass userID as parameter.
        /// </param>
        /// <returns>
        /// return list.
        /// </returns>
        public List<PackageDTO> GetByUserID(Guid _userID)
        {
            List<PackageDTO> _lspackage = new List<PackageDTO>();
            try
            {
                var packuser = (from pack in entShippling.Packages
                                where pack.UserId == _userID
                                select pack).ToList();
                foreach (var packageitem in packuser)
                {
                    _lspackage.Add(new PackageDTO(packageitem));
                }
            }
            catch (Exception)
            {
            }
            return _lspackage;
        }


        /// <summary>
        /// get record from package by shippingID
        /// </summary>
        /// <param name="_shippingID">
        /// pass shippingID as parameter.
        /// </param>
        /// <returns>
        /// return list.
        /// </returns>
        public List<PackageDTO> GetByShipping(Guid _shippingID)
        {
            List<PackageDTO> _lspackage = new List<PackageDTO>();
            try
            {
                var packuser = (from pack in entShippling.Packages
                                where pack.ShippingID == _shippingID
                                select pack).ToList();
                foreach (var packageitem in packuser)
                {
                    _lspackage.Add(new PackageDTO(packageitem));
                }
            }
            catch (Exception)
            {
            }
            return _lspackage;
        }

        /// <summary>
        /// get record from package by ShippingNum
        /// </summary>
        /// <param name="_ShippingNum">
        /// pass ShippingNum as parameter.
        /// </param>
        /// <returns>
        /// return list.
        /// </returns>
        public List<PackageDTO> GetByShippingNum(String _ShippingNum)
        {
            List<PackageDTO> _lspackage = new List<PackageDTO>();
            try
            {
                var packuser = (from pack in entShippling.Packages
                                where pack.ShippingNum == _ShippingNum
                                select pack).ToList();
                foreach (var packageitem in packuser)
                {
                    _lspackage.Add(new PackageDTO(packageitem));
                }
            }
            catch (Exception)
            {
            }
            return _lspackage;
        }


        #region Upsert Method
        public Boolean UpsertPackage(List<PackageDTO> package)
        {
            Boolean _flag = false;
            try
            {
                foreach (var packgeitem in package)
                {

                    Package pack ;
                    pack = entShippling.Packages.SingleOrDefault(re => re.PackingId == packgeitem.PackingId);
                    
                    if (pack.PackingId == Guid.Empty)
                    {
                        pack = new Package();
                        pack.PackingId = packgeitem.PackingId;
                        pack.UserId = packgeitem.UserID;
                        pack.StationID = packgeitem.StationID;
                        pack.ShippingNum = packgeitem.ShippingNum;
                        pack.StartTime = packgeitem.StartTime;
                        pack.EndTime = packgeitem.EndTime;
                        pack.PackingStatus = packgeitem.PackingStatus;
                        pack.ShippingID = packgeitem.ShippingID;
                        pack.ShipmentLocation = packgeitem.ShipmentLocation;
                        pack.ManagerOverride=packgeitem.MangerOverride;
                        pack.PCKROWID = packgeitem.PCKROWID;
                        pack.ROWID = packgeitem.ROWID;
                        pack.CreatedBy = packgeitem.CreatedBy;
                        pack.Updatedby = packgeitem.Updatedby;
                        pack.UpdatedDateTime = packgeitem.UpdatedDateTime;
                        pack.CreatedDateTime = packgeitem.CreatedDateTime;
                        entShippling.AddToPackages(pack);
                    }
                    else
                    {
                        pack.UserId = packgeitem.UserID;
                        pack.StationID = packgeitem.StationID;
                        pack.ShippingNum = packgeitem.ShippingNum;
                        pack.StartTime = packgeitem.StartTime;
                        pack.EndTime = packgeitem.EndTime;
                        pack.PackingStatus = packgeitem.PackingStatus;
                        pack.ShippingID = packgeitem.ShippingID;
                        pack.ShipmentLocation = packgeitem.ShipmentLocation;
                        pack.ManagerOverride=packgeitem.MangerOverride;
                        pack.PCKROWID = packgeitem.PCKROWID;
                        pack.ROWID = packgeitem.ROWID;
                        pack.CreatedBy = packgeitem.CreatedBy;
                        pack.Updatedby = packgeitem.Updatedby;
                        pack.UpdatedDateTime = packgeitem.UpdatedDateTime;
                        pack.CreatedDateTime = packgeitem.CreatedDateTime;
                    }
                }
                entShippling.SaveChanges();
               _flag=true;
              }
            catch (Exception)
            {
            }
            return _flag;
        }
        #endregion

    }
}
