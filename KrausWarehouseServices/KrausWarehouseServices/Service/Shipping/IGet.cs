using KrausWarehouseServices.DTO.Shipping.ReportEntity;
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

        [OperationContract]
        [WebInvoke(UriTemplate = "/View_Get_Shipping_DataBySKUNameAndShippngNumber?ShippingNumber={ShippingNumber}&SKUName={SKUName}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml)]
        List<DTO.Shipping.viewGet_Shipping_DataDTO> View_Get_Shipping_DataBySKUNameAndShippngNumber(String ShippingNumber, String SKUName);

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

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/PackageByUserIDAndDate?ID={UserID}&value={Date}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        List<DTO.Shipping.PackageDTO> PackageByUserIDAndDate(Guid UserID, DateTime Date);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/PackageByShippingNumAndLocation?ID={ShippingNum}&value={Location}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        List<DTO.Shipping.PackageDTO> PackageByShippingNumAndLocation(string ShippingNum, string Location);

        [OperationContract]
        Guid PackingID(string PCKROWID);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        string MaxPackingID();

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

        #region Upc To SKU and vice versa

        [OperationContract]
        String UPCtoSKUName(String UPC_Code);

        [OperationContract]
        String SKUNameToUPCCode(String SKU_Name);
        #endregion

        #region ViewGetShippingDetail
        [OperationContract]
        List<DTO.Shipping.viewgetShippingDetails> ViewAllShippingDeatil();

        [OperationContract]
        List<DTO.Shipping.viewgetShippingDetails> ViewGetByShipmentNum(String ShipmentNumber);

        [OperationContract]
        List<DTO.Shipping.viewgetShippingDetails> ViewGetByOrderID(String _orderID);

        [OperationContract]
        List<DTO.Shipping.viewgetShippingDetails> ViewGetByPoNumber(String _POnumber);

        [OperationContract]
        List<DTO.Shipping.viewgetShippingDetails> ViewGetBySupplierNumber(String _SupplierNumber);

        [OperationContract]
        List<DTO.Shipping.viewgetShippingDetails> ViewGetByVendorName(String _VenderName);

        #endregion

        #region SKIImages
        [OperationContract]
        string GetBySKUname(string SKUname);


        [OperationContract]
        Boolean GetByBarcode(string SKUname);

        #endregion

        #region Report Commands

        #region cmdBPNameShippingNum
        [OperationContract]
        List<ShippingInfoBPNameDTO> GetBpinfoOFShippingNum();

        [OperationContract]
        string getBPNameFromBPNUM(string BPNUM_0);
        #endregion

        #region Packing Time and Quantity
        [OperationContract]
        List<PackingTimeDTO> GetPackingTimeAndQantity1();

        [OperationContract]
        List<PackingTimeDTO> GetPackingTimeAndQantity2(Guid UserID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity2?FDate={Fromdate}&TDatee={Todate}", 
            BodyStyle = WebMessageBodyStyle.Bare, 
            ResponseFormat = WebMessageFormat.Xml, 
            RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantity3(DateTime Fromdate, DateTime Todate);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity3?User={UserID}&FDate={Fromdate}&TDatee={Todate}",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantity4(Guid UserID, DateTime Fromdate, DateTime Todate);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity4?PStatus={PackingStatus}&BoolStatus={PackingStaus1}",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantity5(int PackingStatus, Boolean PackingStaus1);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity5?user={UserID}&PStatus={PackingStatus}",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantity6(Guid UserID, int PackingStatus);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity6?PStatus={PackingStatus}&FDate={Fromdate}&TDatee={Todate}",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantity7(DateTime Fromdate, DateTime Todate, int PackingStatus);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity7?UserI={UserID}&PStatus={PackingStatus}&FDate={Fromdate}&TDatee={Todate}",
           BodyStyle = WebMessageBodyStyle.Bare,
           ResponseFormat = WebMessageFormat.Xml,
           RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantity8(Guid UserID, DateTime Fromdate, DateTime Todate, int PackingStatus);



        #region By Station ID
        
        [OperationContract]

        List<PackingTimeDTO> GetPackingTimeAndQantityByStation21(Guid StationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity21?User={UserID}&Station={StationID}",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantityByStation22(Guid UserID, Guid StationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity22?FDate={Fromdate}&TDatee={Todate}&Station={StationID}",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Xml,
            RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantityByStation23(DateTime Fromdate, DateTime Todate, Guid StationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity23?FDate={Fromdate}&TDatee={Todate}&Station={StationID}&User={UserID}",
           BodyStyle = WebMessageBodyStyle.Bare,
           ResponseFormat = WebMessageFormat.Xml,
           RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantityByStation24(Guid UserID, DateTime Fromdate, DateTime Todate, Guid StationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity24?PackingStat={PackingStatus}&PackingSt={PackingStaus1}&Station={StationID}",
           BodyStyle = WebMessageBodyStyle.Bare,
           ResponseFormat = WebMessageFormat.Xml,
           RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantityByStation25(int PackingStatus, Boolean PackingStaus1, Guid StationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity25?User={UserID}&PackingSt={PackingStatus}&Station={StationID}",
           BodyStyle = WebMessageBodyStyle.Bare,
           ResponseFormat = WebMessageFormat.Xml,
           RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantityByStation26(Guid UserID, int PackingStatus, Guid StationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity26?Fromdat={Fromdate}&Todat={Todate}&PackingStat={PackingStatus}&Station={StationID}",
           BodyStyle = WebMessageBodyStyle.Bare,
           ResponseFormat = WebMessageFormat.Xml,
           RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantityByStation27(DateTime Fromdate, DateTime Todate, int PackingStatus, Guid StationID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetPackingTimeAndQantity27?UserI={UserID}&Fromdat={Fromdate}&Todat={Todate}&PackingStat={PackingStatus}&Station={StationID}",
          BodyStyle = WebMessageBodyStyle.Bare,
          ResponseFormat = WebMessageFormat.Xml,
          RequestFormat = WebMessageFormat.Xml)]
        List<PackingTimeDTO> GetPackingTimeAndQantityByStation28(Guid UserID, DateTime Fromdate, DateTime Todate, int PackingStatus, Guid StationID);

        #endregion


        #endregion

        #region cmdShippinNumStatus

        [OperationContract]
        List<ShipmentNumStatusDTO> GetStaus(String ShippingNumber);

        #endregion

        #region Shipping Number Status

        [OperationContract]
        List<StationToatlPackedDTO> GetEachStationPacked();

        [OperationContract]
        List<StationToatlPackedDTO> GetEachStationPacked1(DateTime DateReport);

        [OperationContract]
        List<DashBoardStionDTO> GetStationByReport(DateTime DateReport);

        [OperationContract]
        int PackedTodayByStationID(string StationName);

        [OperationContract]
        String UnderPackingID(String StationName);

        #endregion

        #region cmdUserCurrentStationAndDeviceID

        [OperationContract]
        List<UserCurrentStationAndDeviceIDDTO> LastLoginStationAllUsers();

        #endregion

        #region cmdUserShipmentCount

        [OperationContract]
        List<UserShipmentCountDTO> GetAllShipmentCountByUser();

        #endregion

        #region GetTotalShipmentPackedToday
        
        [OperationContract]
        List<ShipmentPackedTodayAndAvgTimeDTO> GetTotalShipmentPackedTime();
        
        #endregion

        #endregion

        #region Avg packing Time
        [OperationContract]
        List<KeyValuePair<string, float>> Execute(Guid UserID);
        #endregion
    }
}
