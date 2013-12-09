using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.Shipping
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Save" in both code and config file together.
    public class Save : ISave
    {

        #region Declarations.

        /// <summary>
        /// view Get_Shipping_Data new Object.
        /// </summary>
        DBLogics.Shipping.cmdGetShippingData _GetShippingData = new DBLogics.Shipping.cmdGetShippingData();

        /// <summary>
        /// cmdAudit new Object. 
        /// </summary>
        DBLogics.Shipping.cmdAudit _GetAudit = new DBLogics.Shipping.cmdAudit();

        /// <summary>
        /// cmdpackage new object.
        /// </summary>
        DBLogics.Shipping.cmdPackage _GetPackage = new DBLogics.Shipping.cmdPackage();

        /// <summary>
        /// cmdpackagedetail New Object.
        /// </summary>
        DBLogics.Shipping.cmdPackageDetail _GetPackageDetail = new DBLogics.Shipping.cmdPackageDetail();

        /// <summary>
        ///cmdRole New Object. 
        /// </summary>
        DBLogics.Shipping.cmdRole _GetRole = new DBLogics.Shipping.cmdRole();

        /// <summary>
        /// CmdShipping New Object.
        /// </summary>
        DBLogics.Shipping.cmdShipping _GetShipping = new DBLogics.Shipping.cmdShipping();

        /// <summary>
        /// cmdStationMaster New Object.
        /// </summary>
        DBLogics.Shipping.cmdStationMaster _GetStation = new DBLogics.Shipping.cmdStationMaster();

        /// <summary>
        /// cmdtracking New Object.
        /// </summary>
        DBLogics.Shipping.cmdTracking _GetTracking = new DBLogics.Shipping.cmdTracking();

        /// <summary>
        /// cmduser new Object.
        /// </summary>
        DBLogics.Shipping.cmdUser _GetUser = new DBLogics.Shipping.cmdUser();

        /// <summary>
        /// cmduserstation new Object.
        /// </summary>
        DBLogics.Shipping.cmdUserStation _GetUserStation = new DBLogics.Shipping.cmdUserStation();
        #endregion



        public bool Package(List<DTO.Shipping.PackageDTO> _package)
        {
            return _GetPackage.UpsertPackage(_package);
        }

        public bool PackageDetail(List<DTO.Shipping.PackageDetailDTO> _packagedetail)
        {
            return _GetPackageDetail.UpsertPackageDetails(_packagedetail);
        }

        public bool Role(List<DTO.Shipping.RoleDTO> _role)
        {
            return _GetRole.UpsertRole(_role);
        }
        public bool Shipping(List<DTO.Shipping.ShippingDTO> _shipping)
        {
            return _GetShipping.UpsertShipping(_shipping);
        }

        public bool StationMaster(List<DTO.Shipping.StationMasterDTO> _stationmaster)
        {
            return _GetStation.UpsertStation(_stationmaster);
        }

        public bool User(List<DTO.Shipping.UserDTO> _user)
        {
            return _GetUser.UsertUser(_user);
        }

        public bool UserStation(List<DTO.Shipping.UserStationDTO> _userstation)
        {
            return _GetUserStation.UpsertUserStation(_userstation);
        }
    }
}
