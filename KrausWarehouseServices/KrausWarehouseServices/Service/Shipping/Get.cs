using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.Shipping
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Get" in both code and config file together.
    public class Get : IGet
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

        #region View Get_Shipping_Data

        public List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataAll()
        {
            return _GetShippingData.GetAll();
        }

        public List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataByShippingNumber(string ShippingNumber)
        {
            return _GetShippingData.GeByShipmentID(ShippingNumber);
        }

        public List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataByLocation(string Location)
        {
            return _GetShippingData.GeByLocation(Location);
        } 

        #endregion

        #region Audit
        
        

        public List<DTO.Shipping.AutditDTO> AllAudit()
        {
            throw new NotImplementedException();
        }

        public List<DTO.Shipping.AutditDTO> ByAuditID(Guid AuditID)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Package
        
        
        public List<DTO.Shipping.PackageDTO> AllPackge()
        {
            return _GetPackage.GetAll();
        }

        public List<DTO.Shipping.PackageDTO> ByPackageID(Guid PackageID)
        {
            return _GetPackage.GetByPackageID(PackageID);
        }

        public List<DTO.Shipping.PackageDTO> ByStationID(Guid StationID)
        {
            return _GetPackage.GetByStationID(StationID);
        }

        public List<DTO.Shipping.PackageDTO> ByUserID(Guid UserID)
        {
            return _GetPackage.GetByUserID(UserID);
        }

        public List<DTO.Shipping.PackageDTO> ByShippingID(Guid ShippingID)
        {
            return _GetPackage.GetByShipping(ShippingID);
        }

        public List<DTO.Shipping.PackageDTO> ByShippingNum(string ShippingNum)
        {
            return _GetPackage.GetByShippingNum(ShippingNum);
        }

        #endregion

        #region PackageDetail
        
        

        public List<DTO.Shipping.PackageDetailDTO> AllPackageDetail()
        {
            return _GetPackageDetail.GetAll();
        }

        public List<DTO.Shipping.PackageDetailDTO> ByPackingID(Guid PackingID)
        {
            return _GetPackageDetail.GetByPackingID(PackingID);
        }

        public List<DTO.Shipping.PackageDetailDTO> ByBoxNumber(string BoxNumber)
        {
            return _GetPackageDetail.GetByBoxNumber(BoxNumber);
        }

        #endregion

        #region Role
        
        

        public List<DTO.Shipping.RoleDTO> AllRoles()
        {
            return _GetRole.GetAll();
        }

        public List<DTO.Shipping.RoleDTO> ByRoleID(Guid RoleID)
        {
            return _GetRole.GetRoleByRoleID(RoleID);
        }

        #endregion


        #region Shipping
        
        
        public List<DTO.Shipping.ShippingDTO> AllShipping()
        {
            return _GetShipping.GetAll();
        }

        List<DTO.Shipping.ShippingDTO> IGet.ByShippingID(Guid ShippingID)
        {
            return _GetShipping.GetByShippingID(ShippingID);
        }

        List<DTO.Shipping.ShippingDTO> IGet.ByShippingNum(string ShippingNum)
        {
            return _GetShipping.GetByShippingNum(ShippingNum);
        }

        public List<DTO.Shipping.ShippingDTO> ByOrderID(string OrderID)
        {
            return _GetShipping.GetByOrderID(OrderID);
        }

        public List<DTO.Shipping.ShippingDTO> ByCustomerPO(string CustomerPO)
        {
            return _GetShipping.GetByCustomerPO(CustomerPO);
        }

        public List<DTO.Shipping.ShippingDTO> ByVendorName(string VendorName)
        {
            return _GetShipping.GetByVenderName(VendorName);
        }

        public List<DTO.Shipping.ShippingDTO> ByVendorNum(string VendorNum)
        {
            return _GetShipping.GetByVenderNum(VendorNum);
        }

        public List<DTO.Shipping.ShippingDTO> ByCarrier(string Carrier)
        {
            return _GetShipping.GetByCarrier(Carrier);
        }

        public List<DTO.Shipping.ShippingDTO> ByShippingROWID(string ShippingROWID)
        {
            return _GetShipping.GetByShippingROWID(ShippingROWID);
        }

        public List<DTO.Shipping.ShippingDTO> ByGetByFromDateToDate(DateTime FromDate, DateTime ToDate)
        {
            return _GetShipping.GetByFromDateToDate(FromDate, ToDate);
        }

        #endregion

        #region Station
        
        

        public List<DTO.Shipping.StationMasterDTO> AllStation()
        {
            return _GetStation.GetAll();
        }

        List<DTO.Shipping.StationMasterDTO> IGet.ByStationID(Guid StaionID)
        {
            return _GetStation.GetByStationID(StaionID);
        }

        public List<DTO.Shipping.StationMasterDTO> ByStationName(string StationName)
        {
            return _GetStation.GetByStattionName(StationName);
        }

        public List<DTO.Shipping.StationMasterDTO> ByRequestedUserID(Guid RequestedUserID)
        {
            return _GetStation.GetByRequestedUserID(RequestedUserID);
        }

        #endregion

        #region Tracking
        
        

        public List<DTO.Shipping.TrackingDTO> All()
        {
            return _GetTracking.GetAll();
        }

        public List<DTO.Shipping.TrackingDTO> ByTrackingID(Guid TrackingID)
        {
            return _GetTracking.GetByTrackingID(TrackingID);
        }

        List<DTO.Shipping.TrackingDTO> IGet.ByPackingID(Guid PackingID)
        {
            return _GetTracking.GetByPackingID(PackingID);
        }

        List<DTO.Shipping.TrackingDTO> IGet.ByShippingID(Guid ShippingID)
        {
            return _GetTracking.GetByShippingID(ShippingID);
        }

        public List<DTO.Shipping.TrackingDTO> ByBoxID(Guid BoxID)
        {
            return _GetTracking.GetByBoxID(BoxID);
        }

        public List<DTO.Shipping.TrackingDTO> ByTrackingNUmber(string TrackingNUmber)
        {
            return _GetTracking.GetByTrackingNUmber(TrackingNUmber);
        }

        public List<DTO.Shipping.TrackingDTO> ByVendorID(string VendorID)
        {
            return _GetTracking.GetByVenderID(VendorID);
        }

        public List<DTO.Shipping.TrackingDTO> ByBoxNum(string BoxNum)
        {
            return _GetTracking.GetByBoxNum(BoxNum);
        }

        #endregion

        #region User
        
        

        public List<DTO.Shipping.UserDTO> AllUser()
        {
            return _GetUser.GetAll();
        }

        List<DTO.Shipping.UserDTO> IGet.ByUserID(Guid UserID)
        {
            return _GetUser.GetByUserID(UserID);
        }

        public List<DTO.Shipping.UserDTO> ByUserName(string UserName)
        {
            return _GetUser.GetByUserName(UserName);
        }

        List<DTO.Shipping.UserDTO> IGet.ByRoleID(Guid RoleID)
        {
            return _GetUser.GetByRoleID(RoleID);
        }

        public List<DTO.Shipping.UserDTO> ByRoleName(string RoleName)
        {
            return _GetUser.GetByRoleName(RoleName);
        }
        #endregion

        #region UserStation

        

        List<DTO.Shipping.UserStationDTO> IGet.AllUser()
        {
            return _GetUserStation.GetAll();
        }

        public List<DTO.Shipping.UserStationDTO> ByUserStationID(Guid UserStationID)
        {
            return _GetUserStation.GetByUserStationID(UserStationID);
        }

        List<DTO.Shipping.UserStationDTO> IGet.ByUserID(Guid UserID)
        {
            return _GetUserStation.GetByUserID(UserID);
        }

        List<DTO.Shipping.UserStationDTO> IGet.ByStationID(Guid StationID)
        {
            return _GetUserStation.GetByStationID(StationID);
        }

        #endregion
    }
}
