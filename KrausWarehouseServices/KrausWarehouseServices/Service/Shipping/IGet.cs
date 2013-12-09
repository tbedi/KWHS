using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KrausWarehouseServices.Service.Shipping
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGet" in both code and config file together.
    [ServiceContract]
    public interface IGet
    {
        #region Get_Shipping_Data

        [OperationContract]
        List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataAll();

        [OperationContract]
        List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataByShippingNumber(String ShippingNumber);

        [OperationContract]
        List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataByLocation(String Location); 

        #endregion

        #region Audit
        [OperationContract]
        List<DTO.Shipping.AutditDTO> AllAudit();

        [OperationContract]
        List<DTO.Shipping.AutditDTO> ByAuditID(Guid AuditID);

        //[OperationContract]
        //List<DTO.Shipping.
        #endregion

        #region Package
        [OperationContract]
        List<DTO.Shipping.PackageDTO> AllPackge();

        [OperationContract]
        List<DTO.Shipping.PackageDTO> ByPackageID(Guid PackageID);

        [OperationContract]
        List<DTO.Shipping.PackageDTO> ByStationID(Guid StationID);

        [OperationContract]
        List<DTO.Shipping.PackageDTO> ByUserID(Guid UserID);

        [OperationContract]
        List<DTO.Shipping.PackageDTO> ByShippingID(Guid ShippingID);

        [OperationContract]
        List<DTO.Shipping.PackageDTO> ByShippingNum(String ShippingNum);

        #endregion

        #region PackgeDetail

        [OperationContract]
        List<DTO.Shipping.PackageDetailDTO> AllPackageDetail();

        [OperationContract]
        List<DTO.Shipping.PackageDetailDTO> ByPackingID(Guid PackingID);

        [OperationContract]
        List<DTO.Shipping.PackageDetailDTO> ByBoxNumber(String BoxNumber);

        #endregion

        #region Role
        [OperationContract]
        List<DTO.Shipping.RoleDTO> AllRoles();

        [OperationContract]
        List<DTO.Shipping.RoleDTO> ByRoleID(Guid RoleID);
     
        #endregion



        #region Shipping
        [OperationContract]
        List<DTO.Shipping.ShippingDTO> AllShipping();

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ByShippingID(Guid ShippingID);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ByShippingNum(String ShippingNum);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ByOrderID(String OrderID);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ByCustomerPO(String CustomerPO);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ByVendorName(String VendorName);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ByVendorNum(String VendorNum);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ByCarrier(String Carrier);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ByShippingROWID(String ShippingROWID);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ByGetByFromDateToDate(DateTime FromDate, DateTime ToDate);
        #endregion


        #region Station Master.
        [OperationContract]
        List<DTO.Shipping.StationMasterDTO> AllStation();

        [OperationContract]
        List<DTO.Shipping.StationMasterDTO> ByStationID(Guid StaionID);

        [OperationContract]
        List<DTO.Shipping.StationMasterDTO> ByStationName(String StationName);

        [OperationContract]
        List<DTO.Shipping.StationMasterDTO> ByRequestedUserID(Guid RequestedUserID);
        #endregion

        #region Tracking.
        [OperationContract]
        List<DTO.Shipping.TrackingDTO> All();

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> ByTrackingID(Guid TrackingID);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> ByPackingID(Guid PackingID);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> ByShippingID(Guid ShippingID);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> ByBoxID(Guid BoxID);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> ByTrackingNUmber(String TrackingNUmber);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> ByVendorID(String VendorID);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> ByBoxNum(String BoxNum);
        #endregion



        #region User
        [OperationContract]
        List<DTO.Shipping.UserDTO> AllUser();

        [OperationContract]
        List<DTO.Shipping.UserDTO> ByUserID(Guid UserID);

        [OperationContract]
        List<DTO.Shipping.UserDTO> ByUserName(String UserName);

        [OperationContract]
        List<DTO.Shipping.UserDTO> ByRoleID(Guid RoleID);

        [OperationContract]
        List<DTO.Shipping.UserDTO> ByRoleName(String RoleName);

        #endregion

        #region UserStation
        [OperationContract]
        List<DTO.Shipping.UserStationDTO> AllUser();

        [OperationContract]
        List<DTO.Shipping.UserStationDTO> ByUserStationID(Guid UserStationID);

        [OperationContract]
        List<DTO.Shipping.UserStationDTO> ByUserID(Guid UserID);

        [OperationContract]
        List<DTO.Shipping.UserStationDTO> ByStationID(Guid StationID);

        #endregion

    }
}
