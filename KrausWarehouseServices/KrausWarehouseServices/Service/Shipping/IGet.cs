using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
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
        List<DTO.Shipping.AutditDTO> AuditByUserID(Guid _UserID);

        [OperationContract]
        List<DTO.Shipping.AutditDTO> AuditByUserLogID(Guid _UserLogID);
        #endregion

        #region BoxPackage
        [OperationContract]
        List<DTO.Shipping.BoxPackageDTO> AllBox();

        [OperationContract]
        DTO.Shipping.BoxPackageDTO BoxByBoxID(Guid _BoxID);

        [OperationContract]
        DTO.Shipping.BoxPackageDTO BoxByBoxNumber(String _BoxNumber);

        [OperationContract]
        List<DTO.Shipping.BoxPackageDTO> BoxByPackingID(Guid _PackingID);
        #endregion


        #region Package
        [OperationContract]
        List<DTO.Shipping.PackageDTO> PackageAllPackge();

        [OperationContract]
        List<DTO.Shipping.PackageDTO> PackageByPackageID(Guid PackageID);

        [OperationContract]
        List<DTO.Shipping.PackageDTO> PackageByStationID(Guid StationID);

        [OperationContract]
        List<DTO.Shipping.PackageDTO> PackageByUserID(Guid UserID);

        [OperationContract]
        List<DTO.Shipping.PackageDTO> PackageByShippingID(Guid ShippingID);

        [OperationContract]
        List<DTO.Shipping.PackageDTO> PackageByShippingNum(String ShippingNum);

        #endregion

        #region PackgeDetail

        [OperationContract]
        List<DTO.Shipping.PackageDetailDTO> PackageDetailAllPackageDetail();

        [OperationContract]
        List<DTO.Shipping.PackageDetailDTO> PackageDetailByPackingID(Guid PackingID);

        [OperationContract]
        List<DTO.Shipping.PackageDetailDTO> PackageDetailByBoxNumber(String BoxNumber);

        #endregion

        #region Role
        [OperationContract]
        List<DTO.Shipping.RoleDTO> RoleAllRoles();

        [OperationContract]
        List<DTO.Shipping.RoleDTO> RoleByRoleID(Guid RoleID);
     
        #endregion

        #region Shipping
        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ShippingAllShipping();

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ShippingByShippingID(Guid ShippingID);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ShippingByShippingNum(String ShippingNum);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ShippingByOrderID(String OrderID);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ShippingByCustomerPO(String CustomerPO);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ShippingByVendorName(String VendorName);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ShippingByVendorNum(String VendorNum);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ShippingByCarrier(String Carrier);

        [OperationContract]
        List<DTO.Shipping.ShippingDTO> ShippingByShippingROWID(String ShippingROWID);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ShippingByDateToDate?ID={FromDate}&value={ToDate}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        List<DTO.Shipping.ShippingDTO> ShippingByGetByFromDateToDate(DateTime FromDate, DateTime ToDate);
        #endregion

        #region Station Master.
        [OperationContract]
        List<DTO.Shipping.StationMasterDTO> StationMasterAllStation();

        [OperationContract]
        List<DTO.Shipping.StationMasterDTO> StationMasterByStationID(Guid StaionID);

        [OperationContract]
        List<DTO.Shipping.StationMasterDTO> StationMasterByStationName(String StationName);

        [OperationContract]
        List<DTO.Shipping.StationMasterDTO> StationMasterByRequestedUserID(Guid RequestedUserID);
        #endregion

        #region Tracking.
        [OperationContract]
        List<DTO.Shipping.TrackingDTO> TrackingAll();

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> TrackingByTrackingID(Guid TrackingID);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> TrackingByPackingID(Guid PackingID);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> TrackingByShippingID(Guid ShippingID);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> TrackingByBoxID(Guid BoxID);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> TrackingByTrackingNUmber(String TrackingNUmber);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> TrackingByVendorID(String VendorID);

        [OperationContract]
        List<DTO.Shipping.TrackingDTO> TrackingByBoxNum(String BoxNum);
        #endregion

        #region User
        [OperationContract]
        List<DTO.Shipping.UserDTO> UserAllUser();

        [OperationContract]
        List<DTO.Shipping.UserDTO> UserByUserID(Guid UserID);

        [OperationContract]
        List<DTO.Shipping.UserDTO> UserByUserName(String UserName);

        [OperationContract]
        List<DTO.Shipping.UserDTO> UserByRoleID(Guid RoleID);

        [OperationContract]
        List<DTO.Shipping.UserDTO> UserByRoleName(String RoleName);

        #endregion

        #region UserStation
        [OperationContract]
        List<DTO.Shipping.UserStationDTO> UserStationAllUser();

        [OperationContract]
        List<DTO.Shipping.UserStationDTO> UserStationByUserStationID(Guid UserStationID);

        [OperationContract]
        List<DTO.Shipping.UserStationDTO> UserStationByUserID(Guid UserID);

        [OperationContract]
        List<DTO.Shipping.UserStationDTO> UserStationByStationID(Guid StationID);

        #endregion

        #region ErrorLog.
        [OperationContract]
        List<DTO.Shipping.ErrorLogDTO> ErrorLogAll();
        
        #endregion

    }
}
