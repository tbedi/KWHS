﻿using System;
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
            return _GetAudit.GetUserLog();
        }

        //public List<DTO.Shipping.AutditDTO> ByAuditID(Guid UserID)
        //{
        //    return _GetAudit.
        //}

        #endregion

        #region Package


        public List<DTO.Shipping.PackageDTO> PackageAllPackge()
        {
            return _GetPackage.GetAll();
        }

        public List<DTO.Shipping.PackageDTO> PackageByPackageID(Guid PackageID)
        {
            return _GetPackage.GetByPackageID(PackageID);
        }

        public List<DTO.Shipping.PackageDTO> PackageByStationID(Guid StationID)
        {
            return _GetPackage.GetByStationID(StationID);
        }

        public List<DTO.Shipping.PackageDTO> PackageByUserID(Guid UserID)
        {
            return _GetPackage.GetByUserID(UserID);
        }

        public List<DTO.Shipping.PackageDTO> PackageByShippingID(Guid ShippingID)
        {
            return _GetPackage.GetByShipping(ShippingID);
        }

        public List<DTO.Shipping.PackageDTO> PackageByShippingNum(string ShippingNum)
        {
            return _GetPackage.GetByShippingNum(ShippingNum);
        }

        #endregion

        #region PackageDetail



        public List<DTO.Shipping.PackageDetailDTO> PackageDetailAllPackageDetail()
        {
            return _GetPackageDetail.GetAll();
        }

        public List<DTO.Shipping.PackageDetailDTO> PackageDetailByPackingID(Guid PackingID)
        {
            return _GetPackageDetail.GetByPackingID(PackingID);
        }

        public List<DTO.Shipping.PackageDetailDTO> PackageDetailByBoxNumber(string BoxNumber)
        {
            return _GetPackageDetail.GetByBoxNumber(BoxNumber);
        }

        #endregion

        #region Role



        public List<DTO.Shipping.RoleDTO> RoleAllRoles()
        {
            return _GetRole.GetAll();
        }

        public List<DTO.Shipping.RoleDTO> RoleByRoleID(Guid RoleID)
        {
            return _GetRole.GetRoleByRoleID(RoleID);
        }

        #endregion


        #region Shipping


        public List<DTO.Shipping.ShippingDTO> ShippingAllShipping()
        {
            return _GetShipping.GetAll();
        }

       public List<DTO.Shipping.ShippingDTO> ShippingByShippingID(Guid ShippingID)
        {
            return _GetShipping.GetByShippingID(ShippingID);
        }

       public List<DTO.Shipping.ShippingDTO> ShippingByShippingNum(string ShippingNum)
        {
            return _GetShipping.GetByShippingNum(ShippingNum);
        }

        public List<DTO.Shipping.ShippingDTO> ShippingByOrderID(string OrderID)
        {
            return _GetShipping.GetByOrderID(OrderID);
        }

        public List<DTO.Shipping.ShippingDTO> ShippingByCustomerPO(string CustomerPO)
        {
            return _GetShipping.GetByCustomerPO(CustomerPO);
        }

        public List<DTO.Shipping.ShippingDTO> ShippingByVendorName(string VendorName)
        {
            return _GetShipping.GetByVenderName(VendorName);
        }

        public List<DTO.Shipping.ShippingDTO> ShippingByVendorNum(string VendorNum)
        {
            return _GetShipping.GetByVenderNum(VendorNum);
        }

        public List<DTO.Shipping.ShippingDTO> ShippingByCarrier(string Carrier)
        {
            return _GetShipping.GetByCarrier(Carrier);
        }

        public List<DTO.Shipping.ShippingDTO> ShippingByShippingROWID(string ShippingROWID)
        {
            return _GetShipping.GetByShippingROWID(ShippingROWID);
        }

        public List<DTO.Shipping.ShippingDTO> ShippingByGetByFromDateToDate(DateTime FromDate, DateTime ToDate)
        {
            return _GetShipping.GetByFromDateToDate(FromDate, ToDate);
        }

        #endregion

        #region Station



        public List<DTO.Shipping.StationMasterDTO> StationMasterAllStation()
        {
            return _GetStation.GetAll();
        }

      public  List<DTO.Shipping.StationMasterDTO> StationMasterByStationID(Guid StaionID)
        {
            return _GetStation.GetByStationID(StaionID);
        }

        public List<DTO.Shipping.StationMasterDTO> StationMasterByStationName(string StationName)
        {
            return _GetStation.GetByStattionName(StationName);
        }

        public List<DTO.Shipping.StationMasterDTO> StationMasterByRequestedUserID(Guid RequestedUserID)
        {
            return _GetStation.GetByRequestedUserID(RequestedUserID);
        }

        #endregion

        #region Tracking



        public List<DTO.Shipping.TrackingDTO> TrackingAll()
        {
            return _GetTracking.GetAll();
        }

        public List<DTO.Shipping.TrackingDTO> TrackingByTrackingID(Guid TrackingID)
        {
            return _GetTracking.GetByTrackingID(TrackingID);
        }

       public  List<DTO.Shipping.TrackingDTO> TrackingByPackingID(Guid PackingID)
        {
            return _GetTracking.GetByPackingID(PackingID);
        }

       public List<DTO.Shipping.TrackingDTO> TrackingByShippingID(Guid ShippingID)
        {
            return _GetTracking.GetByShippingID(ShippingID);
        }

        public List<DTO.Shipping.TrackingDTO> TrackingByBoxID(Guid BoxID)
        {
            return _GetTracking.GetByBoxID(BoxID);
        }

        public List<DTO.Shipping.TrackingDTO> TrackingByTrackingNUmber(string TrackingNUmber)
        {
            return _GetTracking.GetByTrackingNUmber(TrackingNUmber);
        }

        public List<DTO.Shipping.TrackingDTO> TrackingByVendorID(string VendorID)
        {
            return _GetTracking.GetByVenderID(VendorID);
        }

        public List<DTO.Shipping.TrackingDTO> TrackingByBoxNum(string BoxNum)
        {
            return _GetTracking.GetByBoxNum(BoxNum);
        }

        #endregion

        #region User



        public List<DTO.Shipping.UserDTO> UserAllUser()
        {
            return _GetUser.GetAll();
        }

        public List<DTO.Shipping.UserDTO> UserByUserID(Guid UserID)
        {
            return _GetUser.GetByUserID(UserID);
        }

        public List<DTO.Shipping.UserDTO> UserByUserName(string UserName)
        {
            return _GetUser.GetByUserName(UserName);
        }

        public List<DTO.Shipping.UserDTO> UserByRoleID(Guid RoleID)
        {
            return _GetUser.GetByRoleID(RoleID);
        }

        public List<DTO.Shipping.UserDTO> UserByRoleName(string RoleName)
        {
            return _GetUser.GetByRoleName(RoleName);
        }
        #endregion

        #region UserStation



        public List<DTO.Shipping.UserStationDTO> UserStationAllUser()
        {
            return _GetUserStation.GetAll();
        }

        public List<DTO.Shipping.UserStationDTO> UserStationByUserStationID(Guid UserStationID)
        {
            return _GetUserStation.GetByUserStationID(UserStationID);
        }

        public List<DTO.Shipping.UserStationDTO> UserStationByUserID(Guid UserID)
        {
            return _GetUserStation.GetByUserID(UserID);
        }
       public List<DTO.Shipping.UserStationDTO> UserStationByStationID(Guid StationID)
       {
           return _GetUserStation.GetByStationID(StationID);
       }  
        
        #endregion
    }
}