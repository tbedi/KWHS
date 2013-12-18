using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrausWarehouseServices.Connections.Shipping;
using KrausWarehouseServices.DTO.Shipping;
using System.Data.Objects;

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

        /// <summary>
        /// Get package by userID and Date
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        public List<PackageDTO> GetByUserIDAndDate(Guid UserID, DateTime Date)
        {
            List<PackageDTO> _lspackage = new List<PackageDTO>();

            try
            {
                var userpack = (from pack in entShippling.Packages
                                where pack.UserId == UserID &&
                                EntityFunctions.TruncateTime(pack.EndTime.Value) == EntityFunctions.TruncateTime(Date.Date)
                                select pack);

                foreach (var item in userpack)
                {
                    _lspackage.Add(new PackageDTO(item));
                }
            }
            catch (Exception)
            {
            }
            return _lspackage;

        }

        /// <summary>
        /// Get package by ShippingNum and Location.
        /// </summary>
        /// <param name="ShippingNum"></param>
        /// <param name="Location"></param>
        /// <returns></returns>
        public List<PackageDTO> GetShippingNumAndLocation(String ShippingNum, String Location)
        {
            List<PackageDTO> _lspackage = new List<PackageDTO>();
            try
            {
                var userpack = (from pack in entShippling.Packages
                                where pack.ShippingNum == ShippingNum &&
                                pack.ShipmentLocation == Location
                                select pack);

                foreach (var item in userpack)
                {
                    _lspackage.Add(new PackageDTO(item));
                }
            }
            catch (Exception)
            {
            }
            return _lspackage;


        }

        /// <summary>
        /// Get PackingID from PackingTable By PCKROWID
        /// </summary>
        /// <param name="PCKROWID"></param>
        /// <returns></returns>
        public Guid GetPackingID(String PCKROWID)
        {
            Guid _PackingID = new Guid();
            try
            {
                _PackingID = entShippling.Packages.SingleOrDefault(i => i.PCKROWID == PCKROWID).PackingId;
            }
            catch (Exception)
            {
            }
            return _PackingID;
        }

        /// <summary>
        /// Get MaxPackingID from PackingTable 
        /// </summary>
        /// <returns></returns>
        public string GetMaxPackageID()
        {
            string MaxID = "";
            try
            {
                Guid MaxGUiID = entShippling.Packages.Select(i => i.PackingId).ToList().Max();
                MaxID = entShippling.Packages.SingleOrDefault(i => i.PackingId == MaxGUiID).ShippingNum;

            }
            catch (Exception)
            {
            }
            return MaxID;
        }
        #endregion

        #region Upsert Method
        public Boolean UpsertPackage(List<PackageDTO> package)
        {
            Boolean _flag = false;
            try
            {
                foreach (var packgeitem in package)
                {

                    Package pack = new Package();
                    pack = entShippling.Packages.SingleOrDefault(re => re.PackingId == packgeitem.PackingId);

                    if (pack == null)
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
                        pack.ManagerOverride = packgeitem.MangerOverride;
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
                        pack.ManagerOverride = packgeitem.MangerOverride;
                        pack.PCKROWID = packgeitem.PCKROWID;
                        pack.ROWID = packgeitem.ROWID;
                        pack.CreatedBy = packgeitem.CreatedBy;
                        pack.Updatedby = packgeitem.Updatedby;
                        pack.UpdatedDateTime = packgeitem.UpdatedDateTime;
                        pack.CreatedDateTime = packgeitem.CreatedDateTime;
                    }
                }
                entShippling.SaveChanges();
                _flag = true;
            }
            catch (Exception)
            {
            }
            return _flag;
        }
        #endregion

        #region Delete 
        /// <summary>
        /// Roll Back Transaction Operations that delete the entry from the table Paking.
        /// For shipment ID
        /// </summary>
        /// <param name="ShipmentNum">Roll back entry from Shipment</param>
        /// <returns>Boolean if Transacetion Seccess else False</returns>
        public Boolean DeleteByShipmentNum(String ShipmentNum)
        {
            Boolean _return = false;
            try
            {
                Package _Packing = entShippling.Packages.SingleOrDefault(i => i.ShippingNum == ShipmentNum);
                entShippling.DeleteObject(_Packing);
                entShippling.SaveChanges();
                _return = true;
            }
            catch (Exception )
            {}
            return _return;
        }
        #endregion

    }
}
