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
        DBLogics.Shipping.viewGet_Shipping_Data _GetShippingData = new DBLogics.Shipping.viewGet_Shipping_Data();

        /// <summary>
        /// cmdAudit new Object. 
        /// </summary>
        DBLogics.Shipping.cmdAudit _returnAudit = new DBLogics.Shipping.cmdAudit();

        /// <summary>
        /// cmdpackage new object.
        /// </summary>
        DBLogics.Shipping.cmdPackage _returnPackage = new DBLogics.Shipping.cmdPackage();

        /// <summary>
        /// cmdpackagedetail New Object.
        /// </summary>
        DBLogics.Shipping.cmdPackageDetail _returnPackageDetail = new DBLogics.Shipping.cmdPackageDetail();

        /// <summary>
        ///cmdRole New Object. 
        /// </summary>
        DBLogics.Shipping.cmdRole _returnRole = new DBLogics.Shipping.cmdRole();

        /// <summary>
        /// CmdShipping New Object.
        /// </summary>
        DBLogics.Shipping.cmdShipping _returnShipping = new DBLogics.Shipping.cmdShipping();

        /// <summary>
        /// cmdStationMaster New Object.
        /// </summary>
        DBLogics.Shipping.cmdStationMaster _returnStation = new DBLogics.Shipping.cmdStationMaster();

        /// <summary>
        /// cmdtracking New Object.
        /// </summary>
        DBLogics.Shipping.cmdTracking _returnTracking = new DBLogics.Shipping.cmdTracking();

        /// <summary>
        /// cmduser new Object.
        /// </summary>
        DBLogics.Shipping.cmdUser _returnUser = new DBLogics.Shipping.cmdUser();

        /// <summary>
        /// cmduserstation new Object.
        /// </summary>
        DBLogics.Shipping.cmdUserStation _returnUserStation = new DBLogics.Shipping.cmdUserStation();

        /// <summary>
        /// cmdErrorLog new Object.
        /// </summary>
        DBLogics.Shipping.cmdErrorLog _returnErrorLog = new DBLogics.Shipping.cmdErrorLog();

        /// <summary>
        /// cmdboxpackage new Object.
        /// </summary>
        DBLogics.Shipping.cmdBoxPackage _returnBoxPackage = new DBLogics.Shipping.cmdBoxPackage();

        #endregion

      

        public bool Package(List<DTO.Shipping.PackageDTO> _package)
        {
            return _returnPackage.UpsertPackage(_package);
        }

        public bool PackageDetail(List<DTO.Shipping.PackageDetailDTO> _packagedetail)
        {
            return _returnPackageDetail.UpsertPackageDetails(_packagedetail);
        }

        public bool Role(List<DTO.Shipping.RoleDTO> _role)
        {
            return _returnRole.UpsertRole(_role);
        }
        public bool Shipping(List<DTO.Shipping.ShippingDTO> _shipping)
        {
            return _returnShipping.UpsertShipping(_shipping);
        }

        public bool StationMaster(List<DTO.Shipping.StationMasterDTO> _stationmaster)
        {
            return _returnStation.UpsertStation(_stationmaster);
        }

        public bool User(List<DTO.Shipping.UserDTO> _user)
        {
            return _returnUser.UsertUser(_user);
        }

        public bool UserStation(List<DTO.Shipping.UserStationDTO> _userstation)
        {
            return _returnUserStation.UpsertUserStation(_userstation);
        }

        public bool ErrorLog(List<DTO.Shipping.ErrorLogDTO> _errorlog)
        {
            return _returnErrorLog.UpsertErrorLog(_errorlog);
        }

        public bool Audit(List<DTO.Shipping.AutditDTO> _audit)
        {
            return _returnAudit.UpsertAuditLog(_audit);
        }


        public bool BoxPackage(List<DTO.Shipping.BoxPackageDTO> _boxpackage)
        {
            return _returnBoxPackage.UpsertBoxPackage(_boxpackage);
        }
        
        public bool TrackingUpdateByReadytoExpert(string TrackingNo, string BoxNumber, bool ReadyToExpert)
        {
            return _returnTracking.UpdateTracking(TrackingNo, BoxNumber, ReadyToExpert);
        }


        public bool UpdateByUser(List<DTO.Shipping.UserDTO> _user, Guid UserID)
        {
            return _returnUser.UserMasterByUserID(_user,UserID);
        }
    }
}
